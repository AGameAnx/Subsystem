using BBI.Core.Utility.FixedPoint;
using BBI.Game.Data;

namespace Subsystem.Wrappers
{
	public class UnitAvoidanceAttributesWrapper : UnitAvoidanceAttributes
	{
		public UnitAvoidanceAttributesWrapper(UnitAvoidanceAttributes other)
		{
			AvoidsCarriers = other.AvoidsCarriers;
			AvoidsWrecks = other.AvoidsWrecks;
			AvoidanceDistance = other.AvoidanceDistance;
		}

		public bool AvoidsCarriers { get; set; }
		public bool AvoidsWrecks { get; set; }
		public Fixed64 AvoidanceDistance { get; set; }
	}
}
