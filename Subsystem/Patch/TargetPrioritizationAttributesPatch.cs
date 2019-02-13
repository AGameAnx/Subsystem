using Subsystem.Wrappers;
using BBI.Core.Utility.FixedPoint;

namespace Subsystem.Patch
{
	public class TargetPrioritizationAttributesPatch: SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapper)
		{
			if (!(wrapper is TargetPriorizationAttributesWrapper targetPrioritizationAttributesWrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(WeaponEffectivenessWeight, () => targetPrioritizationAttributesWrapper.WeaponEffectivenessWeight, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(TargetThreatWeight, () => targetPrioritizationAttributesWrapper.TargetThreatWeight, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(DistanceWeight, () => targetPrioritizationAttributesWrapper.DistanceWeight, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(AngleWeight, () => targetPrioritizationAttributesWrapper.AngleWeight, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(TargetPriorityWeight, () => targetPrioritizationAttributesWrapper.TargetPriorityWeight, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(AutoTargetStickyBias, () => targetPrioritizationAttributesWrapper.AutoTargetStickyBias, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(ManualTargetStickyBias, () => targetPrioritizationAttributesWrapper.ManualTargetStickyBias, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(TargetSameCommanderBias, () => targetPrioritizationAttributesWrapper.TargetSameCommanderBias, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(TargetWithinFOVBias, () => targetPrioritizationAttributesWrapper.TargetWithinFOVBias, x => Fixed64.UnsafeFromDouble(x));
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
