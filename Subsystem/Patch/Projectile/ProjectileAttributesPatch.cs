using Subsystem.Wrappers;
using BBI.Core.Utility.FixedPoint;
using BBI.Game.Data;
using System.Collections.Generic;
using System.Linq;

namespace Subsystem.Patch
{
	public class ProjectileAttributesPatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapperObj)
		{
			if (!(wrapperObj is ProjectileAttributesWrapper wrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(ProjectileType, () => wrapper.ProjectileType);
			loader.ApplyPropertyPatch(DetonationDelay, () => wrapper.DetonationDelay, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(MissStageIndex, () => wrapper.MissStageIndex);
			loader.ApplyPropertyPatch(MinimumMissDistance, () => wrapper.MinimumMissDistance, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(MaximumMissDistance, () => wrapper.MaximumMissDistance, x => Fixed64.UnsafeFromDouble(x));

			if (Stages.Count > 0)
			{
				var l = wrapper.Stages?.Select(x => new ProjectileMotionStageWrapper(x)).ToList() ?? new List<ProjectileMotionStageWrapper>();
				loader.ApplyListPatch(Stages, l, () => new ProjectileMotionStageWrapper(), nameof(ProjectileMotionStage));
				wrapper.Stages = l.ToArray();
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
