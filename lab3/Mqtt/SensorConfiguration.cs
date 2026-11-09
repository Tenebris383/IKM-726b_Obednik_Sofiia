
using Sensors;

namespace Obednik_IKM_M726b.Mqtt;

public class SensorConfiguration
{
    public Sensor Sensor { get; set; }
    public string Topic { get; set; }
    public string AlarmTopic { get; set; }
    public string Unit { get; set; }


    public SensorConfiguration(Sensor sensor, string topic, string alarmTopic, string unit)
    {
        Sensor = sensor;
        Topic = topic;
        AlarmTopic = alarmTopic;
        Unit = unit;
    }
}
