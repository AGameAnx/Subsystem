using Subsystem.Wrappers;
using BBI.Game.Data;
using System.Collections.Generic;
using System.Linq;

namespace Subsystem.Patch
{
	public class ExperienceAttributesPatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapperObj)
		{
			if (!(wrapperObj is ExperienceAttributesWrapper wrapper))
				throw new System.InvalidCastException();

			{
				var l = wrapper.Levels?.Select(x => new ExperienceLevelAttributesWrapper(x)).ToList() ?? new List<ExperienceLevelAttributesWrapper>();
				loader.ApplyListPatch(Levels, l, () => new ExperienceLevelAttributesWrapper(), nameof(ExperienceLevelAttributes));
				wrapper.Levels = l.ToArray();
			}
		}

		public Dictionary<string, ExperienceLevelAttributesPatch> Levels { get; set; } = new Dictionary<string, ExperienceLevelAttributesPatch>();
	}
}
