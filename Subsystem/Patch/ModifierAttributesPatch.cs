using Subsystem.Wrappers;
using BBI.Game.Data;

namespace Subsystem.Patch
{
	public class ModifierAttributesPatch : SubsystemPatch, IRemovable
	{
		protected override void Apply(AttributeLoader loader, object wrapper)
		{
			if (!(wrapper is ModifierAttributes modifierAttributes))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(ModifierType, ref modifierAttributes.ModifierType, "ModifierType");
			loader.ApplyPropertyPatch(EnableWeapon_WeaponID, ref modifierAttributes.EnableWeaponAttributes.WeaponID, "EnableWeapon_WeaponID");
			loader.ApplyPropertyPatch(SwapFromWeaponID, ref modifierAttributes.SwapWeaponAttributes.SwapFromWeaponID, "SwapFromWeaponID");
			loader.ApplyPropertyPatch(SwapToWeaponID, ref modifierAttributes.SwapWeaponAttributes.SwapToWeaponID, "SwapToWeaponID");

			if (HealthOverTimeAttributes != null)
			{
				using (loader.logger.BeginScope("HealthOverTimeAttributes:"))
				{
					HealthOverTimeAttributes.Apply(loader, modifierAttributes.HealthOverTimeAttributes, null);
				}
			}
		}

		public ModifierType? ModifierType { get; set; }

		//public EnableWeaponAttributes EnableWeaponAttributes { get; set; }
		public string EnableWeapon_WeaponID { get; set; }

		//public SwapWeaponAttributes SwapWeaponAttributes { get; set; }
		public string SwapFromWeaponID { get; set; }
		public string SwapToWeaponID { get; set; }

		public HealthOverTimeAttributesPatch HealthOverTimeAttributes { get; set; }

		public bool Remove { get; set; }
	}
}
