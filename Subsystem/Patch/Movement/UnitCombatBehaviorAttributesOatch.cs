using Subsystem.Wrappers;
using BBI.Core.Utility.FixedPoint;
using BBI.Game.Data;

namespace Subsystem.Patch
{
	public class UnitCombatBehaviorAttributesPatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapper)
		{
			if (!(wrapper is UnitCombatBehaviorAttributesWrapper unitCombatBehaviorAttributesWrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(PassiveCombatApproachMode, () => unitCombatBehaviorAttributesWrapper.PassiveCombatApproachMode);
			loader.ApplyPropertyPatch(ActiveCombatApproachMode, () => unitCombatBehaviorAttributesWrapper.ActiveCombatApproachMode);
			loader.ApplyPropertyPatch(MinDesiredCombatRange, () => unitCombatBehaviorAttributesWrapper.MinDesiredCombatRange, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(MaxDesiredCombatRange, () => unitCombatBehaviorAttributesWrapper.MaxDesiredCombatRange, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(HoverStrafeCycleDuration, () => unitCombatBehaviorAttributesWrapper.HoverStrafeCycleDuration, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(HoverStrafeLateralDisplacement, () => unitCombatBehaviorAttributesWrapper.HoverStrafeLateralDisplacement, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(AdvanceThroughSmokeScreen, () => unitCombatBehaviorAttributesWrapper.AdvanceThroughSmokeScreen);
		}

		public CombatApproachType? PassiveCombatApproachMode { get; set; }
		public CombatApproachType? ActiveCombatApproachMode { get; set; }
		public double? MinDesiredCombatRange { get; set; }
		public double? MaxDesiredCombatRange { get; set; }
		public double? HoverStrafeCycleDuration { get; set; }
		public double? HoverStrafeLateralDisplacement { get; set; }
		public bool? AdvanceThroughSmokeScreen { get; set; }
	}
}
