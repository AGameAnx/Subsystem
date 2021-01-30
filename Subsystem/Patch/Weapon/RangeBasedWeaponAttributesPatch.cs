using Subsystem.Wrappers;
using BBI.Core.Utility.FixedPoint;

namespace Subsystem.Patch
{
	public class RangeBasedWeaponAttributesPatch : SubsystemPatch, IRemovable
	{
		protected override void Apply(AttributeLoader loader, object wrapperObj)
		{
			if (!(wrapperObj is RangeBasedWeaponAttributesWrapper wrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(Accuracy, () => wrapper.Accuracy, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(Distance, () => wrapper.Distance, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(MinDistance, () => wrapper.MinDistance, x => Fixed64.UnsafeFromDouble(x));
		}

		public double? Accuracy { get; set; }
		public double? Distance { get; set; }
		public double? MinDistance { get; set; }

		public bool Remove { get; set; }
	}
}
