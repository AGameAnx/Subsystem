using Subsystem.Wrappers;
using BBI.Game.Data;

namespace Subsystem.Patch
{
	public class WeaponModifierInfoPatch : SubsystemPatch, IRemovable
	{
		protected override void Apply(AttributeLoader loader, object wrapperObj)
		{
			if (!(wrapperObj is WeaponModifierInfoWrapper wrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(TargetClass, () => wrapper.TargetClass);
			loader.ApplyPropertyPatch(ClassOperator, () => wrapper.ClassOperator);
			loader.ApplyPropertyPatch(Modifier, () => wrapper.Modifier);
			loader.ApplyPropertyPatch(Amount, () => wrapper.Amount);
		}

		public UnitClass? TargetClass { get; set; }
		public FlagOperator? ClassOperator { get; set; }
		public WeaponModifierType? Modifier { get; set; }
		public int? Amount { get; set; }
		public bool Remove { get; set; }
	}
}
