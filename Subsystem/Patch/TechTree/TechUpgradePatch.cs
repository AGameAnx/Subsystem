using Subsystem.Wrappers;

namespace Subsystem.Patch
{
	public class TechUpgradePatch: SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapper)
		{
			if (!(wrapper is TechUpgradeWrapper techUpgradeWrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(ResearchItem, () => techUpgradeWrapper.ResearchItem);
			loader.ApplyPropertyPatch(UpgradeName, () => techUpgradeWrapper.UpgradeName);
		}

		public string ResearchItem { get; set; }
		public string UpgradeName { get; set; }
	}
}
