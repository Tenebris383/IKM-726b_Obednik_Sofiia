using System;
using System.Collections.Generic;
using System.Text;

namespace lab3
{
    public class CurrentSensor : Sensor
    {
        public CurrentSensor(string name, HydroelectricPowerPlant plant) : base(name, plant)
        {
        }

        public override void ReadValue()
        {
            Value = Plant.GeneratorCurrent;

            Console.WriteLine($"Sensor {Name} measured current {Value:F2} A.");
        }
    }
}
