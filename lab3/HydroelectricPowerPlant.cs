
namespace lab3
{
    public class HydroelectricPowerPlant
    {
        public List<Sensor> Sensors { get; set; }
        public List<Output> Outputs { get; set; }
        public List<Alarm> Alarms { get; set; }

        public bool IsRunning { get; private set; }

        public double UpperLevel { get; private set; }
        public double TailLevel { get; private set; }
        public double Flow {  get; private set; }
        public double PressureBefore { get; private set; }
        public double PressureAfter { get; private set; }
        public double TurbineSpeed { get; private set; }
        public double GeneratorVoltage { get; private set; }
        public double GeneratorCurrent {  get; private set; }
        public double GatePosition { get; private set; }
        private readonly Random random = new Random();
        public HydroelectricPowerPlant()
        {
            Sensors = new List<Sensor>();
            Outputs = new List<Output>();
            Alarms = new List<Alarm>();
            IsRunning = false;
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
        public void CheckAlarms()
        {
            Alarms[0].Check(UpperLevel);
            Alarms[1].Check(TailLevel);
            Alarms[2].Check(Flow);
            Alarms[3].Check(PressureBefore);
            Alarms[4].Check(PressureAfter);
            Alarms[5].Check(TurbineSpeed);
            Alarms[6].Check(GeneratorVoltage);
            Alarms[7].Check(GeneratorCurrent);
            Alarms[8].Check(GatePosition);
        }
        private double gateDirection = 1;
        public void Start()
        {
            IsRunning = true;
        }

        public void Stop()
        {
            IsRunning = false;
            GatePosition = 0;
        }

        public void SetGate(double value)
        {
            if (!IsRunning)
            {
                GatePosition = 0;
                return;
            }

            if (value < 0)
                value = 0;

            if (value > 100)
                value = 100;

            GatePosition = value;
        }
        public void UpdateState()
        {
            UpperLevel = random.NextDouble() * 50;
            TailLevel = random.NextDouble() * 30;
            if (!IsRunning)
            {
                Flow = 0;
                PressureBefore = 0;
                PressureAfter = 0;
                TurbineSpeed = 0;
                GeneratorVoltage = 0;
                GeneratorCurrent = 0;
                return;
            }
            GatePosition += 10 * gateDirection;

            if (GatePosition >= 100)
            {
                GatePosition = 100;
                gateDirection = -1;
            }

            if (GatePosition <= 0)
            {
                GatePosition = 0;
                gateDirection = 1;
            }
            Flow = 5 * GatePosition;
            PressureBefore = 0.05 * UpperLevel;
            PressureAfter = 0.02 * TailLevel;
            TurbineSpeed = 3 * GatePosition;
            GeneratorVoltage = 8.6 + 0.144 * GatePosition;
            GeneratorCurrent = 10.0 * GatePosition;
        }

        public void Monitor()
        {
            UpdateState();
            foreach (var sensor in Sensors)
            {
                sensor.ReadValue();
            }
        }
    }
}
