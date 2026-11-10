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
    }
}
