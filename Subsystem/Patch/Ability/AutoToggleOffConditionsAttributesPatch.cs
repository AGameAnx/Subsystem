using Subsystem.Wrappers;
using BBI.Game.Data;

namespace Subsystem.Patch
{
	public class AutoToggleOffConditionsAttributesPatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapperObj)
		{
			if (!(wrapperObj is AutoToggleOffConditionsAttributesWrapper wrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(ManeuveringConditions, () => wrapper.ManeuveringConditions);
			loader.ApplyPropertyPatch(TakeDamage, () => wrapper.TakeDamage);
		}

		public ManeuveringRequirements? ManeuveringConditions { get; set; }
		public bool? TakeDamage { get; set; }
	}
}
