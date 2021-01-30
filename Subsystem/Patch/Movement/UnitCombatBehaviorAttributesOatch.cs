using Subsystem.Wrappers;
using BBI.Core.Utility.FixedPoint;
using BBI.Game.Data;

namespace Subsystem.Patch
{
	public class UnitCombatBehaviorAttributesPatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapperObj)
		{
			if (!(wrapperObj is UnitCombatBehaviorAttributesWrapper wrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(PassiveCombatApproachMode, () => wrapper.PassiveCombatApproachMode);
			loader.ApplyPropertyPatch(ActiveCombatApproachMode, () => wrapper.ActiveCombatApproachMode);
			loader.ApplyPropertyPatch(MinDesiredCombatRange, () => wrapper.MinDesiredCombatRange, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(MaxDesiredCombatRange, () => wrapper.MaxDesiredCombatRange, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(HoverStrafeCycleDuration, () => wrapper.HoverStrafeCycleDuration, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(HoverStrafeLateralDisplacement, () => wrapper.HoverStrafeLateralDisplacement, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(AdvanceThroughSmokeScreen, () => wrapper.AdvanceThroughSmokeScreen);
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
