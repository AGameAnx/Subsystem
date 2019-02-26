using BBI.Game.Data;
using System.Linq;

namespace Subsystem.Wrappers
{
	public class StatusEffectsSetAttributesWrapper : StatusEffectsSetAttributes
	{
		public StatusEffectsSetAttributesWrapper()
		{
		}

		public StatusEffectsSetAttributesWrapper(StatusEffectsSetAttributes other)
		{
			StatusEffects = other.StatusEffects?.ToArray();
		}

		public string[] StatusEffects { get; set; }
	}
}
