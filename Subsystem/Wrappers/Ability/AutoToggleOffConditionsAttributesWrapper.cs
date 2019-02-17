using BBI.Game.Data;

namespace Subsystem.Wrappers
{
	public class AutoToggleOffConditionsAttributesWrapper : AutoToggleOffConditionsAttributes
	{
		public AutoToggleOffConditionsAttributesWrapper(AutoToggleOffConditionsAttributes other)
		{
			ManeuveringConditions = other.ManeuveringConditions;
			TakeDamage = other.TakeDamage;
		}

		public ManeuveringRequirements ManeuveringConditions { get; set; }
		public bool TakeDamage { get; set; }
	}
}
