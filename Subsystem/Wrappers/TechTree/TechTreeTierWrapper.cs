using BBI.Core;
using BBI.Game.Data;
using System.Linq;

namespace Subsystem.Wrappers
{
	public class TechTreeTierWrapper : TechTreeTier
	{
		public TechTreeTierWrapper()
		{
		}

		public TechTreeTierWrapper(TechTreeTier other)
		{
			ResearchItems = other.ResearchItems?.ToArray();
			TierName = other.TierName;
		}

		public string[] ResearchItems { get; set; }
		public string TierName { get; set; }
	}
}
