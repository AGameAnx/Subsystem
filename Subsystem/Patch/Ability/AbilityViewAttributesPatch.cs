using BBI.Unity.Game.Data;
using UnityEngine;

namespace Subsystem.Patch
{
	public class AbilityViewAttributesPatch: SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapper)
		{
			if (!(wrapper is AbilityViewAttributes abilityViewAttributesWrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(LocalizedTitleStringID, ref abilityViewAttributesWrapper.LocalizedTitleStringID, "LocalizedTitleStringID");
			loader.ApplyPropertyPatch(LocalizedShortDescriptionStringID, ref abilityViewAttributesWrapper.LocalizedShortDescriptionStringID, "LocalizedShortDescriptionStringID");
			loader.ApplyPropertyPatch(LocalizedLongDescriptionStringID, ref abilityViewAttributesWrapper.LocalizedLongDescriptionStringID, "LocalizedLongDescriptionStringID");
			loader.ApplyPropertyPatch(LocalizedToggledTitleStringID, ref abilityViewAttributesWrapper.LocalizedToggledTitleStringID, "LocalizedToggledTitleStringID");
			loader.ApplyPropertyPatch(LocalizedToggledShortDescriptionStringID, ref abilityViewAttributesWrapper.LocalizedToggledShortDescriptionStringID, "LocalizedToggledShortDescriptionStringID");
			loader.ApplyPropertyPatch(LocalizedToggledLongDescriptionStringID, ref abilityViewAttributesWrapper.LocalizedToggledLongDescriptionStringID, "LocalizedToggledLongDescriptionStringID");

			loader.ApplyPropertyPatch(IconName, ref abilityViewAttributesWrapper.IconName, "IconName");
			loader.ApplyPropertyPatch(ToggledIconName, ref abilityViewAttributesWrapper.ToggledIconName, "ToggledIconName");

			loader.ApplyPropertyPatch(Hotkey, ref abilityViewAttributesWrapper.Hotkey, "Hotkey");
			loader.ApplyPropertyPatch(ToggledHotkey, ref abilityViewAttributesWrapper.ToggledHotkey, "ToggledHotkey");

			loader.ApplyPropertyPatch(BindingIsExclusive, ref abilityViewAttributesWrapper.BindingIsExclusive, "BindingIsExclusive");
			loader.ApplyPropertyPatch(AutocastHotkeyModifier, ref abilityViewAttributesWrapper.AutocastHotkeyModifier, "AutocastHotkeyModifier");
			loader.ApplyPropertyPatch(DrawPreviewRouteLine, ref abilityViewAttributesWrapper.DrawPreviewRouteLine, "DrawPreviewRouteLine");
			loader.ApplyPropertyPatch(ForceHideAutocastSprite, ref abilityViewAttributesWrapper.ForceHideAutocastSprite, "ForceHideAutocastSprite");
			loader.ApplyPropertyPatch(ForcePassiveVisuals, ref abilityViewAttributesWrapper.ForcePassiveVisuals, "ForcePassiveVisuals");
			loader.ApplyPropertyPatch(WillToggleDialIndicator, ref abilityViewAttributesWrapper.WillToggleDialIndicator, "WillToggleDialIndicator");
			loader.ApplyPropertyPatch(InventoryID, ref abilityViewAttributesWrapper.InventoryID, "InventoryID");
			loader.ApplyPropertyPatch(InvertFillCooldown, ref abilityViewAttributesWrapper.InvertFillCooldown, "InvertFillCooldown");
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
