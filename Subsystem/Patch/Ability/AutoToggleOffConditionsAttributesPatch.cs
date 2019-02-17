using Subsystem.Wrappers;
using BBI.Game.Data;

namespace Subsystem.Patch
{
	public class AutoToggleOffConditionsAttributesPatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapper)
		{
			if (!(wrapper is AutoToggleOffConditionsAttributesWrapper autoToggleOffConditionsAttributesWrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(ManeuveringConditions, () => autoToggleOffConditionsAttributesWrapper.ManeuveringConditions);
			loader.ApplyPropertyPatch(TakeDamage, () => autoToggleOffConditionsAttributesWrapper.TakeDamage);
		}

		public ManeuveringRequirements? ManeuveringConditions { get; set; }
		public bool? TakeDamage { get; set; }
	}
}
