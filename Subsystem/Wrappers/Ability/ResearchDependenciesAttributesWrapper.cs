using BBI.Game.Data;

namespace Subsystem.Wrappers
{
	public class ResearchDependenciesAttributesWrapper : ResearchDependenciesAttributes
	{
		public ResearchDependenciesAttributesWrapper(ResearchDependenciesAttributes other)
		{
			RequiredResearch = other.RequiredResearch;
		}

		public string[] RequiredResearch { get; set; }
	}
}
