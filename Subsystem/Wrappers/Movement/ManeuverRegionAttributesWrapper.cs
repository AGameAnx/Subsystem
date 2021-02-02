using BBI.Core.Utility.FixedPoint;
using BBI.Game.Data;

namespace Subsystem.Wrappers
{
	public class ManeuverRegionAttributesWrapper : ManeuverRegionAttributes
	{
		public ManeuverRegionAttributesWrapper(ManeuverRegionAttributes other)
		{
			Direction = other.Direction;
			HalfAngle = other.HalfAngle;
			MinRange = other.MinRange;
			MaxRange = other.MaxRange;
		}

		public RegionDirection Direction { get; set; }
		public Fixed64 HalfAngle { get; set; }
		public Fixed64 MinRange { get; set; }
		public Fixed64 MaxRange { get; set; }
	}
}
