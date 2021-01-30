using Subsystem.Wrappers;
using BBI.Core.Utility.FixedPoint;

namespace Subsystem.Patch
{
	public class AirSortieAttributesPatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapperObj)
		{
			if (!(wrapperObj is AirSortieAttributesWrapper wrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(LoiterLength, () => wrapper.LoiterLength, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(SetAttackTargetsWithinRadius, () => wrapper.SetAttackTargetsWithinRadius, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(SortieSquadSize, () => wrapper.SortieSquadSize);
		}

		public double? LoiterLength { get; set; }
		public double? SetAttackTargetsWithinRadius { get; set; }
		public int? SortieSquadSize { get; set; }
	}
}
