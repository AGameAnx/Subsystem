using Subsystem.Wrappers;

namespace Subsystem.Patch
{
	public class AutocastAttributesPatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapperObj)
		{
			if (!(wrapperObj is AutocastAttributesWrapper wrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(IsAutocastable, () => wrapper.IsAutocastable);
			loader.ApplyPropertyPatch(AutocastEnabledOnSpawn, () => wrapper.AutocastEnabledOnSpawn);
		}

		public bool? IsAutocastable { get; set; }
		public bool? AutocastEnabledOnSpawn { get; set; }
	}
}
