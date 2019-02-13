using Subsystem.Wrappers;
using BBI.Core.Utility.FixedPoint;
using BBI.Game.Data;

namespace Subsystem.Patch
{
	public class HangarBayPatch: SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapper)
		{
			if (!(wrapper is HangarBayWrapper hangarBayWrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(EntityType, () => hangarBayWrapper.EntityType);
			loader.ApplyPropertyPatch(MaxCount, () => hangarBayWrapper.MaxCount);
			loader.ApplyPropertyPatch(UsesStrictClassMatching, () => hangarBayWrapper.UsesStrictClassMatching);
			loader.ApplyPropertyPatch(HoldsClass, () => hangarBayWrapper.HoldsClass);
			loader.ApplyPropertyPatch(SlotCount, () => hangarBayWrapper.SlotCount);
			loader.ApplyPropertyPatch(UndockPresCtrlBone, () => hangarBayWrapper.UndockPresCtrlBone);
			loader.ApplyPropertyPatch(UndockTotalSeconds, () => hangarBayWrapper.UndockTotalSeconds, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(UndockAnimationSeconds, () => hangarBayWrapper.UndockAnimationSeconds, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(UndockSlotStaggerSeconds, () => hangarBayWrapper.UndockSlotStaggerSeconds, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(UndockXOffsetPos, () => hangarBayWrapper.UndockXOffsetPos, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(UndockYOffsetPos, () => hangarBayWrapper.UndockYOffsetPos, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(UndockSlotXSeperationOffset, () => hangarBayWrapper.UndockSlotXSeperationOffset, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(DegreesOffsetUndockAngle, () => hangarBayWrapper.DegreesOffsetUndockAngle, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(UndockSpeed, () => hangarBayWrapper.UndockSpeed, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(DockPresCtrlBone, () => hangarBayWrapper.DockPresCtrlBone);
			loader.ApplyPropertyPatch(DockBringInAnimationSeconds, () => hangarBayWrapper.DockBringInAnimationSeconds, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(DockSlotStaggerSeconds, () => hangarBayWrapper.DockSlotStaggerSeconds, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(MaxDamageCoolingSeconds, () => hangarBayWrapper.MaxDamageCoolingSeconds, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(MaxDamageCoolingSeconds, () => hangarBayWrapper.MaxDamageCoolingSeconds, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(MaxPayloadCoolingSeconds, () => hangarBayWrapper.MaxPayloadCoolingSeconds, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(MinDockCoolingSeconds, () => hangarBayWrapper.MinDockCoolingSeconds, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(DockReceivingXOffset, () => hangarBayWrapper.DockReceivingXOffset, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(DockReceivingYOffset, () => hangarBayWrapper.DockReceivingYOffset, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(DoorAnimationSeconds, () => hangarBayWrapper.DoorAnimationSeconds, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(UndockLiftTime, () => hangarBayWrapper.UndockLiftTime, x => Fixed64.UnsafeFromDouble(x));
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
