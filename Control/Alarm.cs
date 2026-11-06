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

            double emergencyRange = (MaxValue - MinValue) * 0.1;

            IsEmergency =
                value < MinValue - emergencyRange ||
                value > MaxValue + emergencyRange;
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
