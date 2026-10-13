using System;
using System.Collections.Generic;
using System.Text;

namespace lab3
{
    public class FlowSensor : Sensor
    {
        public FlowSensor(string name, HydroelectricPowerPlant plant) : base (name, plant) 
        { 
        }

        public override void ReadValue()
        {
            Value = Plant.Flow;
            Console.WriteLine($"Sensor {Name} measured flow {Value:F2} m3/s.");
        }
    }
}
