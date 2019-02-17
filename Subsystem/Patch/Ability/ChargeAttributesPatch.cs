using Subsystem.Wrappers;

namespace Subsystem.Patch
{
	public class ChargeAttributesPatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapper)
		{
			if (!(wrapper is ChargeAttributesWrapper chargeAttributesWrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(ChargesPerUse, () => chargeAttributesWrapper.ChargesPerUse);
			loader.ApplyPropertyPatch(InventoryID, () => chargeAttributesWrapper.InventoryID);
		}

		public int? ChargesPerUse { get; set; }
		public string InventoryID { get; set; }
	}
}
