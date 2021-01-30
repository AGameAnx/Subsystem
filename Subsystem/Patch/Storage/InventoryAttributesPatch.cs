using Subsystem.Wrappers;

namespace Subsystem.Patch
{
	public class InventoryAttributesPatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapperObj)
		{
			if (!(wrapperObj is InventoryAttributesWrapper wrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(Capacity, () => wrapper.Capacity);
			loader.ApplyPropertyPatch(HasUnlimitedCapacity, () => wrapper.HasUnlimitedCapacity);
			loader.ApplyPropertyPatch(StartingAmount, () => wrapper.StartingAmount);
		}

		public bool? HasUnlimitedCapacity { get; set; }
		public int? StartingAmount { get; set; }
		public int? Capacity { get; set; }
	}
}
