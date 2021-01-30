using Subsystem.Wrappers;

namespace Subsystem.Patch
{
	public class UseWeaponAttributesPatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapperObj)
		{
			if (!(wrapperObj is UseWeaponAttributesWrapper wrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(WeaponID, () => wrapper.WeaponID);
			loader.ApplyPropertyPatch(ClearGoalsOnUse, () => wrapper.ClearGoalsOnUse);
		}

		public string WeaponID { get; set; }
		public bool? ClearGoalsOnUse { get; set; }
	}
}
