using Sensors.Entities;
using System.Collections.Concurrent;

namespace SCADA.web.Sevices
{
    public class LiveValuesCache
    {
        private readonly ConcurrentDictionary<string, SensorReading> _values = new();
        public void Update(SensorReading reading)
        {
            _values[reading.Topic] = reading;
        }

        public List<SensorReading> GetAll()
        {
            return _values.Values.ToList();
        }
        private readonly ConcurrentDictionary<string, string> _alarms = new();

        public void UpdateAlarm(string topic, string status)
        {
            _alarms[topic] = status;
        }

        public Dictionary<string, string> GetAllAlarms()
        {
            return _alarms.ToDictionary(x => x.Key, x => x.Value);
        }
    }
}
