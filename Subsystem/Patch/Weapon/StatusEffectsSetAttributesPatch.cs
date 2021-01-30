using Subsystem.Wrappers;

namespace Subsystem.Patch
{
	public class StatusEffectsSetAttributesPatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapperObj)
		{
			if (!(wrapperObj is StatusEffectsSetAttributesWrapper wrapper))
				throw new System.InvalidCastException();

			loader.ApplyArrayPropertyPatch(StatusEffects, wrapper, "StatusEffects");
		}

		public string[] StatusEffects { get; set; } = null;
	}
}
