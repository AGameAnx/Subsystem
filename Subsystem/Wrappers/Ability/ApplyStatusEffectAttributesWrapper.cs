using BBI.Game.Data;

namespace Subsystem.Wrappers
{
	public class ApplyStatusEffectAttributesWrapper : ApplyStatusEffectAttributes
	{
		public ApplyStatusEffectAttributesWrapper(ApplyStatusEffectAttributes other)
		{
			StatusEffectsToApply = other.StatusEffectsToApply;
		}

		public StatusEffectAttributes[] StatusEffectsToApply { get; set; }
	}
}
