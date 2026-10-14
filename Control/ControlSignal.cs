using System;
using System.Collections.Generic;
using System.Text;

namespace Control
{
    public class ControlSignal
    {
        public double Value { get; protected set; }
        public string Name { get; set; }
        public ControlSignal(string name)
        {
            Name = name;
        }

        public void SetValue(double value)
        {
            Value = value;
        }
    }
}
