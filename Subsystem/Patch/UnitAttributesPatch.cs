using Subsystem.Wrappers;
using BBI.Core.Utility.FixedPoint;
using BBI.Game.Data;
using System.Linq;

namespace Subsystem.Patch
{
	public class UnitAttributesPatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapper)
		{
			if (!(wrapper is UnitAttributesWrapper unitAttributesWrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(Class, () => unitAttributesWrapper.Class);
			loader.ApplyPropertyPatch(SelectionFlags, () => unitAttributesWrapper.SelectionFlags);
			loader.ApplyPropertyPatch(MaxHealth, () => unitAttributesWrapper.MaxHealth);
			loader.ApplyPropertyPatch(Armour, () => unitAttributesWrapper.Armour);
			loader.ApplyPropertyPatch(DamageReceivedMultiplier, () => unitAttributesWrapper.DamageReceivedMultiplier, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(AccuracyReceivedMultiplier, () => unitAttributesWrapper.AccuracyReceivedMultiplier, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(PopCapCost, () => unitAttributesWrapper.PopCapCost);
			loader.ApplyPropertyPatch(ExperienceValue, () => unitAttributesWrapper.ExperienceValue);
			loader.ApplyPropertyPatch(ProductionTime, () => unitAttributesWrapper.ProductionTime, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(AggroRange, () => unitAttributesWrapper.AggroRange, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(LeashRange, () => unitAttributesWrapper.LeashRange, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(AlertRange, () => unitAttributesWrapper.AlertRange, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(RepairPickupRange, () => unitAttributesWrapper.RepairPickupRange, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(UnitPositionReaggroConditions, () => unitAttributesWrapper.UnitPositionReaggroConditions);
			loader.ApplyPropertyPatch(LeashPositionReaggroConditions, () => unitAttributesWrapper.LeashPositionReaggroConditions);
			loader.ApplyPropertyPatch(LeadPriority, () => unitAttributesWrapper.LeadPriority);
			loader.ApplyPropertyPatch(Selectable, () => unitAttributesWrapper.Selectable);
			loader.ApplyPropertyPatch(Controllable, () => unitAttributesWrapper.Controllable);
			loader.ApplyPropertyPatch(Targetable, () => unitAttributesWrapper.Targetable);
			loader.ApplyPropertyPatch(NonAutoTargetable, () => unitAttributesWrapper.NonAutoTargetable);
			loader.ApplyPropertyPatch(RetireTargetable, () => unitAttributesWrapper.RetireTargetable);
			loader.ApplyPropertyPatch(HackedReturnTargetable, () => unitAttributesWrapper.HackedReturnTargetable);
			loader.ApplyPropertyPatch(HackableProperties, () => unitAttributesWrapper.HackableProperties);
			loader.ApplyPropertyPatch(ExcludeFromUnitStats, () => unitAttributesWrapper.ExcludeFromUnitStats);
			loader.ApplyPropertyPatch(BlocksLOF, () => unitAttributesWrapper.BlocksLOF);
			loader.ApplyPropertyPatch(WorldHeightOffset, () => unitAttributesWrapper.WorldHeightOffset, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(DoNotPersist, () => unitAttributesWrapper.DoNotPersist);
			loader.ApplyPropertyPatch(LevelBound, () => unitAttributesWrapper.LevelBound);
			loader.ApplyPropertyPatch(StartsInHangar, () => unitAttributesWrapper.StartsInHangar);
			loader.ApplyPropertyPatch(SensorRadius, () => unitAttributesWrapper.SensorRadius, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(ContactRadius, () => unitAttributesWrapper.ContactRadius, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(NumProductionQueues, () => unitAttributesWrapper.NumProductionQueues);
			loader.ApplyPropertyPatch(ProductionQueueDepth, () => unitAttributesWrapper.ProductionQueueDepth);
			loader.ApplyPropertyPatch(ShowProductionQueues, () => unitAttributesWrapper.ShowProductionQueues);
			loader.ApplyPropertyPatch(NoTextNotifications, () => unitAttributesWrapper.NoTextNotifications);
			loader.ApplyPropertyPatch(NotificationFlags, () => unitAttributesWrapper.NotificationFlags);
			loader.ApplyPropertyPatch(FireRateDisplay, () => unitAttributesWrapper.FireRateDisplay);
			loader.ApplyPropertyPatch(PriorityAsTarget, () => unitAttributesWrapper.PriorityAsTarget, x => Fixed64.UnsafeFromDouble(x));

			loader.ApplyPropertyPatch(BaseThreat, () => unitAttributesWrapper.ThreatData.BaseThreat);
			loader.ApplyPropertyPatch(ThreatTier, () => unitAttributesWrapper.ThreatData.Tier);

			loader.ApplyPropertyPatch(ThreatCounters, () => unitAttributesWrapper.ThreatCounters, c => c.Select(x => new ThreatCounter(x)));
			loader.ApplyPropertyPatch(ThreatCounteredBys, () => unitAttributesWrapper.ThreatCounteredBys, c => c.Select(x => new ThreatCounter(x)));

			loader.ApplyPropertyPatch(Resource1Cost, () => unitAttributesWrapper.Resource1Cost);
			loader.ApplyPropertyPatch(Resource2Cost, () => unitAttributesWrapper.Resource2Cost);
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
