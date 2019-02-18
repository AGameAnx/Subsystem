using Subsystem.Wrappers;
using BBI.Core.Utility.FixedPoint;

namespace Subsystem.Patch
{
	public class RangeBasedWeaponAttributesPatch : SubsystemPatch, IRemovable
	{
		protected override void Apply(AttributeLoader loader, object wrapper)
		{
			if (!(wrapper is RangeBasedWeaponAttributesWrapper rangeBasedWeaponAttributesWrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(Accuracy, () => rangeBasedWeaponAttributesWrapper.Accuracy, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(Distance, () => rangeBasedWeaponAttributesWrapper.Distance, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(MinDistance, () => rangeBasedWeaponAttributesWrapper.MinDistance, x => Fixed64.UnsafeFromDouble(x));
		}

		public double? Accuracy { get; set; }
		public double? Distance { get; set; }
		public double? MinDistance { get; set; }

		public bool Remove { get; set; }
	}
}
