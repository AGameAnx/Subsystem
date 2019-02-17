using Subsystem.Wrappers;

namespace Subsystem.Patch
{
	public class TargetHighlightingAttributesPatch: SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapper)
		{
			if (!(wrapper is TargetHighlightingAttributesWrapper targetHighlightingAttributesWrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(HighlightWrecks, () => targetHighlightingAttributesWrapper.HighlightWrecks);
			loader.ApplyPropertyPatch(HighlightArtifacts, () => targetHighlightingAttributesWrapper.HighlightArtifacts);
		}

		public bool? HighlightWrecks { get; set; }
		public bool? HighlightArtifacts { get; set; }
	}
}
