using Subsystem.Wrappers;
using BBI.Core.Utility.FixedPoint;
using BBI.Game.Data;

namespace Subsystem.Patch
{
	public class ManeuverRegionAttributesPatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapperObj)
		{
			if (!(wrapperObj is ManeuverRegionAttributesWrapper wrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(Direction, () => wrapper.Direction);
			loader.ApplyPropertyPatch(HalfAngle, () => wrapper.HalfAngle, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(MinRange, () => wrapper.MinRange, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(MaxRange, () => wrapper.MaxRange, x => Fixed64.UnsafeFromDouble(x));
		}

		public RegionDirection? Direction { get; set; }
		public double? HalfAngle { get; set; }
		public double? MinRange { get; set; }
		public double? MaxRange { get; set; }
	}
}
