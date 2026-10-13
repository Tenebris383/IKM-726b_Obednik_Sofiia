using System;
using System.Collections.Generic;
using System.Text;

namespace lab3
{
    public class LevelSensor : Sensor
    {
        private readonly bool isUpperLevel;
        public LevelSensor(string name, HydroelectricPowerPlant plant, bool isUpperLevel) : base(name, plant)
        {
            this.isUpperLevel = isUpperLevel;
        }

        public override void ReadValue()
        {
            if (isUpperLevel) 
            {
                Value = Plant.UpperLevel;
                Console.WriteLine($"Sensor {Name} measured level {Value:F2} m.");
            }
            else
            {
                Value = Plant.TailLevel;
                Console.WriteLine($"Sensor {Name} measured level {Value:F2} m.");
            }
        }

    }
}
