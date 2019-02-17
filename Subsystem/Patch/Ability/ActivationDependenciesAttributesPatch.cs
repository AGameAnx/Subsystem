using Subsystem.Wrappers;
using BBI.Game.Data;

namespace Subsystem.Patch
{
	public class ActivationDependenciesAttributesPatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapper)
		{
			if (!(wrapper is ActivationDependenciesAttributesWrapper activationDependenciesAttributesWrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(ManeuveringDependencies, () => activationDependenciesAttributesWrapper.ManeuveringDependencies);
			loader.ApplyPropertyPatch(CommanderHasUnitWithTargetables, () => activationDependenciesAttributesWrapper.CommanderHasUnitWithTargetables);
			loader.ApplyPropertyPatch(TakeNoDamageForMS, () => activationDependenciesAttributesWrapper.TakeNoDamageForMS);
		}

		public ManeuveringRequirements? ManeuveringDependencies { get; set; }
		public TargetableRequirements? CommanderHasUnitWithTargetables { get; set; }
		public int? TakeNoDamageForMS { get; set; }
	}
}
