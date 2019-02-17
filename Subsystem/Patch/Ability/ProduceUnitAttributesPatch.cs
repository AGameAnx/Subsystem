using Subsystem.Wrappers;

namespace Subsystem.Patch
{
	public class UseWeaponAttributesPatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapper)
		{
			if (!(wrapper is UseWeaponAttributesWrapper useWeaponAttributesWrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(WeaponID, () => useWeaponAttributesWrapper.WeaponID);
			loader.ApplyPropertyPatch(ClearGoalsOnUse, () => useWeaponAttributesWrapper.ClearGoalsOnUse);
		}

		public string WeaponID { get; set; }
		public bool? ClearGoalsOnUse { get; set; }
	}
}
