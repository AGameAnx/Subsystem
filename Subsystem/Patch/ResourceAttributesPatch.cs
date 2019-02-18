using Subsystem.Wrappers;
using BBI.Game.Data;

namespace Subsystem.Patch
{
	public class ResourceAttributesPatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapper)
		{
			if (!(wrapper is ResourceAttributesWrapper resourceAttributesWrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(ResourceType, () => resourceAttributesWrapper.ResourceType);
			loader.ApplyPropertyPatch(StartingAmount, () => resourceAttributesWrapper.StartingAmount);
			loader.ApplyPropertyPatch(MaxHarvesters, () => resourceAttributesWrapper.MaxHarvesters);
		}

		public ResourceType? ResourceType { get; set; }
		public int? StartingAmount { get; set; }
		public int? MaxHarvesters { get; set; }
	}
}
