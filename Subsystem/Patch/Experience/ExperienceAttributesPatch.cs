using Subsystem.Wrappers;
using BBI.Game.Data;
using System.Collections.Generic;
using System.Linq;

namespace Subsystem.Patch
{
	public class ExperienceAttributesPatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapper)
		{
			if (!(wrapper is ExperienceAttributesWrapper experienceAttributesWrapper))
				throw new System.InvalidCastException();

			var wrappers = experienceAttributesWrapper.Levels?.Select(x => new ExperienceLevelAttributesWrapper(x)).ToList() ?? new List<ExperienceLevelAttributesWrapper>();
			loader.ApplyListPatch(Levels, wrappers, () => new ExperienceLevelAttributesWrapper(), nameof(ExperienceLevelAttributes));
			experienceAttributesWrapper.Levels = wrappers.ToArray();
		}

		public Dictionary<string, ExperienceLevelAttributesPatch> Levels { get; set; } = new Dictionary<string, ExperienceLevelAttributesPatch>();
	}
}
