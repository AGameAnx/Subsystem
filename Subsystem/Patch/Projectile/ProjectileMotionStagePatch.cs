using Subsystem.Wrappers;
using BBI.Core.Utility.FixedPoint;
using BBI.Game.Data;

namespace Subsystem.Patch
{
	public class ProjectileMotionStagePatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapperObj)
		{
			if (!(wrapperObj is ProjectileMotionStageWrapper wrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(OutroType, () => wrapper.OutroType);
			loader.ApplyPropertyPatch(OutroValue, () => wrapper.OutroValue, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(MinSpeed, () => wrapper.MinSpeed, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(MaxSpeed, () => wrapper.MaxSpeed, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(AccelerationTime, () => wrapper.AccelerationTime, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(TurnsToTarget, () => wrapper.TurnsToTarget);
		}

		public ProjectileOutroType? OutroType { get; set; }
		public double? OutroValue { get; set; }
		public double? MinSpeed { get; set; }
		public double? MaxSpeed { get; set; }
		public double? AccelerationTime { get; set; }
		public bool? TurnsToTarget { get; set; }
	}
}
