using Models;

namespace Sensors
{
    public class SpeedSensor : Sensor
    {
        public SpeedSensor(string name, HydroelectricPowerPlant plant) : base(name, plant)
        {
        }

        public override void ReadValue()
        {
            Value = Plant.TurbineSpeed;
            Console.WriteLine($"Sensor {Name} measured speed {Value:F0} Rpm.");
        }
    }
}
