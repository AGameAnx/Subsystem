using BBI.Game.Data;

namespace Subsystem.Wrappers
{
	public class PowerLevelViewAttributesWrapper : PowerLevelViewAttributes
	{
		public PowerLevelViewAttributesWrapper(PowerLevelViewAttributes other)
		{
			LocalizedShortDescriptionStringID = other.LocalizedShortDescriptionStringID;
		}

		public string LocalizedShortDescriptionStringID { get; set; }
	}
}
