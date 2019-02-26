using BBI.Game.Data;
using System.Linq;

namespace Subsystem.Wrappers
{
	public class PowerSystemAttributesWrapper : PowerSystemAttributes
	{
		public PowerSystemAttributesWrapper()
		{
		}

		public PowerSystemAttributesWrapper(PowerSystemAttributes other)
		{
			PowerSystemType = other.PowerSystemType;
			StartingPowerLevelIndex = other.StartingPowerLevelIndex;
			StartingMaxPowerLevelIndex = other.StartingMaxPowerLevelIndex;
			PowerLevels = other.PowerLevels?.ToArray();
			View = other.View;
		}

		public PowerSystemType PowerSystemType { get; set; }
		public int StartingPowerLevelIndex { get; set; }
		public int StartingMaxPowerLevelIndex { get; set; }
		public PowerLevelAttributes[] PowerLevels { get; set; }
		public PowerSystemViewAttributes View { get; set; }
	}
}
