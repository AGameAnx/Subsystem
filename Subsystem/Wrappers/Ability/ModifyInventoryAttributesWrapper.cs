using BBI.Game.Data;

namespace Subsystem.Wrappers
{
	public class ModifyInventoryAttributesWrapper : ModifyInventoryAttributes
	{
		public ModifyInventoryAttributesWrapper(ModifyInventoryAttributes other)
		{
			InventoryID = other.InventoryID;
			Delta = other.Delta;
		}

		public string InventoryID { get; set; }
		public int Delta { get; set; }
	}
}
