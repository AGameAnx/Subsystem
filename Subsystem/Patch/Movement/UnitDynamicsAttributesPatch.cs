using Subsystem.Wrappers;
using BBI.Core.Utility.FixedPoint;
using BBI.Game.Data;

namespace Subsystem.Patch
{
	public class UnitDynamicsAttributesPatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapper)
		{
			if (!(wrapper is UnitDynamicsAttributesWrapper unitDynamicsAttributesWrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(DriveType, () => unitDynamicsAttributesWrapper.DriveType);
			loader.ApplyPropertyPatch(Length, () => unitDynamicsAttributesWrapper.Length, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(Width, () => unitDynamicsAttributesWrapper.Width, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(MaxSpeed, () => unitDynamicsAttributesWrapper.MaxSpeed, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(ReverseFactor, () => unitDynamicsAttributesWrapper.ReverseFactor, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(AccelerationTime, () => unitDynamicsAttributesWrapper.AccelerationTime, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(BrakingTime, () => unitDynamicsAttributesWrapper.BrakingTime, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(MaxSpeedTurnRadius, () => unitDynamicsAttributesWrapper.MaxSpeedTurnRadius, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(MaxEaseIntoTurnTime, () => unitDynamicsAttributesWrapper.MaxEaseIntoTurnTime, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(DriftType, () => unitDynamicsAttributesWrapper.DriftType, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(ReverseDriftMultiplier, () => unitDynamicsAttributesWrapper.ReverseDriftMultiplier, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(DriftOvershootFactor, () => unitDynamicsAttributesWrapper.DriftOvershootFactor, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(FishTailingTimeIntervals, () => unitDynamicsAttributesWrapper.FishTailingTimeIntervals, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(FishTailControlRecover, () => unitDynamicsAttributesWrapper.FishTailControlRecover, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(MinDriftSlipSpeed, () => unitDynamicsAttributesWrapper.MinDriftSlipSpeed, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(MaxDriftRecoverTime, () => unitDynamicsAttributesWrapper.MaxDriftRecoverTime, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(MinCruiseSpeed, () => unitDynamicsAttributesWrapper.MinCruiseSpeed, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(DeathDriftTime, () => unitDynamicsAttributesWrapper.DeathDriftTime, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(PermanentlyImmobile, () => unitDynamicsAttributesWrapper.PermanentlyImmobile);
		}

		public UnitDriveType? DriveType { get; set; }
		public double? Length { get; set; }
		public double? Width { get; set; }
		public double? MaxSpeed { get; set; }
		public double? ReverseFactor { get; set; }
		public double? AccelerationTime { get; set; }
		public double? BrakingTime { get; set; }
		public double? MaxSpeedTurnRadius { get; set; }
		public double? MaxEaseIntoTurnTime { get; set; }
		public double? DriftType { get; set; }
		public double? ReverseDriftMultiplier { get; set; }
		public double? DriftOvershootFactor { get; set; }
		public double? FishTailingTimeIntervals { get; set; }
		public double? FishTailControlRecover { get; set; }
		public double? MinDriftSlipSpeed { get; set; }
		public double? MaxDriftRecoverTime { get; set; }
		public double? MinCruiseSpeed { get; set; }
		public double? DeathDriftTime { get; set; }
		public bool? PermanentlyImmobile { get; set; }
	}
}
