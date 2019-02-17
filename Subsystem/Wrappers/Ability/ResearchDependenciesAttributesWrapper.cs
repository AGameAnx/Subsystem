using BBI.Game.Data;
using System.Linq;

namespace Subsystem.Wrappers
{
	public class ResearchDependenciesAttributesWrapper : ResearchDependenciesAttributes
	{
		public ResearchDependenciesAttributesWrapper(ResearchDependenciesAttributes other)
		{
			RequiredResearch = other.RequiredResearch.ToArray();
		}

		public string[] RequiredResearch { get; set; }
	}
}
