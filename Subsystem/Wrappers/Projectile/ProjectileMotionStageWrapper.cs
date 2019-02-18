using BBI.Game.Data;
using BBI.Core.Utility.FixedPoint;

namespace Subsystem.Wrappers
{
	public class ProjectileMotionStageWrapper : ProjectileMotionStage
	{
		public ProjectileMotionStageWrapper()
		{
		}

		public ProjectileMotionStageWrapper(ProjectileMotionStage other)
		{
			OutroType = other.OutroType;
			OutroValue = other.OutroValue;
			MinSpeed = other.MinSpeed;
			MaxSpeed = other.MaxSpeed;
			AccelerationTime = other.AccelerationTime;
			TurnsToTarget = other.TurnsToTarget;
		}

		public ProjectileOutroType OutroType { get; set; }
		public Fixed64 OutroValue { get; set; }
		public Fixed64 MinSpeed { get; set; }
		public Fixed64 MaxSpeed { get; set; }
		public Fixed64 AccelerationTime { get; set; }
		public bool TurnsToTarget { get; set; }
	}
}
