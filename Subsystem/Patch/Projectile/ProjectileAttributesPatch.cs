using Subsystem.Wrappers;
using BBI.Core.Utility.FixedPoint;
using BBI.Game.Data;
using System.Collections.Generic;
using System.Linq;

namespace Subsystem.Patch
{
	public class ProjectileAttributesPatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapper)
		{
			if (!(wrapper is ProjectileAttributesWrapper projectileAttributesWrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(ProjectileType, () => projectileAttributesWrapper.ProjectileType);
			loader.ApplyPropertyPatch(DetonationDelay, () => projectileAttributesWrapper.DetonationDelay, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(MissStageIndex, () => projectileAttributesWrapper.MissStageIndex);
			loader.ApplyPropertyPatch(MinimumMissDistance, () => projectileAttributesWrapper.MinimumMissDistance, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(MaximumMissDistance, () => projectileAttributesWrapper.MaximumMissDistance, x => Fixed64.UnsafeFromDouble(x));

			if (Stages.Count > 0)
			{
				var projectileMotionStageWrappers = projectileAttributesWrapper.Stages?.Select(x => new ProjectileMotionStageWrapper(x)).ToList() ?? new List<ProjectileMotionStageWrapper>();
				loader.ApplyListPatch(Stages, projectileMotionStageWrappers, () => new ProjectileMotionStageWrapper(), nameof(ProjectileMotionStage));
				projectileAttributesWrapper.Stages = projectileMotionStageWrappers.ToArray();
			}
		}

		public ProjectileType? ProjectileType { get; set; }
		public double? DetonationDelay { get; set; }
		public Dictionary<string, ProjectileMotionStagePatch> Stages { get; set; } = new Dictionary<string, ProjectileMotionStagePatch>();
		public int? MissStageIndex { get; set; }
		public double? MinimumMissDistance { get; set; }
		public double? MaximumMissDistance { get; set; }
	}
}
