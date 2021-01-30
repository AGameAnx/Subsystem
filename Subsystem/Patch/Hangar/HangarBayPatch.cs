using Subsystem.Wrappers;
using BBI.Core.Utility.FixedPoint;
using BBI.Game.Data;

namespace Subsystem.Patch
{
	public class HangarBayPatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapperObj)
		{
			if (!(wrapperObj is HangarBayWrapper wrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(EntityType, () => wrapper.EntityType);
			loader.ApplyPropertyPatch(MaxCount, () => wrapper.MaxCount);
			loader.ApplyPropertyPatch(UsesStrictClassMatching, () => wrapper.UsesStrictClassMatching);
			loader.ApplyPropertyPatch(HoldsClass, () => wrapper.HoldsClass);
			loader.ApplyPropertyPatch(SlotCount, () => wrapper.SlotCount);
			loader.ApplyPropertyPatch(UndockPresCtrlBone, () => wrapper.UndockPresCtrlBone);
			loader.ApplyPropertyPatch(UndockTotalSeconds, () => wrapper.UndockTotalSeconds, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(UndockAnimationSeconds, () => wrapper.UndockAnimationSeconds, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(UndockSlotStaggerSeconds, () => wrapper.UndockSlotStaggerSeconds, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(UndockXOffsetPos, () => wrapper.UndockXOffsetPos, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(UndockYOffsetPos, () => wrapper.UndockYOffsetPos, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(UndockSlotXSeperationOffset, () => wrapper.UndockSlotXSeperationOffset, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(DegreesOffsetUndockAngle, () => wrapper.DegreesOffsetUndockAngle, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(UndockSpeed, () => wrapper.UndockSpeed, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(DockPresCtrlBone, () => wrapper.DockPresCtrlBone);
			loader.ApplyPropertyPatch(DockBringInAnimationSeconds, () => wrapper.DockBringInAnimationSeconds, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(DockSlotStaggerSeconds, () => wrapper.DockSlotStaggerSeconds, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(MaxDamageCoolingSeconds, () => wrapper.MaxDamageCoolingSeconds, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(MaxDamageCoolingSeconds, () => wrapper.MaxDamageCoolingSeconds, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(MaxPayloadCoolingSeconds, () => wrapper.MaxPayloadCoolingSeconds, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(MinDockCoolingSeconds, () => wrapper.MinDockCoolingSeconds, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(DockReceivingXOffset, () => wrapper.DockReceivingXOffset, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(DockReceivingYOffset, () => wrapper.DockReceivingYOffset, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(DoorAnimationSeconds, () => wrapper.DoorAnimationSeconds, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(UndockLiftTime, () => wrapper.UndockLiftTime, x => Fixed64.UnsafeFromDouble(x));
		}

		public string EntityType { get; set; }
		public int? MaxCount { get; set; }
		public bool? UsesStrictClassMatching { get; set; }
		public UnitClass? HoldsClass { get; set; }
		public int? SlotCount { get; set; }
		public string UndockPresCtrlBone { get; set; }
		public double? UndockTotalSeconds { get; set; }
		public double? UndockAnimationSeconds { get; set; }
		public double? UndockSlotStaggerSeconds { get; set; }
		public double? UndockXOffsetPos { get; set; }
		public double? UndockYOffsetPos { get; set; }
		public double? UndockSlotXSeperationOffset { get; set; }
		public double? DegreesOffsetUndockAngle { get; set; }
		public double? UndockSpeed { get; set; }
		public string DockPresCtrlBone { get; set; }
		public double? DockBringInAnimationSeconds { get; set; }
		public double? DockSlotStaggerSeconds { get; set; }
		public double? MaxDamageCoolingSeconds { get; set; }
		public double? MaxPayloadCoolingSeconds { get; set; }
		public double? MinDockCoolingSeconds { get; set; }
		public double? DockReceivingXOffset { get; set; }
		public double? DockReceivingYOffset { get; set; }
		public double? DoorAnimationSeconds { get; set; }
		public double? UndockLiftTime { get; set; }
	}
}
