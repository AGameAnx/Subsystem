using Subsystem.Wrappers;
using BBI.Game.Data;
using BBI.Core.Data;
using System.Collections.Generic;
using System.Linq;

namespace Subsystem.Patch
{
	public class RelicAttributesPatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapperObjj)
		{
			if (!(wrapperObjj is RelicAttributesWrapper wrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(CollectibleType, () => wrapper.CollectibleType);
			loader.ApplyPropertyPatch(DetonationWeaponTypeID, () => wrapper.DetonationWeaponTypeID);

			{
				var l = new AttributeBuffSetWrapper(wrapper.BuffsWhileHolding);
				loader.ApplyListPatch(BuffsWhileHolding, l.Buffs, () => new AttributeBuffWrapper(), nameof(AttributeBuff));
				wrapper.BuffsWhileHolding = l;
			}
		}

		public CollectibleType? CollectibleType { get; set; }
		public Dictionary<string, AttributeBuffPatch> BuffsWhileHolding { get; set; } = new Dictionary<string, AttributeBuffPatch>();
		//public CommandAttributesBase[] CommandsToRunAfterExtraction { get; set; }
		public string DetonationWeaponTypeID { get; set; }
	}
}
