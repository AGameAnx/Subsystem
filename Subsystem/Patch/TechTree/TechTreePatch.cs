using Subsystem.Wrappers;
using BBI.Game.Data;
using System.Collections.Generic;
using System.Linq;

namespace Subsystem.Patch
{
	public class TechTreePatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapperObj)
		{
			if (!(wrapperObj is TechTreeWrapper wrapper))
				throw new System.InvalidCastException();

			if (Tiers != null)
			{
				var l = wrapper.Tiers?.Select(x => new TechTreeTierWrapper(x)).ToList() ?? new List<TechTreeTierWrapper>();
				loader.ApplyListPatch(Tiers, l, () => new TechTreeTierWrapper(), nameof(TechTreeTier));
				wrapper.Tiers = l.ToArray();
			}

			if (Upgrades != null)
			{
				var l = wrapper.Upgrades?.Select(x => new TechUpgradeWrapper(x)).ToList() ?? new List<TechUpgradeWrapper>();
				loader.ApplyListPatch(Upgrades, l, () => new TechUpgradeWrapper(), nameof(TechUpgrade));
				wrapper.Upgrades = l.ToArray();
			}

			loader.ApplyPropertyPatch(TechTreeName, () => wrapper.TechTreeName);
			loader.ApplyPropertyPatch(IconSpriteName, () => wrapper.IconSpriteName);
		}

		public Dictionary<string, TechTreeTierPatch> Tiers { get; set; } = new Dictionary<string, TechTreeTierPatch>();
		public Dictionary<string, TechUpgradePatch> Upgrades { get; set; } = new Dictionary<string, TechUpgradePatch>();
		public string TechTreeName { get; set; }
		public string IconSpriteName { get; set; }
	}
}
