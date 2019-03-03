using Subsystem.Wrappers;

namespace Subsystem.Patch
{
	public class PowerShuntViewAttributesPatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapper)
		{
			if (!(wrapper is PowerShuntViewAttributesWrapper powerShuntViewAttributesWrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(ReservePowerPoolLocalizedTitleStringID, () => powerShuntViewAttributesWrapper.ReservePowerPoolLocalizedTitleStringID);
			loader.ApplyPropertyPatch(ReservePowerPoolLocalizedShortDescriptionStringID, () => powerShuntViewAttributesWrapper.ReservePowerPoolLocalizedShortDescriptionStringID);
			loader.ApplyPropertyPatch(ReservePowerPoolLocalizedLongDescriptionStringID, () => powerShuntViewAttributesWrapper.ReservePowerPoolLocalizedLongDescriptionStringID);
			loader.ApplyPropertyPatch(TemperatureGaugeLocalizedTitleStringID, () => powerShuntViewAttributesWrapper.TemperatureGaugeLocalizedTitleStringID);
			loader.ApplyPropertyPatch(TemperatureGaugeLocalizedShortDescriptionStringID, () => powerShuntViewAttributesWrapper.TemperatureGaugeLocalizedShortDescriptionStringID);
			loader.ApplyPropertyPatch(TemperatureGaugeLocalizedLongDescriptionStringID, () => powerShuntViewAttributesWrapper.TemperatureGaugeLocalizedLongDescriptionStringID);
		}

		public string ReservePowerPoolLocalizedTitleStringID { get; set; }
		public string ReservePowerPoolLocalizedShortDescriptionStringID { get; set; }
		public string ReservePowerPoolLocalizedLongDescriptionStringID { get; set; }
		public string TemperatureGaugeLocalizedTitleStringID { get; set; }
		public string TemperatureGaugeLocalizedShortDescriptionStringID { get; set; }
		public string TemperatureGaugeLocalizedLongDescriptionStringID { get; set; }
	}
}
