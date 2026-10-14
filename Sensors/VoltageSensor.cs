using Models;

namespace Sensors
{
    public class VoltageSensor : Sensor
    {
        public VoltageSensor(string name, HydroelectricPowerPlant plant) : base(name, plant)
        {
        }

        public override void ReadValue()
        {
            Value = Plant.GeneratorVoltage;

            Console.WriteLine($"Sensor {Name} measured voltage {Value:F2} kV.");
        }
    }
}
