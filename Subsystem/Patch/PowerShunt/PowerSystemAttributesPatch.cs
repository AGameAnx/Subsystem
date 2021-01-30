using Subsystem.Wrappers;
using BBI.Game.Data;
using System.Collections.Generic;
using System.Linq;

namespace Subsystem.Patch
{
	public class PowerSystemAttributesPatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapperObj)
		{
			if (!(wrapperObj is PowerSystemAttributesWrapper wrapper))
				throw new System.InvalidCastException();
			
			loader.ApplyPropertyPatch(PowerSystemType, () => wrapper.PowerSystemType);
			loader.ApplyPropertyPatch(StartingPowerLevelIndex, () => wrapper.StartingPowerLevelIndex);
			loader.ApplyPropertyPatch(StartingMaxPowerLevelIndex, () => wrapper.StartingMaxPowerLevelIndex);

			{
				var l = wrapper.PowerLevels?.Select(x => new PowerLevelAttributesWrapper(x)).ToList() ?? new List<PowerLevelAttributesWrapper>();
				loader.ApplyListPatch(PowerLevels, l, () => new PowerLevelAttributesWrapper(), "PowerLevels");
				wrapper.PowerLevels = l.ToArray();
			}

			if (View != null)
			{
				PowerSystemViewAttributesWrapper powerSystemViewAttributesWrapper = new PowerSystemViewAttributesWrapper(wrapper.View);
				View.Apply(loader, powerSystemViewAttributesWrapper, null);
				wrapper.View = powerSystemViewAttributesWrapper;
			}
		}

		public PowerSystemType? PowerSystemType { get; set; }
		public int? StartingPowerLevelIndex { get; set; }
		public int? StartingMaxPowerLevelIndex { get; set; }
		public Dictionary<string, PowerLevelAttributesPatch> PowerLevels { get; set; } = new Dictionary<string, PowerLevelAttributesPatch>();
		public PowerSystemViewAttributesPatch View { get; set; }
	}
}
