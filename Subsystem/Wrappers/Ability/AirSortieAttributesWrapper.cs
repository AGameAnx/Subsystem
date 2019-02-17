using BBI.Game.Data;
using BBI.Core.Utility.FixedPoint;

namespace Subsystem.Wrappers
{
	public class AirSortieAttributesWrapper : AirSortieAttributes
	{
		public AirSortieAttributesWrapper(AirSortieAttributes other)
		{
			LoiterLength = other.LoiterLength;
			SetAttackTargetsWithinRadius = other.SetAttackTargetsWithinRadius;
			SortieSquadSize = other.SortieSquadSize;
		}

		public Fixed64 LoiterLength { get; set; }
		public Fixed64 SetAttackTargetsWithinRadius { get; set; }
		public int SortieSquadSize { get; set; }
	}
}
