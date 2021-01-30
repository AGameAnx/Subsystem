using Subsystem.Wrappers;

namespace Subsystem.Patch
{
	public class ChargeAttributesPatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapperObj)
		{
			if (!(wrapperObj is ChargeAttributesWrapper wrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(ChargesPerUse, () => wrapper.ChargesPerUse);
			loader.ApplyPropertyPatch(InventoryID, () => wrapper.InventoryID);
		}

		public int? ChargesPerUse { get; set; }
		public string InventoryID { get; set; }
	}
}
