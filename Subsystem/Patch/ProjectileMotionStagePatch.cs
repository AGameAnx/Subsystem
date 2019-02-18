using Subsystem.Wrappers;
using BBI.Core.Utility.FixedPoint;
using BBI.Game.Data;

namespace Subsystem.Patch
{
	public class ProjectileMotionStagePatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapper)
		{
			if (!(wrapper is ProjectileMotionStageWrapper projectileMotionStageWrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(OutroType, () => projectileMotionStageWrapper.OutroType);
			loader.ApplyPropertyPatch(OutroValue, () => projectileMotionStageWrapper.OutroValue, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(MinSpeed, () => projectileMotionStageWrapper.MinSpeed, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(MaxSpeed, () => projectileMotionStageWrapper.MaxSpeed, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(AccelerationTime, () => projectileMotionStageWrapper.AccelerationTime, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(TurnsToTarget, () => projectileMotionStageWrapper.TurnsToTarget);
		}

		public ProjectileOutroType? OutroType { get; set; }
		public double? OutroValue { get; set; }
		public double? MinSpeed { get; set; }
		public double? MaxSpeed { get; set; }
		public double? AccelerationTime { get; set; }
		public bool? TurnsToTarget { get; set; }
	}
}
