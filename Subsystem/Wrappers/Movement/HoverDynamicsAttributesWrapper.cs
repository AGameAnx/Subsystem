using BBI.Core.Utility.FixedPoint;
using BBI.Game.Data;

namespace Subsystem.Wrappers
{
	public class HoverDynamicsAttributesWrapper : HoverDynamicsAttributes
	{
		public HoverDynamicsAttributesWrapper(HoverDynamicsAttributes other)
		{
			TurnAcceleration = other.TurnAcceleration;
			TurnMaxLookAheadTime = other.TurnMaxLookAheadTime;
			NoTurnDistance = other.NoTurnDistance;
			FaceTargetOnlyInCombat = other.FaceTargetOnlyInCombat;
			TurnHeuristic = other.TurnHeuristic;
		}

		public Fixed64 TurnAcceleration { get; set; }
		public Fixed64 TurnMaxLookAheadTime { get; set; }
		public Fixed64 NoTurnDistance { get; set; }
		public bool FaceTargetOnlyInCombat { get; set; }
		public HoverTurnHeuristic TurnHeuristic { get; set; }
	}
}
