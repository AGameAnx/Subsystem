using BBI.Core;
using BBI.Game.Data;

namespace Subsystem.Wrappers
{
	public class RelicAttributesWrapper : NamedObjectBase, RelicAttributes
	{
		public RelicAttributesWrapper(RelicAttributes other) : base(other.Name)
		{
			CollectibleType = other.CollectibleType;
			BuffsWhileHolding = other.BuffsWhileHolding;
			CommandsToRunAfterExtraction = other.CommandsToRunAfterExtraction;
			DetonationWeaponTypeID = other.DetonationWeaponTypeID;
		}

		public CollectibleType CollectibleType { get; set; }
		public AttributeBuffSet BuffsWhileHolding { get; set; }
		public CommandAttributesBase[] CommandsToRunAfterExtraction { get; set; }
		public string DetonationWeaponTypeID { get; set; }
	}
}
