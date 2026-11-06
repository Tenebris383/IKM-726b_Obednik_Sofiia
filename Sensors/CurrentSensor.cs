
namespace Sensors
{
    public class CurrentSensor : Sensor
    {
        public CurrentSensor(string name) : base(name)
        {
        }

        public override void ReadValue()
        {
            Value = Random.Shared.NextDouble() * 100;

            Console.WriteLine($"Sensor {Name} measured current {Value:F2} A.");
        }
    }
}
