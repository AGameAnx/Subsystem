using Subsystem.Wrappers;
using BBI.Core.Utility.FixedPoint;

namespace Subsystem.Patch
{
	public class TurretAttributesPatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapperObj)
		{
			if (!(wrapperObj is TurretAttributesWrapper wrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(FieldOfFire, () => wrapper.FieldOfFire, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(FieldOfView, () => wrapper.FieldOfView, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(RotationSpeed, () => wrapper.RotationSpeed, x => Fixed64.UnsafeFromDouble(x));
		}

		public double? FieldOfView { get; set; }
		public double? FieldOfFire { get; set; }
		public double? RotationSpeed { get; set; }
	}
}
