using System;
using System.Collections.Generic;
using System.Text;

namespace lab3
{
    public class GatePositionSensor : Sensor
    {
        public GatePositionSensor(string name, HydroelectricPowerPlant plant) : base(name, plant)
        {
        }
        public override void ReadValue()
        {
            Value = Plant.GatePosition;
            Console.WriteLine($"Sensor {Name} is open {Value:F0} %.");
        }
    }
}
