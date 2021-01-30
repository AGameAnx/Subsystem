using Subsystem.Wrappers;

namespace Subsystem.Patch
{
	public class TechTreeTierPatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapperObj)
		{
			if (!(wrapperObj is TechTreeTierWrapper wrapper))
				throw new System.InvalidCastException();
			
			loader.ApplyPropertyPatch(ResearchItems, () => wrapper.ResearchItems);
			loader.ApplyPropertyPatch(TierName, () => wrapper.TierName);
		}

		public string[] ResearchItems { get; set; }
		public string TierName { get; set; }
	}
}
