using Subsystem.Wrappers;
using BBI.Game.Data;

namespace Subsystem.Patch
{
	public class UnitMovementAttributesPatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapperObj)
		{
			if (!(wrapperObj is UnitMovementAttributesWrapper wrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(DriveType, () => wrapper.DriveType);

			if (Dynamics != null)
			{
				using (loader.logger.BeginScope($"UnitDynamicsAttributes:"))
				{
					var w = new UnitDynamicsAttributesWrapper(wrapper.Dynamics);
					Dynamics.Apply(loader, w, null);
					wrapper.Dynamics = w;
				}
			}
			if (RandomDynamicsVariance != null)
			{
				using (loader.logger.BeginScope($"RandomDynamicsVariance:"))
				{
					var w = new UnitDynamicsRandomizationParametersWrapper(wrapper.RandomDynamicsVariance);
					RandomDynamicsVariance.Apply(loader, w, null);
					wrapper.RandomDynamicsVariance = w;
				}
			}
			if (Combat != null)
			{
				using (loader.logger.BeginScope($"Combat:"))
				{
					var w = new UnitCombatBehaviorAttributesWrapper(wrapper.Combat);
					Combat.Apply(loader, w, null);
					wrapper.Combat = w;
				}
			}
		}

		public UnitDriveType? DriveType { get; set; }
		public UnitDynamicsAttributesPatch Dynamics { get; set; }
		public UnitDynamicsRandomizationParametersPatch RandomDynamicsVariance { get; set; }
		public UnitCombatBehaviorAttributesPatch Combat { get; set; }
	}
}
