
using Sensors;
using Control;
namespace Models;

public class HydroelectricPowerPlant
{

    public List<Sensor> Sensors { get; set; }
    public List<Output> Outputs { get; set; }
    public List<Alarm> Alarms { get; set; }

    public HydroelectricPowerPlant()
    {
        Sensors = new List<Sensor>();
        Outputs = new List<Output>();
        Alarms = new List<Alarm>();
    }
    public void CreateAlarms()
    {
        Alarms.Add(new Alarm("Upper Water Level", 0, 50));
        Alarms.Add(new Alarm("Tail Water Level", 0, 30));
        Alarms.Add(new Alarm("Water Flow", 0, 500));
        Alarms.Add(new Alarm("Pressure Before Turbine", 0, 2.5));
        Alarms.Add(new Alarm("Pressure After Turbine", 0, 0.6));
        Alarms.Add(new Alarm("Turbine Speed", 0, 300));
        Alarms.Add(new Alarm("Generator Voltage", 8.6, 23));
        Alarms.Add(new Alarm("Generator Current", 0, 1000));
        Alarms.Add(new Alarm("Gate Position", 0, 100));
    }

    public void Monitor()
    {
        foreach (var sensor in Sensors)
        {
            sensor.ReadValue();
        }
    }

    public void CheckAlarms()
    {
        for (int i = 0; i < Sensors.Count; i++)
        {
            Alarms[i].Check(Sensors[i].Value);

        }
    }
}