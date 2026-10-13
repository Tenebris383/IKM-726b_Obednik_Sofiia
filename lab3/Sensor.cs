using System;
namespace lab3;
public abstract class Sensor
{
	public int SensorId { get; set; }
	public double Value { get; protected set; }
	public string Name { get; set; }

	protected HydroelectricPowerPlant Plant { get; }

	public Sensor(string name, HydroelectricPowerPlant plant) 
	{
		Name = name;
		Plant = plant;
	}

	public abstract void ReadValue();
}
