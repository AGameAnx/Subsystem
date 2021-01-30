using Subsystem.Wrappers;

namespace Subsystem.Patch
{
	public class ProduceUnitAttributesPatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapperObj)
		{
			if (!(wrapperObj is ProduceUnitAttributesWrapper wrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(UnitTypeToProduce, () => wrapper.UnitTypeToProduce);
			loader.ApplyPropertyPatch(BypassQueue, () => wrapper.BypassQueue);
		}

		public string UnitTypeToProduce { get; set; }
		public bool? BypassQueue { get; set; }
	}
}
