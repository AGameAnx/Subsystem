using BBI.Game.Data;

namespace Subsystem.Wrappers
{
	public class PowerSystemViewAttributesWrapper : PowerSystemViewAttributes
	{
		public PowerSystemViewAttributesWrapper(PowerSystemViewAttributes other)
		{
			EnabledIconName = other.EnabledIconName;
			DisabledIconName = other.DisabledIconName;
			LocalizedTitleStringID = other.LocalizedTitleStringID;
			LocalizedShortDescriptionStringID = other.LocalizedShortDescriptionStringID;
			LocalizedLongDescriptionStringID = other.LocalizedLongDescriptionStringID;
			LocalizedSystemDisabledStringID = other.LocalizedSystemDisabledStringID;
		}

		public string EnabledIconName { get; set; }
		public string DisabledIconName { get; set; }
		public string LocalizedTitleStringID { get; set; }
		public string LocalizedShortDescriptionStringID { get; set; }
		public string LocalizedLongDescriptionStringID { get; set; }
		public string LocalizedSystemDisabledStringID { get; set; }
	}
}
