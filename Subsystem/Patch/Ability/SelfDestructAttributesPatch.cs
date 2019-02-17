using Subsystem.Wrappers;
using BBI.Game.Data;
using BBI.Core.Utility.FixedPoint;

namespace Subsystem.Patch
{
	public class SelfDestructAttributesPatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapper)
		{
			if (!(wrapper is SelfDestructAttributesWrapper selfDestructAttributesWrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(WeaponID, () => selfDestructAttributesWrapper.WeaponID);
			loader.ApplyPropertyPatch(Lifetime, () => selfDestructAttributesWrapper.Lifetime);
			loader.ApplyPropertyPatch(DurationSeconds, () => selfDestructAttributesWrapper.DurationSeconds, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(TimeoutType, () => selfDestructAttributesWrapper.TimeoutType);
		}

		public string WeaponID { get; set; }
		public SelfDestructLifetime? Lifetime { get; set; }
		public double? DurationSeconds { get; set; }
		public SelfDestructTimeoutType? TimeoutType { get; set; }
	}
}
