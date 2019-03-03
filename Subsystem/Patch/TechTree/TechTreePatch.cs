using Subsystem.Wrappers;
using BBI.Game.Data;
using System.Collections.Generic;
using System.Linq;

namespace Subsystem.Patch
{
	public class TechTreePatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapper)
		{
			if (!(wrapper is TechTreeWrapper techTreeWrapper))
				throw new System.InvalidCastException();

			if (Tiers != null)
			{
				var tiers = techTreeWrapper.Tiers?.Select(x => new TechTreeTierWrapper(x)).ToList() ?? new List<TechTreeTierWrapper>();
				loader.ApplyListPatch(Tiers, tiers, () => new TechTreeTierWrapper(), nameof(TechTreeTier));
				techTreeWrapper.Tiers = tiers.ToArray();
			}

			if (Upgrades != null)
			{
				var upgrades = techTreeWrapper.Upgrades?.Select(x => new TechUpgradeWrapper(x)).ToList() ?? new List<TechUpgradeWrapper>();
				loader.ApplyListPatch(Upgrades, upgrades, () => new TechUpgradeWrapper(), nameof(TechUpgrade));
				techTreeWrapper.Upgrades = upgrades.ToArray();
			}

			loader.ApplyPropertyPatch(TechTreeName, () => techTreeWrapper.TechTreeName);
			loader.ApplyPropertyPatch(IconSpriteName, () => techTreeWrapper.IconSpriteName);
		}

		public Dictionary<string, TechTreeTierPatch> Tiers { get; set; } = new Dictionary<string, TechTreeTierPatch>();
		public Dictionary<string, TechUpgradePatch> Upgrades { get; set; } = new Dictionary<string, TechUpgradePatch>();
		public string TechTreeName { get; set; }
		public string IconSpriteName { get; set; }
	}
}
