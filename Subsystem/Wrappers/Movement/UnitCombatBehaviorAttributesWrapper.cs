using BBI.Core.Utility.FixedPoint;
using BBI.Game.Data;

namespace Subsystem.Wrappers
{
	public class UnitCombatBehaviorAttributesWrapper : UnitCombatBehavior
	{
		public UnitCombatBehaviorAttributesWrapper(UnitCombatBehavior other)
		{
			PassiveCombatApproachMode = other.PassiveCombatApproachMode;
			ActiveCombatApproachMode = other.ActiveCombatApproachMode;
			MinDesiredCombatRange = other.MinDesiredCombatRange;
			MaxDesiredCombatRange = other.MaxDesiredCombatRange;
			HoverStrafeCycleDuration = other.HoverStrafeCycleDuration;
			HoverStrafeLateralDisplacement = other.HoverStrafeLateralDisplacement;
			AdvanceThroughSmokeScreen = other.AdvanceThroughSmokeScreen;
		}

		public CombatApproachType PassiveCombatApproachMode { get; set; }
		public CombatApproachType ActiveCombatApproachMode { get; set; }
		public Fixed64 MinDesiredCombatRange { get; set; }
		public Fixed64 MaxDesiredCombatRange { get; set; }
		public Fixed64 HoverStrafeCycleDuration { get; set; }
		public Fixed64 HoverStrafeLateralDisplacement { get; set; }
		public bool AdvanceThroughSmokeScreen { get; set; }
	}
}
