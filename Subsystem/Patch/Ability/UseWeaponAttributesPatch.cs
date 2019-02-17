using Subsystem.Wrappers;

namespace Subsystem.Patch
{
	public class ProduceUnitAttributesPatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapper)
		{
			if (!(wrapper is ProduceUnitAttributesWrapper produceUnitAttributesWrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(UnitTypeToProduce, () => produceUnitAttributesWrapper.UnitTypeToProduce);
			loader.ApplyPropertyPatch(BypassQueue, () => produceUnitAttributesWrapper.BypassQueue);
		}

		public string UnitTypeToProduce { get; set; }
		public bool? BypassQueue { get; set; }
	}
}
