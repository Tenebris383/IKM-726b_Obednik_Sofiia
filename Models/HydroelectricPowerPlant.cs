
namespace Models;

public class HydroelectricPowerPlant
{
    public bool IsRunning { get; private set; }
    public double UpperLevel { get; private set; }
    public double TailLevel { get; private set; }
    public double Flow { get; private set; }
    public double PressureBefore { get; private set; }
    public double PressureAfter { get; private set; }
    public double TurbineSpeed { get; private set; }
    public double GeneratorVoltage { get; private set; }
    public double GeneratorCurrent { get; private set; }
    public double GatePosition { get; private set; }

    private readonly Random random = new Random();
    private double gateDirection = 1;

    public void Start()
    {
        IsRunning = true;
    }

    public void Stop()
    {
        IsRunning = false;
        GatePosition = 0;
        gateDirection = 1;
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
            GatePosition = 0;
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
}

