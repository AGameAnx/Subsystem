using Subsystem.Wrappers;
using BBI.Core.Utility.FixedPoint;

namespace Subsystem.Patch
{
	public class ChainCastingAttributesPatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapper)
		{
			if (!(wrapper is ChainCastingAttributesWrapper chainCastingAttributesWrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(QueuedAbility, () => chainCastingAttributesWrapper.QueuedAbility);
			loader.ApplyPropertyPatch(QueuedAbilityDelay, () => chainCastingAttributesWrapper.QueuedAbilityDelay, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(RetryQueueIfAbilityFails, () => chainCastingAttributesWrapper.RetryQueueIfAbilityFails);
			loader.ApplyPropertyPatch(AbilityOnToggledOff, () => chainCastingAttributesWrapper.AbilityOnToggledOff);
		}

		public string QueuedAbility { get; set; }
		public double? QueuedAbilityDelay { get; set; }
		public bool? RetryQueueIfAbilityFails { get; set; }
		public string AbilityOnToggledOff { get; set; }
	}
}
