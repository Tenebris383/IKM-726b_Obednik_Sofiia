
namespace Sensors
{
    public class SpeedSensor : Sensor
    {
        public SpeedSensor(string name) : base(name)
        {
        }

        public override void ReadValue()
        {
            Value = Random.Shared.NextDouble() * 100;
            Console.WriteLine($"Sensor {Name} measured speed {Value:F0} Rpm.");
        }
    }
}
