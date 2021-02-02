using Subsystem.Wrappers;
using BBI.Core.Utility.FixedPoint;

namespace Subsystem.Patch
{
	public class ReversePolarityAttributesPatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapperObj)
		{
			if (!(wrapperObj is ReversePolarityAttributesWrapper wrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(Enabled, () => wrapper.Enabled);
			loader.ApplyPropertyPatch(RelativeWeight, () => wrapper.RelativeWeight, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(PushRadiusMultiplier, () => wrapper.PushRadiusMultiplier, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(SquishinessFactor, () => wrapper.SquishinessFactor, x => Fixed64.UnsafeFromDouble(x));
		}

		public bool? Enabled { get; set; }
		public double? RelativeWeight { get; set; }
		public double? PushRadiusMultiplier { get; set; }
		public double? SquishinessFactor { get; set; }
	}
}
