using Subsystem.Wrappers;

namespace Subsystem.Patch
{
	public class PowerShuntViewAttributesPatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapperObj)
		{
			if (!(wrapperObj is PowerShuntViewAttributesWrapper wrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(ReservePowerPoolLocalizedTitleStringID, () => wrapper.ReservePowerPoolLocalizedTitleStringID);
			loader.ApplyPropertyPatch(ReservePowerPoolLocalizedShortDescriptionStringID, () => wrapper.ReservePowerPoolLocalizedShortDescriptionStringID);
			loader.ApplyPropertyPatch(ReservePowerPoolLocalizedLongDescriptionStringID, () => wrapper.ReservePowerPoolLocalizedLongDescriptionStringID);
			loader.ApplyPropertyPatch(TemperatureGaugeLocalizedTitleStringID, () => wrapper.TemperatureGaugeLocalizedTitleStringID);
			loader.ApplyPropertyPatch(TemperatureGaugeLocalizedShortDescriptionStringID, () => wrapper.TemperatureGaugeLocalizedShortDescriptionStringID);
			loader.ApplyPropertyPatch(TemperatureGaugeLocalizedLongDescriptionStringID, () => wrapper.TemperatureGaugeLocalizedLongDescriptionStringID);
		}

		public string ReservePowerPoolLocalizedTitleStringID { get; set; }
		public string ReservePowerPoolLocalizedShortDescriptionStringID { get; set; }
		public string ReservePowerPoolLocalizedLongDescriptionStringID { get; set; }
		public string TemperatureGaugeLocalizedTitleStringID { get; set; }
		public string TemperatureGaugeLocalizedShortDescriptionStringID { get; set; }
		public string TemperatureGaugeLocalizedLongDescriptionStringID { get; set; }
	}
}
