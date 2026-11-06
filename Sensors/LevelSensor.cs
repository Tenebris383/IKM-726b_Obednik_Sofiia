
namespace Sensors
{
    public class LevelSensor : Sensor
    {
        private readonly bool isUpperLevel;
        public LevelSensor(string name) : base(name)
        {
            
        }

        public override void ReadValue()
        {

                Value = Random.Shared.NextDouble() * 100;

            Console.WriteLine($"Sensor {Name} measured level {Value:F2} m.");
        }

    }
}
