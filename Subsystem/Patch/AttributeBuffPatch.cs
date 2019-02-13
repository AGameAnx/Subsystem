using Subsystem.Wrappers;
using BBI.Core.Data;
using BBI.Game.Data;

namespace Subsystem.Patch
{
	public class AttributeBuffPatch : SubsystemPatch, IRemovable
	{
		protected override void Apply(AttributeLoader loader, object wrapper)
		{
			if (!(wrapper is AttributeBuffWrapper attributeBuffWrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(Name, () => attributeBuffWrapper.Name);
			loader.ApplyPropertyPatch(Attribute, () => attributeBuffWrapper.AttributeID, Buff.AttributeIDFromBuffCategoryAndID);
			loader.ApplyPropertyPatch(Attribute, () => attributeBuffWrapper.Category, Buff.CategoryFromBuffCategoryAndID);
			loader.ApplyPropertyPatch(Mode, () => attributeBuffWrapper.Mode);
			loader.ApplyPropertyPatch(Value, () => attributeBuffWrapper.Value);
		}

		public string Name { get; set; }
		public Buff.CategoryAndID? Attribute { get; set; }
		public AttributeBuffMode? Mode { get; set; }
		public int? Value { get; set; }
		public bool Remove { get; set; }
	}
}
