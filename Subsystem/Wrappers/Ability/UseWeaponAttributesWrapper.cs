using BBI.Game.Data;

namespace Subsystem.Wrappers
{
	public class UseWeaponAttributesWrapper : UseWeaponAttributes
	{
		public UseWeaponAttributesWrapper(UseWeaponAttributes other)
		{
			WeaponID = other.WeaponID;
			ClearGoalsOnUse = other.ClearGoalsOnUse;
		}

		public string WeaponID { get; set; }
		public bool ClearGoalsOnUse { get; set; }
	}
}
