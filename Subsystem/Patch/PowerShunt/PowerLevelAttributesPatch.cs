using Subsystem.Wrappers;
using System.Collections.Generic;
using System.Linq;

namespace Subsystem.Patch
{
	public class PowerLevelAttributesPatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapperObj)
		{
			if (!(wrapperObj is PowerLevelAttributesWrapper wrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(PowerUnitsRequired, () => wrapper.PowerUnitsRequired);
			loader.ApplyPropertyPatch(HeatPointsProvided, () => wrapper.HeatPointsProvided);

			var statusEffects = wrapper.StatusEffectsToApply?.Select(x => new StatusEffectAttributesWrapper(x)).ToList() ?? new List<StatusEffectAttributesWrapper>();
			loader.ApplyNamedListPatch(StatusEffectsToApply, statusEffects, (x) => new StatusEffectAttributesWrapper(x), "StatusEffectsToApply");
			wrapper.StatusEffectsToApply = statusEffects.ToArray();

			if (LocalizedShortDescriptionStringID != null)
			{
				PowerLevelViewAttributesWrapper powerLevelViewAttributesWrapper = new PowerLevelViewAttributesWrapper(wrapper.View);
				loader.ApplyPropertyPatch(LocalizedShortDescriptionStringID, () => powerLevelViewAttributesWrapper.LocalizedShortDescriptionStringID);
				wrapper.View = powerLevelViewAttributesWrapper;
			}
		}

		public int? PowerUnitsRequired { get; set; }
		public int? HeatPointsProvided { get; set; }
		public Dictionary<string, StatusEffectAttributesPatch> StatusEffectsToApply { get; set; } = new Dictionary<string, StatusEffectAttributesPatch>();

		public string LocalizedShortDescriptionStringID { get; set; }
	}
}
