using Subsystem.Wrappers;
using BBI.Game.Data;

namespace Subsystem.Patch
{
	public class ResourceAttributesPatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapperObj)
		{
			if (!(wrapperObj is ResourceAttributesWrapper wrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(ResourceType, () => wrapper.ResourceType);
			loader.ApplyPropertyPatch(StartingAmount, () => wrapper.StartingAmount);
			loader.ApplyPropertyPatch(MaxHarvesters, () => wrapper.MaxHarvesters);
		}

		public ResourceType? ResourceType { get; set; }
		public int? StartingAmount { get; set; }
		public int? MaxHarvesters { get; set; }
	}
}
