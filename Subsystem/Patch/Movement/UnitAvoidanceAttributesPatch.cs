using Subsystem.Wrappers;
using BBI.Core.Utility.FixedPoint;

namespace Subsystem.Patch
{
	public class UnitAvoidanceAttributesPatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapperObj)
		{
			if (!(wrapperObj is UnitAvoidanceAttributesWrapper wrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(AvoidsCarriers, () => wrapper.AvoidsCarriers);
			loader.ApplyPropertyPatch(AvoidsWrecks, () => wrapper.AvoidsWrecks);
			loader.ApplyPropertyPatch(AvoidanceDistance, () => wrapper.AvoidanceDistance, x => Fixed64.UnsafeFromDouble(x));
		}

		public bool? AvoidsCarriers { get; set; }
		public bool? AvoidsWrecks { get; set; }
		public double? AvoidanceDistance { get; set; }
	}
}
