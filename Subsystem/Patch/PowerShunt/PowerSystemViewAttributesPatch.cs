using Subsystem.Wrappers;

namespace Subsystem.Patch
{
	public class PowerSystemViewAttributesPatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapper)
		{
			if (!(wrapper is PowerSystemViewAttributesWrapper powerSystemViewAttributesWrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(EnabledIconName, () => powerSystemViewAttributesWrapper.EnabledIconName);
			loader.ApplyPropertyPatch(DisabledIconName, () => powerSystemViewAttributesWrapper.DisabledIconName);
			loader.ApplyPropertyPatch(LocalizedTitleStringID, () => powerSystemViewAttributesWrapper.LocalizedTitleStringID);
			loader.ApplyPropertyPatch(LocalizedShortDescriptionStringID, () => powerSystemViewAttributesWrapper.LocalizedShortDescriptionStringID);
			loader.ApplyPropertyPatch(LocalizedLongDescriptionStringID, () => powerSystemViewAttributesWrapper.LocalizedLongDescriptionStringID);
			loader.ApplyPropertyPatch(LocalizedSystemDisabledStringID, () => powerSystemViewAttributesWrapper.LocalizedSystemDisabledStringID);
		}

		public string EnabledIconName { get; set; }
		public string DisabledIconName { get; set; }
		public string LocalizedTitleStringID { get; set; }
		public string LocalizedShortDescriptionStringID { get; set; }
		public string LocalizedLongDescriptionStringID { get; set; }
		public string LocalizedSystemDisabledStringID { get; set; }
	}
}
