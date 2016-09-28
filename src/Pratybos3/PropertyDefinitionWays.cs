using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Pratybos3
{
    class PropertyDefinitionWays
    {
        public int AutomaticProperty { get; set; }
        public int ReadOnlyAutomaticProperty { get; }
        public int PrivateSetterAutomaticProperty { get; private set; }

        private int _value;
        public int ExplicitProperty
        {
            get { return _value; }
            set { _value = value; }
        }

        public int InlineProperty => AutomaticProperty + ReadOnlyAutomaticProperty;
        public int NonInlineProperty
        {
            get { return AutomaticProperty + ReadOnlyAutomaticProperty; }
        }
    }
}
