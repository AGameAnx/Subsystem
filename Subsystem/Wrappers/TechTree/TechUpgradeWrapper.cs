using BBI.Core;
using BBI.Game.Data;

namespace Subsystem.Wrappers
{
	public class TechUpgradeWrapper : TechUpgrade
	{
		public TechUpgradeWrapper()
		{
		}

		public TechUpgradeWrapper(TechUpgrade other)
		{
			ResearchItem = other.ResearchItem;
			UpgradeName = other.UpgradeName;
		}

		public string ResearchItem { get; set; }
		public string UpgradeName { get; set; }
	}
}
