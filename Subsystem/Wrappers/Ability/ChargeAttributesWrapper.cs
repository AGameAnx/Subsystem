using BBI.Game.Data;

namespace Subsystem.Wrappers
{
	public class ChargeAttributesWrapper : ChargeAttributes
	{
		public ChargeAttributesWrapper(ChargeAttributes other)
		{
			InventoryID = other.InventoryID;
			ChargesPerUse = other.ChargesPerUse;
		}

		public string InventoryID { get; set; }
		public int ChargesPerUse { get; set; }
	}
}
