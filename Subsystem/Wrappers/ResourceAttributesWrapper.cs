using BBI.Game.Data;

namespace Subsystem.Wrappers
{
	public class ResourceAttributesWrapper : ResourceAttributes
	{
		public ResourceAttributesWrapper(ResourceAttributes other)
		{
			ResourceType = other.ResourceType;
			StartingAmount = other.StartingAmount;
			MaxHarvesters = other.MaxHarvesters;
		}

		public ResourceType ResourceType { get; set; }
		public int StartingAmount { get; set; }
		public int MaxHarvesters { get; set; }
	}
}
