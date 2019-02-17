using BBI.Game.Data;

namespace Subsystem.Wrappers
{
	public class TargetHighlightingAttributesWrapper : TargetHighlightingAttributes
	{
		public TargetHighlightingAttributesWrapper(TargetHighlightingAttributes other)
		{
			HighlightWrecks = other.HighlightWrecks;
			HighlightArtifacts = other.HighlightArtifacts;
		}

		public bool HighlightWrecks { get; set; }
		public bool HighlightArtifacts { get; set; }
	}
}
