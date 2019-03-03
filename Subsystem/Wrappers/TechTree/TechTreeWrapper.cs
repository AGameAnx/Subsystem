using BBI.Core;
using BBI.Game.Data;
using System.Linq;

namespace Subsystem.Wrappers
{
	public class TechTreeWrapper : TechTree
	{
		public TechTreeWrapper()
		{
		}

		public TechTreeWrapper(TechTree other)
		{
			Tiers = other.Tiers.ToArray();
			Upgrades = other.Upgrades.ToArray();
			TechTreeName = other.TechTreeName;
			IconSpriteName = other.IconSpriteName;
		}

		public TechTreeTier[] Tiers { get; set; }
		public TechUpgrade[] Upgrades { get; set; }
		public string TechTreeName { get; set; }
		public string IconSpriteName { get; set; }
	}
}
