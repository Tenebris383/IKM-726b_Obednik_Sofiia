using System;
using System.Collections.Generic;
using System.Text;

namespace Control
{
    public class Alarm : DiscreteOutput
    {
        public double MinValue { get; set; }
        public double MaxValue { get; set; }
        public bool IsAlarm { get; private set; }
        public bool IsEmergency { get; private set; }

        public Alarm(string name, double minValue, double maxValue)
           : base(name)
        {
            Name = name;
            MinValue = minValue;
            MaxValue = maxValue;
            IsAlarm = false;
            IsEmergency = false;
        }

        public void Check(double value)
        {
            IsAlarm = value < MinValue || value > MaxValue;

            IsEmergency =
                value < MinValue * 0.9 ||
                value > MaxValue * 1.1;
        }

        public string GetStatus()
        {
            if (IsEmergency)
                return "Emergency";

            if (IsAlarm)
                return "Alarm";

            return "Normal";
        }
    }
}
