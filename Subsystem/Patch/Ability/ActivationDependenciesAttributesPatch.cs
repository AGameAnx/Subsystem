using Subsystem.Wrappers;
using BBI.Game.Data;

namespace Subsystem.Patch
{
	public class ActivationDependenciesAttributesPatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapperObj)
		{
			if (!(wrapperObj is ActivationDependenciesAttributesWrapper wrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(ManeuveringDependencies, () => wrapper.ManeuveringDependencies);
			loader.ApplyPropertyPatch(CommanderHasUnitWithTargetables, () => wrapper.CommanderHasUnitWithTargetables);
			loader.ApplyPropertyPatch(TakeNoDamageForMS, () => wrapper.TakeNoDamageForMS);
		}

		public ManeuveringRequirements? ManeuveringDependencies { get; set; }
		public TargetableRequirements? CommanderHasUnitWithTargetables { get; set; }
		public int? TakeNoDamageForMS { get; set; }
	}
}
