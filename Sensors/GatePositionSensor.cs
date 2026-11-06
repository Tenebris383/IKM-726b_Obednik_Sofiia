
namespace Sensors
{
    public class GatePositionSensor : Sensor
    {
        public GatePositionSensor(string name) : base(name)
        {
        }
        public override void ReadValue()
        {
            Value = Random.Shared.NextDouble() * 100;
            Console.WriteLine($"Sensor {Name} is open {Value:F0} %.");
        }
    }
}
