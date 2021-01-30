using Subsystem.Wrappers;

namespace Subsystem.Patch
{
	public class TargetHighlightingAttributesPatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapperObj)
		{
			if (!(wrapperObj is TargetHighlightingAttributesWrapper wrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(HighlightWrecks, () => wrapper.HighlightWrecks);
			loader.ApplyPropertyPatch(HighlightArtifacts, () => wrapper.HighlightArtifacts);
		}

		public bool? HighlightWrecks { get; set; }
		public bool? HighlightArtifacts { get; set; }
	}
}
