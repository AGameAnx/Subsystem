
using BBI.Core;
using BBI.Game.Data;
using BBI.Core.Utility.FixedPoint;
using System.Linq;

namespace Subsystem.Wrappers
{
	public class ProjectileAttributesWrapper : NamedObjectBase, ProjectileAttributes
	{
		public ProjectileAttributesWrapper(ProjectileAttributes other) : base(other.Name)
		{
			ProjectileType = other.ProjectileType;
			DetonationDelay = other.DetonationDelay;
			Stages = other.Stages.ToArray();
			MissStageIndex = other.MissStageIndex;
			MinimumMissDistance = other.MinimumMissDistance;
			MaximumMissDistance = other.MaximumMissDistance;
		}

		public ProjectileType ProjectileType { get; set; }
		public Fixed64 DetonationDelay { get; set; }
		public ProjectileMotionStage[] Stages { get; set; }
		public int MissStageIndex { get; set; }
		public Fixed64 MinimumMissDistance { get; set; }
		public Fixed64 MaximumMissDistance { get; set; }
	}
}
