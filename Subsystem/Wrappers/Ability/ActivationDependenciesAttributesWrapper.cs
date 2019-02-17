using BBI.Game.Data;

namespace Subsystem.Wrappers
{
	public class ActivationDependenciesAttributesWrapper : ActivationDependenciesAttributes
	{
		public ActivationDependenciesAttributesWrapper(ActivationDependenciesAttributes other)
		{
			ManeuveringDependencies = other.ManeuveringDependencies;
			CommanderHasUnitWithTargetables = other.CommanderHasUnitWithTargetables;
			TakeNoDamageForMS = other.TakeNoDamageForMS;
		}

		public ManeuveringRequirements ManeuveringDependencies { get; set; }
		public TargetableRequirements CommanderHasUnitWithTargetables { get; set; }
		public int TakeNoDamageForMS { get; set; }
	}
}
