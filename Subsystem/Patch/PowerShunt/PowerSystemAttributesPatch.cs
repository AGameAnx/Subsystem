using Subsystem.Wrappers;
using BBI.Game.Data;
using System.Collections.Generic;
using System.Linq;

namespace Subsystem.Patch
{
	public class PowerSystemAttributesPatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapper)
		{
			if (!(wrapper is PowerSystemAttributesWrapper powerSystemAttributesWrapper))
				throw new System.InvalidCastException();
			
			loader.ApplyPropertyPatch(PowerSystemType, () => powerSystemAttributesWrapper.PowerSystemType);
			loader.ApplyPropertyPatch(StartingPowerLevelIndex, () => powerSystemAttributesWrapper.StartingPowerLevelIndex);
			loader.ApplyPropertyPatch(StartingMaxPowerLevelIndex, () => powerSystemAttributesWrapper.StartingMaxPowerLevelIndex);

			var powerLevels = powerSystemAttributesWrapper.PowerLevels?.Select(x => new PowerLevelAttributesWrapper(x)).ToList() ?? new List<PowerLevelAttributesWrapper>();
			loader.ApplyListPatch(PowerLevels, powerLevels, () => new PowerLevelAttributesWrapper(), "PowerLevels");
			powerSystemAttributesWrapper.PowerLevels = powerLevels.ToArray();

			if (View != null)
			{
				PowerSystemViewAttributesWrapper powerSystemViewAttributesWrapper = new PowerSystemViewAttributesWrapper(powerSystemAttributesWrapper.View);
				View.Apply(loader, powerSystemViewAttributesWrapper, null);
				powerSystemAttributesWrapper.View = powerSystemViewAttributesWrapper;
			}
		}

		public PowerSystemType? PowerSystemType { get; set; }
		public int? StartingPowerLevelIndex { get; set; }
		public int? StartingMaxPowerLevelIndex { get; set; }
		public Dictionary<string, PowerLevelAttributesPatch> PowerLevels { get; set; } = new Dictionary<string, PowerLevelAttributesPatch>();
		public PowerSystemViewAttributesPatch View { get; set; }
	}
}
