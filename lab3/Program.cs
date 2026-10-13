using lab3;
using System.Numerics;

public class Program
{
    public static void Main() 
    {
        HydroelectricPowerPlant hydroelectricPowerPlant = new HydroelectricPowerPlant();

        hydroelectricPowerPlant.CreateAlarms();

        hydroelectricPowerPlant.Start();

        PressureSensor pressureSensorBefore = new PressureSensor("Pressure before turbine", hydroelectricPowerPlant, true);
        PressureSensor pressureSensorAfter = new PressureSensor("Pressure after turbine", hydroelectricPowerPlant, false);
        LevelSensor levelSensorHead = new LevelSensor("Level in the headpond", hydroelectricPowerPlant, true);
        LevelSensor levelSensorTail = new LevelSensor("Level in the tailrace", hydroelectricPowerPlant, false);
        FlowSensor flowSensor = new FlowSensor("Water flow", hydroelectricPowerPlant);
        SpeedSensor speedSensor = new SpeedSensor("Turbine speed", hydroelectricPowerPlant);
        VoltageSensor voltageSensor = new VoltageSensor("Voltage of the generator", hydroelectricPowerPlant);
        CurrentSensor currentSensor = new CurrentSensor("Current of the generator", hydroelectricPowerPlant);
        GatePositionSensor gatePositionSensor = new GatePositionSensor("Position of the gate", hydroelectricPowerPlant);

        AnalogOutput gateControl = new AnalogOutput("Gate control");
        DiscreteOutput startSystem = new DiscreteOutput("System start");
        DiscreteOutput stopSystem = new DiscreteOutput("System stop");
        Emergency emergency = new Emergency("Emergency");
        AnalogOutput powerSignal = new AnalogOutput("Power control");
        AnalogOutput turbineControl = new AnalogOutput("Turbine control");


        hydroelectricPowerPlant.Sensors.Add(pressureSensorBefore);
        hydroelectricPowerPlant.Sensors.Add(pressureSensorAfter);
        hydroelectricPowerPlant.Sensors.Add(levelSensorHead);
        hydroelectricPowerPlant.Sensors.Add(levelSensorTail);
        hydroelectricPowerPlant.Sensors.Add(flowSensor);
        hydroelectricPowerPlant.Sensors.Add(speedSensor);
        hydroelectricPowerPlant.Sensors.Add(voltageSensor);
        hydroelectricPowerPlant.Sensors.Add(currentSensor);
        hydroelectricPowerPlant.Sensors.Add(gatePositionSensor);

        hydroelectricPowerPlant.Outputs.Add(gateControl);
        hydroelectricPowerPlant.Outputs.Add(startSystem);
        hydroelectricPowerPlant.Outputs.Add(stopSystem);
        hydroelectricPowerPlant.Outputs.Add(emergency);
        hydroelectricPowerPlant.Outputs.Add(powerSignal);
        hydroelectricPowerPlant.Outputs.Add(turbineControl);

        hydroelectricPowerPlant.UpdateState();
        hydroelectricPowerPlant.CheckAlarms();

        emergency.CheckAll(hydroelectricPowerPlant);

        foreach (var alarmItem in hydroelectricPowerPlant.Alarms)
        {
            if (alarmItem.GetStatus() == "Emergency")
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (alarmItem.GetStatus() == "Alarm")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }

            Console.WriteLine(alarmItem.Name + ": " + alarmItem.GetStatus());
            Console.ResetColor();
        }

        hydroelectricPowerPlant.Monitor();
    }
}