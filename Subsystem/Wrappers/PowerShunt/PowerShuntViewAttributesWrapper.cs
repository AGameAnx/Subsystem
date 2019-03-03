using BBI.Core;
using BBI.Game.Data;

namespace Subsystem.Wrappers
{
	public class PowerShuntViewAttributesWrapper : NamedObjectBase, PowerShuntViewAttributes
	{
		public PowerShuntViewAttributesWrapper(PowerShuntViewAttributes other) : base(other.Name)
		{
			ReservePowerPoolLocalizedTitleStringID = other.ReservePowerPoolLocalizedTitleStringID;
			ReservePowerPoolLocalizedShortDescriptionStringID = other.ReservePowerPoolLocalizedShortDescriptionStringID;
			ReservePowerPoolLocalizedLongDescriptionStringID = other.ReservePowerPoolLocalizedLongDescriptionStringID;
			TemperatureGaugeLocalizedTitleStringID = other.TemperatureGaugeLocalizedTitleStringID;
			TemperatureGaugeLocalizedShortDescriptionStringID = other.TemperatureGaugeLocalizedShortDescriptionStringID;
			TemperatureGaugeLocalizedLongDescriptionStringID = other.TemperatureGaugeLocalizedLongDescriptionStringID;
		}

		public string ReservePowerPoolLocalizedTitleStringID { get; set; }
		public string ReservePowerPoolLocalizedShortDescriptionStringID { get; set; }
		public string ReservePowerPoolLocalizedLongDescriptionStringID { get; set; }
		public string TemperatureGaugeLocalizedTitleStringID { get; set; }
		public string TemperatureGaugeLocalizedShortDescriptionStringID { get; set; }
		public string TemperatureGaugeLocalizedLongDescriptionStringID { get; set; }
	}
}
