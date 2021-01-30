using Subsystem.Wrappers;
using BBI.Game.Data;
using System.Collections.Generic;

namespace Subsystem.Patch
{
	public class UnitTypeBuffPatch : SubsystemPatch, IRemovable
	{
		protected override void Apply(AttributeLoader loader, object wrapperObj)
		{
			if (!(wrapperObj is UnitTypeBuffWrapper wrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(UnitType, () => wrapper.UnitType);
			loader.ApplyPropertyPatch(UseAsPrefix, () => wrapper.UseAsPrefix);
			loader.ApplyPropertyPatch(UnitClass, () => wrapper.UnitClass);
			loader.ApplyPropertyPatch(ClassOperator, () => wrapper.ClassOperator);

			if (BuffSet != null)
			{
				var l = wrapper.BuffSet != null ? new AttributeBuffSetWrapper(wrapper.BuffSet) : new AttributeBuffSetWrapper();
				loader.ApplyListPatch(BuffSet, l.Buffs, () => new AttributeBuffWrapper(), nameof(AttributeBuffSet));
				wrapper.BuffSet = l;
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
