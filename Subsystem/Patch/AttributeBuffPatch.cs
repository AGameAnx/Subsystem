using Subsystem.Wrappers;
using BBI.Core.Data;
using BBI.Game.Data;

namespace Subsystem.Patch
{
	public class AttributeBuffPatch : SubsystemPatch, IRemovable
	{
		protected override void Apply(AttributeLoader loader, object wrapperObj)
		{
			if (!(wrapperObj is AttributeBuffWrapper wrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(Name, () => wrapper.Name);
			loader.ApplyPropertyPatch(Attribute, () => wrapper.AttributeID, Buff.AttributeIDFromBuffCategoryAndID);
			loader.ApplyPropertyPatch(Attribute, () => wrapper.Category, Buff.CategoryFromBuffCategoryAndID);
			loader.ApplyPropertyPatch(Mode, () => wrapper.Mode);
			loader.ApplyPropertyPatch(Value, () => wrapper.Value);
		}

		public string Name { get; set; }
		public Buff.CategoryAndID? Attribute { get; set; }
		public AttributeBuffMode? Mode { get; set; }
		public int? Value { get; set; }
		public bool Remove { get; set; }
	}
}
