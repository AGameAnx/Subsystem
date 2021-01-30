using Subsystem.Wrappers;
using BBI.Core.Utility.FixedPoint;

namespace Subsystem.Patch
{
	public class TargetPrioritizationAttributesPatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapperObj)
		{
			if (!(wrapperObj is TargetPriorizationAttributesWrapper wrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(WeaponEffectivenessWeight, () => wrapper.WeaponEffectivenessWeight, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(TargetThreatWeight, () => wrapper.TargetThreatWeight, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(DistanceWeight, () => wrapper.DistanceWeight, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(AngleWeight, () => wrapper.AngleWeight, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(TargetPriorityWeight, () => wrapper.TargetPriorityWeight, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(AutoTargetStickyBias, () => wrapper.AutoTargetStickyBias, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(ManualTargetStickyBias, () => wrapper.ManualTargetStickyBias, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(TargetSameCommanderBias, () => wrapper.TargetSameCommanderBias, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(TargetWithinFOVBias, () => wrapper.TargetWithinFOVBias, x => Fixed64.UnsafeFromDouble(x));
		}

		public double? WeaponEffectivenessWeight { get; set; }
		public double? TargetThreatWeight { get; set; }
		public double? DistanceWeight { get; set; }
		public double? AngleWeight { get; set; }
		public double? TargetPriorityWeight { get; set; }
		public double? AutoTargetStickyBias { get; set; }
		public double? ManualTargetStickyBias { get; set; }
		public double? TargetSameCommanderBias { get; set; }
		public double? TargetWithinFOVBias { get; set; }
	}
}
