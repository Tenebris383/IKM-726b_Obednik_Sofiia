using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Control
{
    public class AnalogOutput : Output
    {
        public double Value { get; private set; }

        public AnalogOutput(string name)
            : base(name)
        {
            Value = 0;
        }

        public void SetValue(double value)
        {
            Value = value;
        }
    }
}
