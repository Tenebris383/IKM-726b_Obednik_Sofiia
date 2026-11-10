using Sensors.Entities;

namespace SCADA.web.Sevices
{
    public class SchemeConfigService
    {
        private readonly List<SensorView> _sensors = new List<SensorView>
        {
            new SensorView
            {
                Name = "Higher level", Topic = "hydroelectricPowerPlant/1/sensors/waterBody/level", X = 20, Y = 40
            },
            new SensorView
            {
                Name = "Lower level", Topic = "hydroelectricPowerPlant/1/sensors/waterBody/level", X = 50, Y = 60
            },
            new SensorView
            {
                Name = "Water flow", Topic = "hydroelectricPowerPlant/1/sensors/turbine/flow", X = 70, Y = 80
            },
            new SensorView
            {
                Name = "Pressure before turbine", Topic = "hydroelectricPowerPlant/1/sensors/turbine/pressureBefore", X = 80, Y = 90
            },
            new SensorView
            {
                Name = "Pressure after turbine", Topic = "hydroelectricPowerPlant/1/sensors/turbine/pressureAfter", X = 20, Y = 40
            },
            new SensorView
            {
                Name = "Turbine speed", Topic = "hydroelectricPowerPlant/1/sensors/turbine/speed", X = 20, Y = 40
            },
            new SensorView
            {
                Name = "Voltage of the generator", Topic = "hydroelectricPowerPlant/1/sensors/generator/voltage", X = 20, Y = 40
            },
            new SensorView
            {
                Name = "Current of the generator", Topic = "hydroelectricPowerPlant/1/alarms/generator/current", X = 20, Y = 40
            },
            new SensorView
            {
                Name = "Position of the gate", Topic = "hydroelectricPowerPlant/1/alarms/gate/position", X = 20, Y = 40
            }
        };

        public IReadOnlyList<SensorView> GetSensors()
        {
            return _sensors;
        }

    }
}
