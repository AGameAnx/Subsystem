using Subsystem.Wrappers;

namespace Subsystem.Patch
{
	public class TechUpgradePatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapperObj)
		{
			if (!(wrapperObj is TechUpgradeWrapper wrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(ResearchItem, () => wrapper.ResearchItem);
			loader.ApplyPropertyPatch(UpgradeName, () => wrapper.UpgradeName);
		}

		public string ResearchItem { get; set; }
		public string UpgradeName { get; set; }
	}
}
