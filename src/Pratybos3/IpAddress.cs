
using System.Linq;
using System.Text.RegularExpressions;

public class IpAddress
{
    private uint _value;
    public byte[] Octets {
        get
        {
            return new[]
            {
                (byte)(_value / (256 * 256 * 256)),
                (byte)(_value / (256 * 256) % 256),
                (byte)(_value / 256 % (256 * 256)),
                (byte)(_value % (256 * 256 * 256))
            };
        }
    }

    public byte this[int octetIndex]
    {
        get
        {
            return Octets[octetIndex];
        }
    }

    public IpAddress(params byte[] octets)
    {
        _value = (uint)(octets[0] << 24) + (uint)(octets[1] << 16) + (uint)(octets[2] << 8) + octets[3];
    }

    public IpAddress(uint value)
    {
        _value = value;
    }

    public bool IsInSubnet(IpAddress subnet, IpAddress subnetMask)
    {
        var mySubnet = this & subnetMask;
        return mySubnet.Equals(subnet);
    }

    public static IpAddress operator &(IpAddress left, IpAddress right)
    {
        var newBytes = new byte[4];

        for (var i = 0;  i < newBytes.Length; i++)
        {
            newBytes[i] = (byte)(left.Octets[i] & right.Octets[i]);
        }

        return new IpAddress(newBytes);
    }

    public override bool Equals(object obj)
    {
        var ip = obj as IpAddress;
        if (ip == null) return false;

        return _value == ip._value;
    }

    public override int GetHashCode()
    {
        return _value.GetHashCode();
    }

    private static Regex IpRegex =
        new Regex(@"^(\d{1,3})\.(\d{1,3})\.(\d{1,3})\.(\d{1,3})$");

    public static bool IsIpAddress(string ip)
    {
        return IpRegex.IsMatch(ip);
    }

    public static IpAddress Parse(string ip)
    {
        var match = IpRegex.Match(ip);
        return new IpAddress(
            byte.Parse(match.Groups[1].Value),
            byte.Parse(match.Groups[2].Value),
            byte.Parse(match.Groups[3].Value),
            byte.Parse(match.Groups[4].Value)
            );
    }
}