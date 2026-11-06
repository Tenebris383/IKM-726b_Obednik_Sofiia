
namespace Sensors
{
    public class FlowSensor : Sensor
    {
        public FlowSensor(string name) : base (name) 
        { 
        }

        public override void ReadValue()
        {
            Value = Random.Shared.NextDouble() * 100;
            Console.WriteLine($"Sensor {Name} measured flow {Value:F2} m3/s.");
        }
    }
}
