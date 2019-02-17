using BBI.Game.Data;
using BBI.Core.Utility.FixedPoint;

namespace Subsystem.Wrappers
{
	public class ChainCastingAttributesWrapper : ChainCastingAttributes
	{
		public ChainCastingAttributesWrapper(ChainCastingAttributes other)
		{
			QueuedAbility = other.QueuedAbility;
			QueuedAbilityDelay = other.QueuedAbilityDelay;
			RetryQueueIfAbilityFails = other.RetryQueueIfAbilityFails;
			AbilityOnToggledOff = other.AbilityOnToggledOff;
		}

		public string QueuedAbility { get; set; }
		public Fixed64 QueuedAbilityDelay { get; set; }
		public bool RetryQueueIfAbilityFails { get; set; }
		public string AbilityOnToggledOff { get; set; }
	}
}
