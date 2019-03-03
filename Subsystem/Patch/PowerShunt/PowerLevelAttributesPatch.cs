using Subsystem.Wrappers;
using System.Collections.Generic;
using System.Linq;

namespace Subsystem.Patch
{
	public class PowerLevelAttributesPatch: SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapper)
		{
			if (!(wrapper is PowerLevelAttributesWrapper powerLevelAttributesWrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(PowerUnitsRequired, () => powerLevelAttributesWrapper.PowerUnitsRequired);
			loader.ApplyPropertyPatch(HeatPointsProvided, () => powerLevelAttributesWrapper.HeatPointsProvided);

			var statusEffects = powerLevelAttributesWrapper.StatusEffectsToApply?.Select(x => new StatusEffectAttributesWrapper(x)).ToList() ?? new List<StatusEffectAttributesWrapper>();
			loader.ApplyNamedListPatch(StatusEffectsToApply, statusEffects, (x) => new StatusEffectAttributesWrapper(x), "StatusEffectsToApply");
			powerLevelAttributesWrapper.StatusEffectsToApply = statusEffects.ToArray();
		}

		public int? PowerUnitsRequired { get; set; }
		public int? HeatPointsProvided { get; set; }
		public Dictionary<string, StatusEffectAttributesPatch> StatusEffectsToApply { get; set; } = new Dictionary<string, StatusEffectAttributesPatch>();
		//PowerLevelViewAttributes View { get; set; }
	}
}
