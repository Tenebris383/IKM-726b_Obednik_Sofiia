using Models;

namespace Sensors
{
    public class PressureSensor : Sensor
    {
        private readonly bool isBeforeTurbine;
        public PressureSensor(string name, HydroelectricPowerPlant plant) : base(name, plant)
        {
        }

        public override void ReadValue()
        {
            if (Name == "Pressure before turbine")
            {
                Value = Plant.PressureBefore;
            }
            else
            {
                Value = Plant.PressureAfter;
            }

            Console.WriteLine($"Sensor {Name} measured pressure {Value:F2} MPa.");
        }
    }

}
