using Subsystem.Wrappers;

namespace Subsystem.Patch
{
	public class ModifyInventoryAttributesPatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapper)
		{
			if (!(wrapper is ModifyInventoryAttributesWrapper modifyInventoryAttributesWrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(InventoryID, () => modifyInventoryAttributesWrapper.InventoryID);
			loader.ApplyPropertyPatch(Delta, () => modifyInventoryAttributesWrapper.Delta);
		}

		public string InventoryID { get; set; }
		public int? Delta { get; set; }
	}
}
