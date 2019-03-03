using Subsystem.Wrappers;

namespace Subsystem.Patch
{
	public class InventoryAttributesPatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapper)
		{
			if (!(wrapper is InventoryAttributesWrapper inventoryAttributesWrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(Capacity, () => inventoryAttributesWrapper.Capacity);
			loader.ApplyPropertyPatch(HasUnlimitedCapacity, () => inventoryAttributesWrapper.HasUnlimitedCapacity);
			loader.ApplyPropertyPatch(StartingAmount, () => inventoryAttributesWrapper.StartingAmount);
		}

		public bool? HasUnlimitedCapacity { get; set; }
		public int? StartingAmount { get; set; }
		public int? Capacity { get; set; }
	}
}
