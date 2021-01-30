using BBI.Unity.Game.Data;
using UnityEngine;

namespace Subsystem.Patch
{
	public class AbilityViewAttributesPatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapperObj)
		{
			if (!(wrapperObj is AbilityViewAttributes wrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(LocalizedTitleStringID, ref wrapper.LocalizedTitleStringID, "LocalizedTitleStringID");
			loader.ApplyPropertyPatch(LocalizedShortDescriptionStringID, ref wrapper.LocalizedShortDescriptionStringID, "LocalizedShortDescriptionStringID");
			loader.ApplyPropertyPatch(LocalizedLongDescriptionStringID, ref wrapper.LocalizedLongDescriptionStringID, "LocalizedLongDescriptionStringID");
			loader.ApplyPropertyPatch(LocalizedToggledTitleStringID, ref wrapper.LocalizedToggledTitleStringID, "LocalizedToggledTitleStringID");
			loader.ApplyPropertyPatch(LocalizedToggledShortDescriptionStringID, ref wrapper.LocalizedToggledShortDescriptionStringID, "LocalizedToggledShortDescriptionStringID");
			loader.ApplyPropertyPatch(LocalizedToggledLongDescriptionStringID, ref wrapper.LocalizedToggledLongDescriptionStringID, "LocalizedToggledLongDescriptionStringID");

			loader.ApplyPropertyPatch(IconName, ref wrapper.IconName, "IconName");
			loader.ApplyPropertyPatch(ToggledIconName, ref wrapper.ToggledIconName, "ToggledIconName");

			loader.ApplyPropertyPatch(Hotkey, ref wrapper.Hotkey, "Hotkey");
			loader.ApplyPropertyPatch(ToggledHotkey, ref wrapper.ToggledHotkey, "ToggledHotkey");

			loader.ApplyPropertyPatch(BindingIsExclusive, ref wrapper.BindingIsExclusive, "BindingIsExclusive");
			loader.ApplyPropertyPatch(AutocastHotkeyModifier, ref wrapper.AutocastHotkeyModifier, "AutocastHotkeyModifier");
			loader.ApplyPropertyPatch(DrawPreviewRouteLine, ref wrapper.DrawPreviewRouteLine, "DrawPreviewRouteLine");
			loader.ApplyPropertyPatch(ForceHideAutocastSprite, ref wrapper.ForceHideAutocastSprite, "ForceHideAutocastSprite");
			loader.ApplyPropertyPatch(ForcePassiveVisuals, ref wrapper.ForcePassiveVisuals, "ForcePassiveVisuals");
			loader.ApplyPropertyPatch(WillToggleDialIndicator, ref wrapper.WillToggleDialIndicator, "WillToggleDialIndicator");
			loader.ApplyPropertyPatch(InventoryID, ref wrapper.InventoryID, "InventoryID");
			loader.ApplyPropertyPatch(InvertFillCooldown, ref wrapper.InvertFillCooldown, "InvertFillCooldown");
		}

		public string LocalizedTitleStringID;
		public string LocalizedShortDescriptionStringID;
		public string LocalizedLongDescriptionStringID;
		public string LocalizedToggledTitleStringID;
		public string LocalizedToggledShortDescriptionStringID;
		public string LocalizedToggledLongDescriptionStringID;
		
		public string IconName;
		public string ToggledIconName;

		//public Texture2D CursorIcon;

		public KeyCode? Hotkey;
		public KeyCode? ToggledHotkey;

		// Unit Test: Declare hotkey binding as exclusive (no duplicates)
		public bool? BindingIsExclusive;

		public EventModifiers? AutocastHotkeyModifier;

		//public TooltipObjectAsset Tooltip;

		// Whether the ability will draw a render line during route preview. Note that attack-class abilities will still use LoF rendering if necessary
		public bool? DrawPreviewRouteLine;

		// If true, hides the autocast sprite if the ability has autocast enabled
		public bool? ForceHideAutocastSprite;

		// If true, the ability button will appear as a passive even if it's not a passive ability
		public bool? ForcePassiveVisuals;

		public bool? WillToggleDialIndicator;

		// If non-empty, the ability button show the current amount of the inventory corresponding the InventoryID on the unit
		public string InventoryID;

		// If true, the ability button cooldown sprite will fill in the opposite direction
		public bool? InvertFillCooldown;

		//public TargetingReticleAttributes TargetingReticle;
		//public AbilityVOFeedback VOFeedback;
	}
}
