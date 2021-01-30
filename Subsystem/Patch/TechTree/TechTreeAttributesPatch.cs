using Subsystem.Wrappers;
using BBI.Game.Data;
using System.Collections.Generic;
using System.Linq;

namespace Subsystem.Patch
{
	public class TechTreeAttributesPatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapperObj)
		{
			if (!(wrapperObj is TechTreeAttributesWrapper wrapper))
				throw new System.InvalidCastException();

			if (TechTrees != null)
			{
				var l = wrapper.TechTrees?.Select(x => new TechTreeWrapper(x)).ToList() ?? new List<TechTreeWrapper>();
				loader.ApplyListPatch(TechTrees, l, () => new TechTreeWrapper(), nameof(TechTree));
				wrapper.TechTrees = l.ToArray();
			}
		}

		public Dictionary<string, TechTreePatch> TechTrees { get; set; } = new Dictionary<string, TechTreePatch>();
	}
}
