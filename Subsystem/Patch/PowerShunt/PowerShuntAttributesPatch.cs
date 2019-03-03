using Subsystem.Wrappers;
using BBI.Core.Utility.FixedPoint;
using System.Collections.Generic;
using System.Linq;

namespace Subsystem.Patch
{
	public class PowerShuntAttributesPatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapper)
		{
			if (!(wrapper is PowerShuntAttributesWrapper powerShuntAttributesWrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(PowerLevelChargeTimeSeconds, () => powerShuntAttributesWrapper.PowerLevelChargeTimeSeconds, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(PowerLevelDrainTimeSeconds, () => powerShuntAttributesWrapper.PowerLevelDrainTimeSeconds, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(HeatThreshold, () => powerShuntAttributesWrapper.HeatThreshold);
			loader.ApplyPropertyPatch(CooldownRate, () => powerShuntAttributesWrapper.CooldownRate);
			loader.ApplyPropertyPatch(OverheatDamage, () => powerShuntAttributesWrapper.OverheatDamage);
			loader.ApplyPropertyPatch(NearOverheatWarningMargin, () => powerShuntAttributesWrapper.NearOverheatWarningMargin);
			loader.ApplyPropertyPatch(OverheatReminderPeriod, () => powerShuntAttributesWrapper.OverheatReminderPeriod);

			var powerSystems = powerShuntAttributesWrapper.PowerSystems?.Select(x => new PowerSystemAttributesWrapper(x)).ToList() ?? new List<PowerSystemAttributesWrapper>();
			loader.ApplyListPatch(PowerSystems, powerSystems, () => new PowerSystemAttributesWrapper(), "PowerSystems");
			powerShuntAttributesWrapper.PowerSystems = powerSystems.ToArray();

			if (ReservePowerPool != null)
			{
				InventoryAttributesWrapper inventoryAttributesWrapper = new InventoryAttributesWrapper(powerShuntAttributesWrapper.ReservePowerPool);
				ReservePowerPool.Apply(loader, inventoryAttributesWrapper, null);
				powerShuntAttributesWrapper.ReservePowerPool = inventoryAttributesWrapper;
			}
			if (OverheatingPool != null)
			{
				InventoryAttributesWrapper inventoryAttributesWrapper = new InventoryAttributesWrapper(powerShuntAttributesWrapper.OverheatingPool);
				OverheatingPool.Apply(loader, inventoryAttributesWrapper, null);
				powerShuntAttributesWrapper.OverheatingPool = inventoryAttributesWrapper;
			}
			if (HeatSystem != null)
			{
				InventoryAttributesWrapper inventoryAttributesWrapper = new InventoryAttributesWrapper(powerShuntAttributesWrapper.HeatSystem);
				HeatSystem.Apply(loader, inventoryAttributesWrapper, null);
				powerShuntAttributesWrapper.HeatSystem = inventoryAttributesWrapper;
			}
			if (View != null)
			{
				PowerShuntViewAttributesWrapper powerShuntViewAttributesWrapper = new PowerShuntViewAttributesWrapper(powerShuntAttributesWrapper.View);
				View.Apply(loader, powerShuntViewAttributesWrapper, null);
				powerShuntAttributesWrapper.View = powerShuntViewAttributesWrapper;
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
