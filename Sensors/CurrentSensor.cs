using Models;

namespace Sensors
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
