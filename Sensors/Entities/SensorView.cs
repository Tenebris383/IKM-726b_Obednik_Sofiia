using System;
using System.Collections.Generic;
using System.Text;

namespace Sensors.Entities
{
    public class SensorView
    {
        public string Name { get; set; } = "";
        public string Topic { get; set; } = "";
        public int X { get; set; }
        public int Y { get; set; }
    }
}
