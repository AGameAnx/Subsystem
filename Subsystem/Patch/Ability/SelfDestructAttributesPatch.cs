using Subsystem.Wrappers;
using BBI.Game.Data;
using BBI.Core.Utility.FixedPoint;

namespace Subsystem.Patch
{
	public class SelfDestructAttributesPatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapperObj)
		{
			if (!(wrapperObj is SelfDestructAttributesWrapper wrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(WeaponID, () => wrapper.WeaponID);
			loader.ApplyPropertyPatch(Lifetime, () => wrapper.Lifetime);
			loader.ApplyPropertyPatch(DurationSeconds, () => wrapper.DurationSeconds, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(TimeoutType, () => wrapper.TimeoutType);
		}

		public string WeaponID { get; set; }
		public SelfDestructLifetime? Lifetime { get; set; }
		public double? DurationSeconds { get; set; }
		public SelfDestructTimeoutType? TimeoutType { get; set; }
	}
}
