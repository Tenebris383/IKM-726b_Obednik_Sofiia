using System;
using System.Collections.Generic;
using System.Text;

namespace lab3
{
    public class Emergency : DiscreteOutput
    {
        public Emergency(string name)
            : base(name)
        {
        }

        private bool CheckValue(Alarm alarm, double value)
        {
            double range = alarm.MaxValue - alarm.MinValue;
            double emergencyRange = range * 0.1;

            if (value < alarm.MinValue - emergencyRange ||
                value > alarm.MaxValue + emergencyRange)
            {
                return true;
            }

            return false;
        }

        public void CheckAll(HydroelectricPowerPlant plant)
        {
            double[] values =
            {
                plant.UpperLevel,
                plant.TailLevel,
                plant.Flow,
                plant.PressureBefore,
                plant.PressureAfter,
                plant.TurbineSpeed,
                plant.GeneratorVoltage,
                plant.GeneratorCurrent,
                plant.GatePosition
            };

            bool emergency = false;

            for (int i = 0; i < plant.Alarms.Count; i++)
            {
                if (CheckValue(plant.Alarms[i], values[i]))
                {
                    emergency = true;
                }
            }

            SetValue(emergency);
        }

        public string GetStatus()
        {
            if (Value)
                return "Emergency";

            return "Normal";
        }
    }
}
