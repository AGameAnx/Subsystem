using BBI.Core.Utility.FixedPoint;
using BBI.Game.Data;
using System.Linq;

namespace Subsystem.Wrappers
{
	public class UnitManeuverAttributesWrapper : UnitManeuverAttributes
	{
		public UnitManeuverAttributesWrapper(UnitManeuverAttributes other)
		{
			ObstacleAvoidanceDistance = other.ObstacleAvoidanceDistance;
			RearFacingArrive = other.RearFacingArrive;
			PeelOut = other.PeelOut;
			MustReachMinSpeedBeforeTurn = other.MustReachMinSpeedBeforeTurn;
			CanGetOutOfDrift = other.CanGetOutOfDrift;
			CanReverse = other.CanReverse;
			CanStop = other.CanStop;
			CanDoSlowTurns = other.CanDoSlowTurns;
			CanDoFastTurns = other.CanDoFastTurns;
			DriftRecoverOptions = other.DriftRecoverOptions?.ToArray();
			SlowAwayTurn = other.SlowAwayTurn;
			SlowDirectTurn = other.SlowDirectTurn;
			FastAwayTurn = other.FastAwayTurn;
			FastDirectTurn = other.FastDirectTurn;
			DockingArrivalDistance = other.DockingArrivalDistance;
			ArrivalDistance = other.ArrivalDistance;
			ColumnCount = other.ColumnCount;
			FormationWeight = other.FormationWeight;
			FormationSpacingDistance = other.FormationSpacingDistance;
			FormationSectionGapAhead = other.FormationSectionGapAhead;
			ThreePointTurn = other.ThreePointTurn;
			JTurn = other.JTurn;
		}

		public Fixed64 ObstacleAvoidanceDistance { get; set; }
		public ReverseOptionAttributes RearFacingArrive { get; set; }
		public PeelOutAttributes PeelOut { get; set; }
		public bool MustReachMinSpeedBeforeTurn { get; set; }
		public bool CanGetOutOfDrift { get; set; }
		public bool CanReverse { get; set; }
		public bool CanStop { get; set; }
		public bool CanDoSlowTurns { get; set; }
		public bool CanDoFastTurns { get; set; }
		public DriftRecoverStyle[] DriftRecoverOptions { get; set; }
		public TurnStyle SlowAwayTurn { get; set; }
		public TurnStyle SlowDirectTurn { get; set; }
		public TurnStyle FastAwayTurn { get; set; }
		public TurnStyle FastDirectTurn { get; set; }
		public Fixed64 DockingArrivalDistance { get; set; }
		public Fixed64 ArrivalDistance { get; set; }
		public int ColumnCount { get; set; }
		public int FormationWeight { get; set; }
		public Fixed64 FormationSpacingDistance { get; set; }
		public Fixed64 FormationSectionGapAhead { get; set; }
		public ReverseOptionAttributes ThreePointTurn { get; set; }
		public JTurnAttributes JTurn { get; set; }
	}
}
