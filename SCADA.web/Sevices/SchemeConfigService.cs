using Sensors.Entities;

namespace SCADA.web.Sevices
{
    public class SchemeConfigService
    {
        private readonly List<SensorView> _sensors = new List<SensorView>
        {
            new SensorView
            {
                Name = "Higher level", Topic = "hydroelectricPowerPlant/1/sensors/waterBody/level", X = 15, Y = 30
            },
            new SensorView
            {
                Name = "Lower level", Topic = "hydroelectricPowerPlant/1/sensors/waterBody/level", X = 700, Y = 360
            },
            new SensorView
            {
                Name = "Water flow", Topic = "hydroelectricPowerPlant/1/sensors/turbine/flow", X = 205, Y = 235
            },
            new SensorView
            {
                Name = "Pressure before turbine", Topic = "hydroelectricPowerPlant/1/sensors/turbine/pressureBefore", X = 235, Y = 315
            },
            new SensorView
            {
                Name = "Pressure after turbine", Topic = "hydroelectricPowerPlant/1/sensors/turbine/pressureAfter", X = 500, Y = 360
            },
            new SensorView
            {
                Name = "Turbine speed", Topic = "hydroelectricPowerPlant/1/sensors/turbine/speed", X = 545, Y = 250
            },
            new SensorView
            {
                Name = "Voltage of the generator", Topic = "hydroelectricPowerPlant/1/sensors/generator/voltage", X = 650, Y = 35
            },
            new SensorView
            {
                Name = "Current of the generator", Topic = "hydroelectricPowerPlant/1/alarms/generator/current", X = 650, Y = 105
            },
            new SensorView
            {
                Name = "Position of the gate", Topic = "hydroelectricPowerPlant/1/alarms/gate/position", X = 15, Y = 145
            }
        };

        public IReadOnlyList<SensorView> GetSensors()
        {
            return _sensors;
        }

    }
}
