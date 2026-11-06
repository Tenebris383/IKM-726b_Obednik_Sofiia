
namespace Sensors;
public abstract class Sensor
{
	public int SensorId { get; set; }
	public double Value { get; protected set; }
	public string Name { get; set; }

	public Sensor(string name) 
	{
		Name = name;
	}

    public abstract void ReadValue();
}
