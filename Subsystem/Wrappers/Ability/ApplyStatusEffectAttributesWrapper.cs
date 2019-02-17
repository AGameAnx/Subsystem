using BBI.Game.Data;
using System.Linq;

namespace Subsystem.Wrappers
{
	public class ApplyStatusEffectAttributesWrapper : ApplyStatusEffectAttributes
	{
		public ApplyStatusEffectAttributesWrapper(ApplyStatusEffectAttributes other)
		{
			StatusEffectsToApply = other.StatusEffectsToApply.ToArray();
		}

		public StatusEffectAttributes[] StatusEffectsToApply { get; set; }
	}
}
