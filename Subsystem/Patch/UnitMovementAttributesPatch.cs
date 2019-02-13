using Subsystem.Wrappers;
using BBI.Game.Data;

namespace Subsystem.Patch
{
	public class UnitMovementAttributesPatch: SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapper)
		{
			if (!(wrapper is UnitMovementAttributesWrapper unitMovementAttributesWrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(DriveType, () => unitMovementAttributesWrapper.DriveType);

			if (Dynamics != null)
			{
				using (loader.logger.BeginScope($"UnitDynamicsAttributes:"))
				{
					var unitDynamicsAttributesWrapper = new UnitDynamicsAttributesWrapper(unitMovementAttributesWrapper.Dynamics);
					Dynamics.Apply(loader, unitDynamicsAttributesWrapper, null);
					unitMovementAttributesWrapper.Dynamics = unitDynamicsAttributesWrapper;
				}
			}
		}

		public UnitDriveType? DriveType { get; set; }
		public UnitDynamicsAttributesPatch Dynamics { get; set; }
	}
}
