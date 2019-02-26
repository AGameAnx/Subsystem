using Subsystem.Wrappers;
using BBI.Game.Data;
using BBI.Core.Data;
using System.Collections.Generic;
using System.Linq;

namespace Subsystem.Patch
{
	public class RelicAttributesPatch: SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapper)
		{
			if (!(wrapper is RelicAttributesWrapper relicAttributesWrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(CollectibleType, () => relicAttributesWrapper.CollectibleType);
			loader.ApplyPropertyPatch(DetonationWeaponTypeID, () => relicAttributesWrapper.DetonationWeaponTypeID);

			var attributeBuffSetWrapper = new AttributeBuffSetWrapper(relicAttributesWrapper.BuffsWhileHolding);
			loader.ApplyListPatch(BuffsWhileHolding, attributeBuffSetWrapper.Buffs, () => new AttributeBuffWrapper(), nameof(AttributeBuff));
			relicAttributesWrapper.BuffsWhileHolding = attributeBuffSetWrapper;
		}

		public CollectibleType? CollectibleType { get; set; }
		public Dictionary<string, AttributeBuffPatch> BuffsWhileHolding { get; set; } = new Dictionary<string, AttributeBuffPatch>();
		//public CommandAttributesBase[] CommandsToRunAfterExtraction { get; set; }
		public string DetonationWeaponTypeID { get; set; }
	}
}
