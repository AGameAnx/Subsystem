using Subsystem.Wrappers;
using BBI.Core.Utility.FixedPoint;

namespace Subsystem.Patch
{
	public class ChainCastingAttributesPatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapperObj)
		{
			if (!(wrapperObj is ChainCastingAttributesWrapper wrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(QueuedAbility, () => wrapper.QueuedAbility);
			loader.ApplyPropertyPatch(QueuedAbilityDelay, () => wrapper.QueuedAbilityDelay, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(RetryQueueIfAbilityFails, () => wrapper.RetryQueueIfAbilityFails);
			loader.ApplyPropertyPatch(AbilityOnToggledOff, () => wrapper.AbilityOnToggledOff);
		}

		public string QueuedAbility { get; set; }
		public double? QueuedAbilityDelay { get; set; }
		public bool? RetryQueueIfAbilityFails { get; set; }
		public string AbilityOnToggledOff { get; set; }
	}
}
