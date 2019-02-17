using BBI.Game.Data;
using BBI.Core.Utility.FixedPoint;

namespace Subsystem.Wrappers
{
	public class SelfDestructAttributesWrapper : SelfDestructAttributes
	{
		public SelfDestructAttributesWrapper(SelfDestructAttributes other)
		{
			WeaponID = other.WeaponID;
			Lifetime = other.Lifetime;
			DurationSeconds = other.DurationSeconds;
			TimeoutType = other.TimeoutType;
		}

		public string WeaponID { get; set; }
		public SelfDestructLifetime Lifetime { get; set; }
		public Fixed64 DurationSeconds { get; set; }
		public SelfDestructTimeoutType TimeoutType { get; set; }
	}
}
