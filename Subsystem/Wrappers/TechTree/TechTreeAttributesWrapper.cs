using BBI.Core;
using BBI.Game.Data;
using System.Linq;

namespace Subsystem.Wrappers
{
	public class TechTreeAttributesWrapper : NamedObjectBase, TechTreeAttributes
	{
		public TechTreeAttributesWrapper(TechTreeAttributes other) : base(other.Name)
		{
			TechTrees = other.TechTrees.ToArray();
		}

		public TechTree[] TechTrees { get; set; }
	}
}
