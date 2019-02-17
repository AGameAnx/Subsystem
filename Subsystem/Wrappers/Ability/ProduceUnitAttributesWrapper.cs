using BBI.Game.Data;

namespace Subsystem.Wrappers
{
	public class ProduceUnitAttributesWrapper : ProduceUnitAttributes
	{
		public ProduceUnitAttributesWrapper(ProduceUnitAttributes other)
		{
			UnitTypeToProduce = other.UnitTypeToProduce;
			BypassQueue = other.BypassQueue;
		}

		public string UnitTypeToProduce { get; set; }
		public bool BypassQueue { get; set; }
	}
}
