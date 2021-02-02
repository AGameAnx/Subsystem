using Subsystem.Wrappers;
using BBI.Core.Utility.FixedPoint;
using BBI.Game.Data;

namespace Subsystem.Patch
{
	public class UnitManeuverAttributesPatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapperObj)
		{
			if (!(wrapperObj is UnitManeuverAttributesWrapper wrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(ObstacleAvoidanceDistance, () => wrapper.ObstacleAvoidanceDistance, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(MustReachMinSpeedBeforeTurn, () => wrapper.MustReachMinSpeedBeforeTurn);
			loader.ApplyPropertyPatch(CanGetOutOfDrift, () => wrapper.CanGetOutOfDrift);
			loader.ApplyPropertyPatch(CanReverse, () => wrapper.CanReverse);
			loader.ApplyPropertyPatch(CanStop, () => wrapper.CanStop);
			loader.ApplyPropertyPatch(CanDoSlowTurns, () => wrapper.CanDoSlowTurns);
			loader.ApplyPropertyPatch(CanDoFastTurns, () => wrapper.CanDoFastTurns);
			loader.ApplyArrayPropertyPatch(DriftRecoverOptions, wrapper, "DriftRecoverOptions");
			loader.ApplyPropertyPatch(SlowAwayTurn, () => wrapper.SlowAwayTurn);
			loader.ApplyPropertyPatch(SlowDirectTurn, () => wrapper.SlowDirectTurn);
			loader.ApplyPropertyPatch(FastAwayTurn, () => wrapper.FastAwayTurn);
			loader.ApplyPropertyPatch(FastDirectTurn, () => wrapper.FastDirectTurn);
			loader.ApplyPropertyPatch(DockingArrivalDistance, () => wrapper.DockingArrivalDistance, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(ArrivalDistance, () => wrapper.ArrivalDistance, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(ColumnCount, () => wrapper.ColumnCount);
			loader.ApplyPropertyPatch(FormationWeight, () => wrapper.FormationWeight);
			loader.ApplyPropertyPatch(FormationSpacingDistance, () => wrapper.FormationSpacingDistance, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(FormationSectionGapAhead, () => wrapper.FormationSectionGapAhead, x => Fixed64.UnsafeFromDouble(x));

			if (RearFacingArrive != null)
			{
				using (loader.logger.BeginScope($"RearFacingArrive:"))
				{
					var w = new ReverseOptionAttributesWrapper(wrapper.RearFacingArrive);
					RearFacingArrive.Apply(loader, w, null);
					wrapper.RearFacingArrive = w;
				}
			}
			if (PeelOut != null)
			{
				using (loader.logger.BeginScope($"PeelOut:"))
				{
					var w = new PeelOutAttributesWrapper(wrapper.PeelOut);
					PeelOut.Apply(loader, w, null);
					wrapper.PeelOut = w;
				}
			}
			if (ThreePointTurn != null)
			{
				using (loader.logger.BeginScope($"ThreePointTurn:"))
				{
					var w = new ReverseOptionAttributesWrapper(wrapper.ThreePointTurn);
					ThreePointTurn.Apply(loader, w, null);
					wrapper.ThreePointTurn = w;
				}
			}
			if (ThreePointTurn != null)
			{
				using (loader.logger.BeginScope($"JTurn:"))
				{
					var w = new JTurnAttributesWrapper(wrapper.JTurn);
					JTurn.Apply(loader, w, null);
					wrapper.JTurn = w;
				}
			}
		}

		public double? ObstacleAvoidanceDistance { get; set; }
		public ReverseOptionAttributesPatch RearFacingArrive { get; set; }
		public PeelOutAttributesPatch PeelOut { get; set; }
		public bool? MustReachMinSpeedBeforeTurn { get; set; }
		public bool? CanGetOutOfDrift { get; set; }
		public bool? CanReverse { get; set; }
		public bool? CanStop { get; set; }
		public bool? CanDoSlowTurns { get; set; }
		public bool? CanDoFastTurns { get; set; }
		public DriftRecoverStyle[] DriftRecoverOptions { get; set; } = null;
		public TurnStyle? SlowAwayTurn { get; set; }
		public TurnStyle? SlowDirectTurn { get; set; }
		public TurnStyle? FastAwayTurn { get; set; }
		public TurnStyle? FastDirectTurn { get; set; }
		public double? DockingArrivalDistance { get; set; }
		public double? ArrivalDistance { get; set; }
		public int? ColumnCount { get; set; }
		public int? FormationWeight { get; set; }
		public double? FormationSpacingDistance { get; set; }
		public double? FormationSectionGapAhead { get; set; }
		public ReverseOptionAttributesPatch ThreePointTurn { get; set; }
		public JTurnAttributesPatch JTurn { get; set; }
	}
}
