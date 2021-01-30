using Subsystem.Wrappers;
using BBI.Core.Utility.FixedPoint;
using System.Collections.Generic;
using System.Linq;

namespace Subsystem.Patch
{
	public class PowerShuntAttributesPatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapperObj)
		{
			if (!(wrapperObj is PowerShuntAttributesWrapper wrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(PowerLevelChargeTimeSeconds, () => wrapper.PowerLevelChargeTimeSeconds, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(PowerLevelDrainTimeSeconds, () => wrapper.PowerLevelDrainTimeSeconds, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(HeatThreshold, () => wrapper.HeatThreshold);
			loader.ApplyPropertyPatch(CooldownRate, () => wrapper.CooldownRate);
			loader.ApplyPropertyPatch(OverheatDamage, () => wrapper.OverheatDamage);
			loader.ApplyPropertyPatch(NearOverheatWarningMargin, () => wrapper.NearOverheatWarningMargin);
			loader.ApplyPropertyPatch(OverheatReminderPeriod, () => wrapper.OverheatReminderPeriod);

			{
				var l = wrapper.PowerSystems?.Select(x => new PowerSystemAttributesWrapper(x)).ToList() ?? new List<PowerSystemAttributesWrapper>();
				loader.ApplyListPatch(PowerSystems, l, () => new PowerSystemAttributesWrapper(), "PowerSystems");
				wrapper.PowerSystems = l.ToArray();
			}

			if (ReservePowerPool != null)
			{
				InventoryAttributesWrapper inventoryAttributesWrapper = new InventoryAttributesWrapper(wrapper.ReservePowerPool);
				ReservePowerPool.Apply(loader, inventoryAttributesWrapper, null);
				wrapper.ReservePowerPool = inventoryAttributesWrapper;
			}
			if (OverheatingPool != null)
			{
				InventoryAttributesWrapper inventoryAttributesWrapper = new InventoryAttributesWrapper(wrapper.OverheatingPool);
				OverheatingPool.Apply(loader, inventoryAttributesWrapper, null);
				wrapper.OverheatingPool = inventoryAttributesWrapper;
			}
			if (HeatSystem != null)
			{
				InventoryAttributesWrapper inventoryAttributesWrapper = new InventoryAttributesWrapper(wrapper.HeatSystem);
				HeatSystem.Apply(loader, inventoryAttributesWrapper, null);
				wrapper.HeatSystem = inventoryAttributesWrapper;
			}
			if (View != null)
			{
				PowerShuntViewAttributesWrapper powerShuntViewAttributesWrapper = new PowerShuntViewAttributesWrapper(wrapper.View);
				View.Apply(loader, powerShuntViewAttributesWrapper, null);
				wrapper.View = powerShuntViewAttributesWrapper;
			}
		}

		public double? PowerLevelChargeTimeSeconds { get; set; }
		public double? PowerLevelDrainTimeSeconds { get; set; }
		public int? HeatThreshold { get; set; }
		public int? CooldownRate { get; set; }
		public int? OverheatDamage { get; set; }
		public int? NearOverheatWarningMargin { get; set; }
		public int? OverheatReminderPeriod { get; set; }
		public Dictionary<string, PowerSystemAttributesPatch> PowerSystems { get; set; } = new Dictionary<string, PowerSystemAttributesPatch>();
		public InventoryAttributesPatch ReservePowerPool { get; set; }
		public InventoryAttributesPatch OverheatingPool { get; set; }
		public InventoryAttributesPatch HeatSystem { get; set; }
		public PowerShuntViewAttributesPatch View { get; set; }
	}
}
