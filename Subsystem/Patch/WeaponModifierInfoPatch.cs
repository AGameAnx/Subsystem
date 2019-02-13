using Subsystem.Wrappers;
using BBI.Game.Data;

namespace Subsystem.Patch
{
	public class WeaponModifierInfoPatch : SubsystemPatch, IRemovable
	{
		protected override void Apply(AttributeLoader loader, object wrapper)
		{
			if (!(wrapper is WeaponModifierInfoWrapper weaponModifierInfoWrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(TargetClass, () => weaponModifierInfoWrapper.TargetClass);
			loader.ApplyPropertyPatch(ClassOperator, () => weaponModifierInfoWrapper.ClassOperator);
			loader.ApplyPropertyPatch(Modifier, () => weaponModifierInfoWrapper.Modifier);
			loader.ApplyPropertyPatch(Amount, () => weaponModifierInfoWrapper.Amount);
		}

		public UnitClass? TargetClass { get; set; }
		public FlagOperator? ClassOperator { get; set; }
		public WeaponModifierType? Modifier { get; set; }
		public int? Amount { get; set; }
		public bool Remove { get; set; }
	}
}
