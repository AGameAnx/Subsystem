using Subsystem.Wrappers;
using BBI.Core.Utility.FixedPoint;
using BBI.Game.Data;
using System.Linq;

namespace Subsystem.Patch
{
	public class UnitAttributesPatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapperObj)
		{
			if (!(wrapperObj is UnitAttributesWrapper wrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(Class, () => wrapper.Class);
			loader.ApplyPropertyPatch(SelectionFlags, () => wrapper.SelectionFlags);
			loader.ApplyPropertyPatch(MaxHealth, () => wrapper.MaxHealth);
			loader.ApplyPropertyPatch(Armour, () => wrapper.Armour);
			loader.ApplyPropertyPatch(DamageReceivedMultiplier, () => wrapper.DamageReceivedMultiplier, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(AccuracyReceivedMultiplier, () => wrapper.AccuracyReceivedMultiplier, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(PopCapCost, () => wrapper.PopCapCost);
			loader.ApplyPropertyPatch(ExperienceValue, () => wrapper.ExperienceValue);
			loader.ApplyPropertyPatch(ProductionTime, () => wrapper.ProductionTime, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(AggroRange, () => wrapper.AggroRange, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(LeashRange, () => wrapper.LeashRange, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(AlertRange, () => wrapper.AlertRange, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(RepairPickupRange, () => wrapper.RepairPickupRange, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(UnitPositionReaggroConditions, () => wrapper.UnitPositionReaggroConditions);
			loader.ApplyPropertyPatch(LeashPositionReaggroConditions, () => wrapper.LeashPositionReaggroConditions);
			loader.ApplyPropertyPatch(LeadPriority, () => wrapper.LeadPriority);
			loader.ApplyPropertyPatch(Selectable, () => wrapper.Selectable);
			loader.ApplyPropertyPatch(Controllable, () => wrapper.Controllable);
			loader.ApplyPropertyPatch(Targetable, () => wrapper.Targetable);
			loader.ApplyPropertyPatch(NonAutoTargetable, () => wrapper.NonAutoTargetable);
			loader.ApplyPropertyPatch(RetireTargetable, () => wrapper.RetireTargetable);
			loader.ApplyPropertyPatch(HackedReturnTargetable, () => wrapper.HackedReturnTargetable);
			loader.ApplyPropertyPatch(HackableProperties, () => wrapper.HackableProperties);
			loader.ApplyPropertyPatch(ExcludeFromUnitStats, () => wrapper.ExcludeFromUnitStats);
			loader.ApplyPropertyPatch(BlocksLOF, () => wrapper.BlocksLOF);
			loader.ApplyPropertyPatch(WorldHeightOffset, () => wrapper.WorldHeightOffset, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(DoNotPersist, () => wrapper.DoNotPersist);
			loader.ApplyPropertyPatch(LevelBound, () => wrapper.LevelBound);
			loader.ApplyPropertyPatch(StartsInHangar, () => wrapper.StartsInHangar);
			loader.ApplyPropertyPatch(SensorRadius, () => wrapper.SensorRadius, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(ContactRadius, () => wrapper.ContactRadius, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(NumProductionQueues, () => wrapper.NumProductionQueues);
			loader.ApplyPropertyPatch(ProductionQueueDepth, () => wrapper.ProductionQueueDepth);
			loader.ApplyPropertyPatch(ShowProductionQueues, () => wrapper.ShowProductionQueues);
			loader.ApplyPropertyPatch(NoTextNotifications, () => wrapper.NoTextNotifications);
			loader.ApplyPropertyPatch(NotificationFlags, () => wrapper.NotificationFlags);
			loader.ApplyPropertyPatch(FireRateDisplay, () => wrapper.FireRateDisplay);
			loader.ApplyPropertyPatch(PriorityAsTarget, () => wrapper.PriorityAsTarget, x => Fixed64.UnsafeFromDouble(x));

			loader.ApplyPropertyPatch(BaseThreat, () => wrapper.ThreatData.BaseThreat);
			loader.ApplyPropertyPatch(ThreatTier, () => wrapper.ThreatData.Tier);

			loader.ApplyPropertyPatch(ThreatCounters, () => wrapper.ThreatCounters, c => c.Select(x => new ThreatCounter(x)));
			loader.ApplyPropertyPatch(ThreatCounteredBys, () => wrapper.ThreatCounteredBys, c => c.Select(x => new ThreatCounter(x)));

			loader.ApplyPropertyPatch(Resource1Cost, () => wrapper.Resource1Cost);
			loader.ApplyPropertyPatch(Resource2Cost, () => wrapper.Resource2Cost);
		}

		public UnitClass? Class { get; set; }
		public UnitSelectionFlags? SelectionFlags { get; set; }

		public int? MaxHealth { get; set; }
		public int? Armour { get; set; }

		public double? DamageReceivedMultiplier { get; set; }
		public double? AccuracyReceivedMultiplier { get; set; }
		public int? PopCapCost { get; set; }
		public int? ExperienceValue { get; set; }
		public double? ProductionTime { get; set; }
		public double? AggroRange { get; set; }
		public double? LeashRange { get; set; }
		public double? AlertRange { get; set; }
		public double? RepairPickupRange { get; set; }

		public UnitPositionReaggroConditions? UnitPositionReaggroConditions { get; set; }
		public LeashPositionReaggroConditions? LeashPositionReaggroConditions { get; set; }

		public int? LeadPriority { get; set; }
		public bool? Selectable { get; set; }
		public bool? Controllable { get; set; }
		public bool? Targetable { get; set; }
		public bool? NonAutoTargetable { get; set; }
		public bool? RetireTargetable { get; set; }
		public bool? HackedReturnTargetable { get; set; }

		public HackableProperties? HackableProperties { get; set; }

		public bool? ExcludeFromUnitStats { get; set; }
		public bool? BlocksLOF { get; set; }
		public double? WorldHeightOffset { get; set; }
		public bool? DoNotPersist { get; set; }
		public bool? LevelBound { get; set; }
		public bool? StartsInHangar { get; set; }
		public double? SensorRadius { get; set; }
		public double? ContactRadius { get; set; }
		public int? NumProductionQueues { get; set; }
		public int? ProductionQueueDepth { get; set; }
		public bool? ShowProductionQueues { get; set; }
		public bool? NoTextNotifications { get; set; }

		public UnitNotificationFlags? NotificationFlags { get; set; }

		public int? FireRateDisplay { get; set; }

		public double? PriorityAsTarget { get; set; }

		public int? BaseThreat { get; set; }
		public int? ThreatTier { get; set; }

		public string[] ThreatCounters { get; set; }
		public string[] ThreatCounteredBys { get; set; }

		public int? Resource1Cost { get; set; }
		public int? Resource2Cost { get; set; }
	}
}
