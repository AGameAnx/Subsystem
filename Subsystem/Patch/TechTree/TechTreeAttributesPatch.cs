using Subsystem.Wrappers;
using BBI.Game.Data;
using System.Collections.Generic;
using System.Linq;

namespace Subsystem.Patch
{
	public class TechTreeAttributesPatch: SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapper)
		{
			if (!(wrapper is TechTreeAttributesWrapper techTreeAttributesWrapper))
				throw new System.InvalidCastException();

			if (TechTrees != null)
			{
				var techTrees = techTreeAttributesWrapper.TechTrees?.Select(x => new TechTreeWrapper(x)).ToList() ?? new List<TechTreeWrapper>();
				loader.ApplyListPatch(TechTrees, techTrees, () => new TechTreeWrapper(), nameof(TechTree));
				techTreeAttributesWrapper.TechTrees = techTrees.ToArray();
			}
		}

		public Dictionary<string, TechTreePatch> TechTrees { get; set; } = new Dictionary<string, TechTreePatch>();
	}
}
