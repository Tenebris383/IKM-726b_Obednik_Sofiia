using Obednik_IKM_M726b.Mqtt;
using MQTTnet;
using System.Text.Json;
using Control;
using Models;
using Sensors;

public class Program
{
    public static async Task Main()
    {
        HydroelectricPowerPlant hydroelectricPowerPlant = new HydroelectricPowerPlant();

        List<Alarm> alarms = new List<Alarm>
        {
            new Alarm("Upper Water Level", 0, 50),
            new Alarm("Tail Water Level", 0, 30),
            new Alarm("Water Flow", 0, 500),
            new Alarm("Pressure Before Turbine", 0, 2.5),
            new Alarm("Pressure After Turbine", 0, 0.6),
            new Alarm("Turbine Speed", 0, 300),
            new Alarm("Generator Voltage", 8.6, 23),
            new Alarm("Generator Current", 0, 1000),
            new Alarm("Gate Position", 0, 100)
        };

        hydroelectricPowerPlant.Start();

        SensorConfiguration[] sensors = CreateSensors(hydroelectricPowerPlant);

        var factory = new MqttClientFactory();
        using var mqttClient = factory.CreateMqttClient();

        var options = new MqttClientOptionsBuilder()
            .WithTcpServer("127.0.0.1", 1883)
            .Build();

        await mqttClient.ConnectAsync(options);
        Console.WriteLine("Connected to MQTT broker");
        await RunSimulationAsync(mqttClient, sensors, hydroelectricPowerPlant);

        await mqttClient.DisconnectAsync();

        foreach (var sensor in sensors)
        {
            Console.WriteLine(
                $"{sensor.Sensor.Name}: {sensor.Topic} ({sensor.Unit})");
        } 
    }

    private static SensorConfiguration[] CreateSensors(HydroelectricPowerPlant hydroelectricPowerPlant)
    {
        return
        [
            new SensorConfiguration(
                new LevelSensor(
                "Higher level",
                hydroelectricPowerPlant),
            "hydroelectricPowerPlant/1/sensors/waterBody/level","m"),

            new SensorConfiguration(
                new LevelSensor(
                "Lower level",
                hydroelectricPowerPlant),
            "hydroelectricPowerPlant/1/sensors/waterBody/level","m"),

            new SensorConfiguration(
                new FlowSensor(
                "Water flow",
                hydroelectricPowerPlant),
            "hydroelectricPowerPlant/1/sensors/turbine/flow","m3/s"),

            new SensorConfiguration(
                new PressureSensor(
                "Pressure before turbine",
                hydroelectricPowerPlant),
            "hydroelectricPowerPlant/1/sensors/turbine/pressureBefore","MPa"),

            new SensorConfiguration(
                new PressureSensor(
                "Pressure after turbine",
                hydroelectricPowerPlant),
            "hydroelectricPowerPlant/1/sensors/turbine/pressureAfter","MPa"),

            new SensorConfiguration(
                new SpeedSensor(
                "Turbine speed",
                hydroelectricPowerPlant),
            "hydroelectricPowerPlant/1/sensors/turbine/speed","rpm"),

            new SensorConfiguration(
                new VoltageSensor(
                "Voltage of the generator",
                hydroelectricPowerPlant),
            "hydroelectricPowerPlant/1/sensors/generator/voltage","kV"),

            new SensorConfiguration(
                new CurrentSensor(
                "Current of the generator",
                hydroelectricPowerPlant),
            "hydroelectricPowerPlant/1/sensors/generator/current","A"),

            new SensorConfiguration(
                new GatePositionSensor(
                "Position of the gate",
                hydroelectricPowerPlant),
            "hydroelectricPowerPlant/1/sensors/gate/position","%")

        ];
    }

    private static async Task RunSimulationAsync(
            IMqttClient mqttClient,
            SensorConfiguration[] sensors,
            HydroelectricPowerPlant hydroelectricPowerPlant)
    {
        for (int iteration = 1; iteration <= 10; iteration++)
        {
            Console.WriteLine($"Iteration {iteration}.");
            hydroelectricPowerPlant.UpdateState();
            foreach (var sensor in sensors)
            {
                await PublicSensorReadingAsync(mqttClient, sensor);
            }

            Console.WriteLine();
            await Task.Delay(TimeSpan.FromSeconds(2));
        }
    }
    private static async Task PublicSensorReadingAsync(
        IMqttClient mqttClient,
        SensorConfiguration configuration)
    {

    configuration.Sensor.ReadValue();

    string payload = JsonSerializer.Serialize(new
    {
        value = Math.Round(configuration.Sensor.Value, 2),
        unit = configuration.Unit,
        measuredAtUtc = DateTimeOffset.UtcNow.ToString("HH:mm:ss")
    });

    var message = new MqttApplicationMessageBuilder()
            .WithTopic(configuration.Topic)
            .WithPayload(payload)
            .Build();
        await mqttClient.PublishAsync(message);
        Console.WriteLine($"Published {configuration.Topic} -> {payload}");
    }  
}