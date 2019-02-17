using BBI.Game.Data;

namespace Subsystem.Wrappers
{
	public class RepairAttributesWrapper : RepairAttributes
	{
		public RepairAttributesWrapper(RepairAttributes other)
		{
			WeaponID = other.WeaponID;
		}

		public string WeaponID { get; set; }
	}
}
