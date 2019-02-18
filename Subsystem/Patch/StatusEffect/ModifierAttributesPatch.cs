﻿using BBI.Game.Data;

namespace Subsystem.Patch
{
	public class ModifierAttributesPatch : SubsystemPatch, IRemovable
	{
		protected override void Apply(AttributeLoader loader, object wrapper)
		{ } // Does nothing because ModifierAttributes is a struct, see StatusEffectAttributesPatch class

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
