using Subsystem.Wrappers;
using BBI.Game.Data;
using System.Collections.Generic;
using System.Linq;

namespace Subsystem.Patch
{
	public class UnitTypeBuffPatch : SubsystemPatch, IRemovable
	{
		protected override void Apply(AttributeLoader loader, object wrapper)
		{
			if (!(wrapper is UnitTypeBuffWrapper unitTypeBuffWrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(UnitType, () => unitTypeBuffWrapper.UnitType);
			loader.ApplyPropertyPatch(UseAsPrefix, () => unitTypeBuffWrapper.UseAsPrefix);
			loader.ApplyPropertyPatch(UnitClass, () => unitTypeBuffWrapper.UnitClass);
			loader.ApplyPropertyPatch(ClassOperator, () => unitTypeBuffWrapper.ClassOperator);

			if (BuffSet != null)
			{
				var attributeBuffSetWrapper = unitTypeBuffWrapper.BuffSet != null ? new AttributeBuffSetWrapper(unitTypeBuffWrapper.BuffSet) : new AttributeBuffSetWrapper();
				loader.ApplyListPatch(BuffSet.ToDictionary(x => x.Key, x => (SubsystemPatch)x.Value), attributeBuffSetWrapper.Buffs, () => new AttributeBuffWrapper(), nameof(AttributeBuffSet));
				unitTypeBuffWrapper.BuffSet = attributeBuffSetWrapper;
			}
		}

		public string UnitType { get; set; }
		public bool? UseAsPrefix { get; set; }
		public UnitClass? UnitClass { get; set; }
		public FlagOperator? ClassOperator { get; set; }
		public Dictionary<string, AttributeBuffPatch> BuffSet { get; set; } = new Dictionary<string, AttributeBuffPatch>();

		public bool Remove { get; set; }
	}
}
