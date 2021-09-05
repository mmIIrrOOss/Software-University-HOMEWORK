namespace VehiclesExtension
{
	public class Bus : Vehicle
	{

		private const double workingAirConditionerAdditionalConsumption = 1.4;
		private AirConditionerCondition airConditionerCondition;
		public Bus(double fuelQuantity, double fuelConsuption, double tankCapacity)
			: base(fuelQuantity, fuelConsuption, tankCapacity)
		{
			this.airConditionerCondition = AirConditionerCondition.On;
		}
		protected override double AdditionalConsumption =>
		airConditionerCondition == AirConditionerCondition.On ?
		workingAirConditionerAdditionalConsumption : (double)AirConditionerCondition.Off;

		public void SwitchOnAirConditioner()
		{
			this.airConditionerCondition = AirConditionerCondition.On;
		}

		public void SwitchOffAirConditioner()
		{
			this.airConditionerCondition = AirConditionerCondition.Off;
		}
	}
}
