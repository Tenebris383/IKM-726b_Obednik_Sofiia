using System;
using System.Collections.Generic;
using System.Text;

namespace lab3
{
    public class PressureSensor : Sensor
    {
        private readonly bool isBeforeTurbine;
        public PressureSensor(string name, HydroelectricPowerPlant plant, bool isBeforeTurbine) : base(name, plant)
        {
            this.isBeforeTurbine = isBeforeTurbine;
        }

        public override void ReadValue()
        {
            if (this.isBeforeTurbine)
            {
                Value = Plant.PressureBefore;
                Console.WriteLine($"Sensor {Name} measured pressure {Value:F2} Mpa.");
            }
            else
            {
                Value = Plant.PressureAfter;
                Console.WriteLine($"Sensor {Name} measured pressure {Value:F2} Mpa.");
            }

        }
    }

}
