
namespace Sensors
{
    public class VoltageSensor : Sensor
    {
        public VoltageSensor(string name) : base(name)
        {
        }

        public override void ReadValue()
        {
            Value = Random.Shared.NextDouble() * 100;

            Console.WriteLine($"Sensor {Name} measured voltage {Value:F2} kV.");
        }
    }
}
