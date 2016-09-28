using System;

public class Maybe<T>
{
    private readonly T _value;
    private readonly bool _hasValue;

    public Maybe()
    {
    }


    public Maybe(T value)
    {
        _value = value;
        _hasValue = true;
    }

    public bool HasValue => _hasValue;
    
    public T Value
    {
        get
        {
            if (!_hasValue)
                throw new InvalidOperationException("Attempted to access missing value");

            return _value;
        }
    }
}

public class Maybe
{
    public static Maybe<T> Of<T>(T value)
    {
        return new Maybe<T>(value);
    }
}