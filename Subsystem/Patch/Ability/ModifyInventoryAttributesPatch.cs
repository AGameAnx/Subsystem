using Subsystem.Wrappers;

namespace Subsystem.Patch
{
	public class ModifyInventoryAttributesPatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapperObj)
		{
			if (!(wrapperObj is ModifyInventoryAttributesWrapper wrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(InventoryID, () => wrapper.InventoryID);
			loader.ApplyPropertyPatch(Delta, () => wrapper.Delta);
		}

		public string InventoryID { get; set; }
		public int? Delta { get; set; }
	}
}
