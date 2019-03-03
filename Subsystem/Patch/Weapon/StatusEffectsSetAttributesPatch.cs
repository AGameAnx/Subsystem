using Subsystem.Wrappers;

namespace Subsystem.Patch
{
	public class StatusEffectsSetAttributesPatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapper)
		{
			if (!(wrapper is StatusEffectsSetAttributesWrapper statusEffectsSetAttributesWrapper))
				throw new System.InvalidCastException();

			loader.ApplyArrayPropertyPatch(StatusEffects, statusEffectsSetAttributesWrapper, "StatusEffects");
		}

		public string[] StatusEffects { get; set; } = null;
	}
}
