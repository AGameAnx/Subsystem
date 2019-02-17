using Subsystem.Wrappers;
using BBI.Core.Utility.FixedPoint;

namespace Subsystem.Patch
{
	public class AirSortieAttributesPatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapper)
		{
			if (!(wrapper is AirSortieAttributesWrapper airSortieAttributesWrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(LoiterLength, () => airSortieAttributesWrapper.LoiterLength, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(SetAttackTargetsWithinRadius, () => airSortieAttributesWrapper.SetAttackTargetsWithinRadius, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(SortieSquadSize, () => airSortieAttributesWrapper.SortieSquadSize);
		}

		public double? LoiterLength { get; set; }
		public double? SetAttackTargetsWithinRadius { get; set; }
		public int? SortieSquadSize { get; set; }
	}
}
