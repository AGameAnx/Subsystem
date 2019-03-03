using Subsystem.Wrappers;

namespace Subsystem.Patch
{
	public class TechTreeTierPatch: SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapper)
		{
			if (!(wrapper is TechTreeTierWrapper techTreeTierWrapper))
				throw new System.InvalidCastException();
			
			loader.ApplyPropertyPatch(ResearchItems, () => techTreeTierWrapper.ResearchItems);
			loader.ApplyPropertyPatch(TierName, () => techTreeTierWrapper.TierName);
		}

		public string[] ResearchItems { get; set; }
		public string TierName { get; set; }
	}
}
