using BBI.Game.Data;

namespace Subsystem.Wrappers
{
	public class ReverseOptionAttributesWrapper : ReverseOptionAttributes
	{
		public ReverseOptionAttributesWrapper(ReverseOptionAttributes other)
		{
			Use = other.Use;
			AllowUseWhenMovingForward = other.AllowUseWhenMovingForward;
			MustReachMinSpeedBeforeTurn = other.MustReachMinSpeedBeforeTurn;
			Region = other.Region;
		}

		public bool Use { get; set; }
		public bool AllowUseWhenMovingForward { get; set; }
		public bool MustReachMinSpeedBeforeTurn { get; set; }
		public ManeuverRegionAttributes Region { get; set; }
	}
}
