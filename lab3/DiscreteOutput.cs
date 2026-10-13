using System;
using System.Collections.Generic;
using System.Text;

namespace lab3
{
    public class DiscreteOutput : Output
    {
        public bool Value { get; private set; }

        public DiscreteOutput(string name)
            : base(name)
        {
            Value = false;
        }

        public void SetValue(bool value)
        {
            Value = value;
        }
    }
}
