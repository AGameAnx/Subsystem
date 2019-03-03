using Subsystem.Wrappers;
using BBI.Core.Utility.FixedPoint;

namespace Subsystem.Patch
{
	public class TurretAttributesPatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapper)
		{
			if (!(wrapper is TurretAttributesWrapper turretAttributesWrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(FieldOfFire, () => turretAttributesWrapper.FieldOfFire, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(FieldOfView, () => turretAttributesWrapper.FieldOfView, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(RotationSpeed, () => turretAttributesWrapper.RotationSpeed, x => Fixed64.UnsafeFromDouble(x));
		}

		public double? FieldOfView { get; set; }
		public double? FieldOfFire { get; set; }
		public double? RotationSpeed { get; set; }
	}
}
