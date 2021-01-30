using Subsystem.Wrappers;
using BBI.Core.Utility.FixedPoint;
using BBI.Game.Data;

namespace Subsystem.Patch
{
	public class UnitDynamicsAttributesPatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapperObj)
		{
			if (!(wrapperObj is UnitDynamicsAttributesWrapper wrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(DriveType, () => wrapper.DriveType);
			loader.ApplyPropertyPatch(Length, () => wrapper.Length, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(Width, () => wrapper.Width, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(MaxSpeed, () => wrapper.MaxSpeed, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(ReverseFactor, () => wrapper.ReverseFactor, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(AccelerationTime, () => wrapper.AccelerationTime, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(BrakingTime, () => wrapper.BrakingTime, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(MaxSpeedTurnRadius, () => wrapper.MaxSpeedTurnRadius, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(MaxEaseIntoTurnTime, () => wrapper.MaxEaseIntoTurnTime, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(DriftType, () => wrapper.DriftType, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(ReverseDriftMultiplier, () => wrapper.ReverseDriftMultiplier, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(DriftOvershootFactor, () => wrapper.DriftOvershootFactor, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(FishTailingTimeIntervals, () => wrapper.FishTailingTimeIntervals, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(FishTailControlRecover, () => wrapper.FishTailControlRecover, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(MinDriftSlipSpeed, () => wrapper.MinDriftSlipSpeed, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(MaxDriftRecoverTime, () => wrapper.MaxDriftRecoverTime, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(MinCruiseSpeed, () => wrapper.MinCruiseSpeed, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(DeathDriftTime, () => wrapper.DeathDriftTime, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(PermanentlyImmobile, () => wrapper.PermanentlyImmobile);
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
