
namespace Sensors
{
    public class PressureSensor : Sensor
    {
        public PressureSensor(string name) : base(name)
        {
        }

        public override void ReadValue()
        {

                Value = Random.Shared.NextDouble() * 100;


            Console.WriteLine($"Sensor {Name} measured pressure {Value:F2} MPa.");
        }
    }

}
