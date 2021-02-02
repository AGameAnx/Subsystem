using BBI.Core.Utility.FixedPoint;
using BBI.Game.Data;

namespace Subsystem.Wrappers
{
	public class ReversePolarityAttributesWrapper : ReversePolarityAttributes
	{
		public ReversePolarityAttributesWrapper(ReversePolarityAttributes other)
		{
			Enabled = other.Enabled;
			RelativeWeight = other.RelativeWeight;
			PushRadiusMultiplier = other.PushRadiusMultiplier;
			SquishinessFactor = other.SquishinessFactor;
		}

		public bool Enabled { get; set; }
		public Fixed64 RelativeWeight { get; set; }
		public Fixed64 PushRadiusMultiplier { get; set; }
		public Fixed64 SquishinessFactor { get; set; }
	}
}
