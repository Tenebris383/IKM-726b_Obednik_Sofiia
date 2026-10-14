using Models;

namespace Sensors
{
    public class LevelSensor : Sensor
    {
        private readonly bool isUpperLevel;
        public LevelSensor(string name, HydroelectricPowerPlant plant) : base(name, plant)
        {
            
        }

        public override void ReadValue()
        {
            if (Name == "Higher level")
            {
                Value = Plant.UpperLevel;
            }
            else
            {
                Value = Plant.TailLevel;
            }

            Console.WriteLine($"Sensor {Name} measured level {Value:F2} m.");
        }

    }
}
