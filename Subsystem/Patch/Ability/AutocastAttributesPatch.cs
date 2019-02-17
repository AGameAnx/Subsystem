using Subsystem.Wrappers;

namespace Subsystem.Patch
{
	public class AutocastAttributesPatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapper)
		{
			if (!(wrapper is AutocastAttributesWrapper autocastAttributesWrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(IsAutocastable, () => autocastAttributesWrapper.IsAutocastable);
			loader.ApplyPropertyPatch(AutocastEnabledOnSpawn, () => autocastAttributesWrapper.AutocastEnabledOnSpawn);
		}

		public bool? IsAutocastable { get; set; }
		public bool? AutocastEnabledOnSpawn { get; set; }
	}
}
