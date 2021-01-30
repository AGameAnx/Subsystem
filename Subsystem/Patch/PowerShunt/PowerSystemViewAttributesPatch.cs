using Subsystem.Wrappers;

namespace Subsystem.Patch
{
	public class PowerSystemViewAttributesPatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapperObj)
		{
			if (!(wrapperObj is PowerSystemViewAttributesWrapper wrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(EnabledIconName, () => wrapper.EnabledIconName);
			loader.ApplyPropertyPatch(DisabledIconName, () => wrapper.DisabledIconName);
			loader.ApplyPropertyPatch(LocalizedTitleStringID, () => wrapper.LocalizedTitleStringID);
			loader.ApplyPropertyPatch(LocalizedShortDescriptionStringID, () => wrapper.LocalizedShortDescriptionStringID);
			loader.ApplyPropertyPatch(LocalizedLongDescriptionStringID, () => wrapper.LocalizedLongDescriptionStringID);
			loader.ApplyPropertyPatch(LocalizedSystemDisabledStringID, () => wrapper.LocalizedSystemDisabledStringID);
		}

		public string EnabledIconName { get; set; }
		public string DisabledIconName { get; set; }
		public string LocalizedTitleStringID { get; set; }
		public string LocalizedShortDescriptionStringID { get; set; }
		public string LocalizedLongDescriptionStringID { get; set; }
		public string LocalizedSystemDisabledStringID { get; set; }
	}
}
