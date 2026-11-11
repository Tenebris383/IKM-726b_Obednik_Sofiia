using Sensors.Entities;

namespace SCADA.web.Sevices
{
    public class SchemeConfigService
    {
        private readonly List<SensorView> _sensors = new List<SensorView>
        {
            new SensorView
            {
                Name = "Upper level", Topic = "hydroelectricPowerPlant/1/sensors/waterBody/upperLevel", X = 15, Y = 30, Min = 0, Max = 50
            },
            new SensorView
            {
                Name = "Lower level", Topic = "hydroelectricPowerPlant/1/sensors/waterBody/lowerLevel", X = 700, Y = 360, Min = 0, Max = 30
            },
            new SensorView
            {
                Name = "Water flow", Topic = "hydroelectricPowerPlant/1/sensors/turbine/flow", X = 205, Y = 235, Min= 0, Max = 500
            },
            new SensorView
            {
                Name = "Pressure before turbine", Topic = "hydroelectricPowerPlant/1/sensors/turbine/pressureBefore", X = 235, Y = 315, Min = 0, Max = 3
            },
            new SensorView
            {
                Name = "Pressure after turbine", Topic = "hydroelectricPowerPlant/1/sensors/turbine/pressureAfter", X = 500, Y = 360, Min = 0, Max = 1
            },
            new SensorView
            {
                Name = "Turbine speed", Topic = "hydroelectricPowerPlant/1/sensors/turbine/speed", X = 545, Y = 250, Min = 0, Max = 300
            },
            new SensorView
            {
                Name = "Voltage of the generator", Topic = "hydroelectricPowerPlant/1/sensors/generator/voltage", X = 650, Y = 35, Min = 8, Max = 23
            },
            new SensorView
            {
                Name = "Current of the generator", Topic = "hydroelectricPowerPlant/1/sensors/generator/current", X = 650, Y = 105, Min = 0, Max = 1000
            },
            new SensorView
            {
                Name = "Position of the gate", Topic = "hydroelectricPowerPlant/1/sensors/gate/position", X = 15, Y = 145, Min = 0, Max = 100
            }
        };

        public IReadOnlyList<SensorView> GetSensors()
        {
            return _sensors;
        }

    }
}
