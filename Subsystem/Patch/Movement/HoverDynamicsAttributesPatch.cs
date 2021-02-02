using Subsystem.Wrappers;
using BBI.Core.Utility.FixedPoint;
using BBI.Game.Data;

namespace Subsystem.Patch
{
	public class HoverDynamicsAttributesPatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapperObj)
		{
			if (!(wrapperObj is HoverDynamicsAttributesWrapper wrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(TurnAcceleration, () => wrapper.TurnAcceleration, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(TurnMaxLookAheadTime, () => wrapper.TurnMaxLookAheadTime, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(NoTurnDistance, () => wrapper.NoTurnDistance, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(FaceTargetOnlyInCombat, () => wrapper.FaceTargetOnlyInCombat);
			loader.ApplyPropertyPatch(TurnHeuristic, () => wrapper.TurnHeuristic);
		}

		public double? TurnAcceleration { get; set; }
		public double? TurnMaxLookAheadTime { get; set; }
		public double? NoTurnDistance { get; set; }
		public bool? FaceTargetOnlyInCombat { get; set; }
		public HoverTurnHeuristic? TurnHeuristic { get; set; }
	}
}
