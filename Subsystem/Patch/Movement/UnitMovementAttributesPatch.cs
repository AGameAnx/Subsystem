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
			if (Maneuvers != null)
			{
				using (loader.logger.BeginScope($"RandomDynamicsVariance:"))
				{
					var w = new UnitManeuverAttributesWrapper(wrapper.Maneuvers);
					Maneuvers.Apply(loader, w, null);
					wrapper.Maneuvers = w;
				}
			}
			if (Hover != null)
			{
				using (loader.logger.BeginScope($"Hover:"))
				{
					var w = new HoverDynamicsAttributesWrapper(wrapper.Hover);
					Hover.Apply(loader, w, null);
					wrapper.Hover = w;
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
			if (Avoidance != null)
			{
				using (loader.logger.BeginScope($"Combat:"))
				{
					var w = new UnitAvoidanceAttributesWrapper(wrapper.Avoidance);
					Avoidance.Apply(loader, w, null);
					wrapper.Avoidance = w;
				}
			}
			if (ReversePolarity != null)
			{
				using (loader.logger.BeginScope($"ReversePolarity:"))
				{
					var w = new ReversePolarityAttributesWrapper(wrapper.ReversePolarity);
					ReversePolarity.Apply(loader, w, null);
					wrapper.ReversePolarity = w;
				}
			}
		}

		public UnitDriveType? DriveType { get; set; }
		public UnitDynamicsAttributesPatch Dynamics { get; set; }
		public UnitDynamicsRandomizationParametersPatch RandomDynamicsVariance { get; set; }
		public UnitManeuverAttributesPatch Maneuvers { get; set; }
		public HoverDynamicsAttributesPatch Hover { get; set; }
		public UnitCombatBehaviorAttributesPatch Combat { get; set; }
		public UnitAvoidanceAttributesPatch Avoidance { get; set; }
		public ReversePolarityAttributesPatch ReversePolarity { get; set; }
	}
}
