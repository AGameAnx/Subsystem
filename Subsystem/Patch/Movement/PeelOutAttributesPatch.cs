using Subsystem.Wrappers;
using BBI.Core.Utility.FixedPoint;

namespace Subsystem.Patch
{
	public class PeelOutAttributesPatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapperObj)
		{
			if (!(wrapperObj is PeelOutAttributesWrapper wrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(UsePeelOut, () => wrapper.UsePeelOut);
			loader.ApplyPropertyPatch(DoOppositeTurn, () => wrapper.DoOppositeTurn);
			loader.ApplyPropertyPatch(InitialForwardAccelerationPercentage, () => wrapper.InitialForwardAccelerationPercentage, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(RadiusProportionalGrowthConstant, () => wrapper.RadiusProportionalGrowthConstant, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(InitialTurnRadiusAsMaxTurnRadiusPercentage, () => wrapper.InitialTurnRadiusAsMaxTurnRadiusPercentage, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(MaxTurnRatePercentage, () => wrapper.MaxTurnRatePercentage, x => Fixed64.UnsafeFromDouble(x));

			if (PeelOutRegion != null)
			{
				using (loader.logger.BeginScope($"PeelOutRegion:"))
				{
					var w = new ManeuverRegionAttributesWrapper(wrapper.PeelOutRegion);
					PeelOutRegion.Apply(loader, w, null);
					wrapper.PeelOutRegion = w;
				}
			}
		}

		public bool? UsePeelOut { get; set; }
		public ManeuverRegionAttributesPatch PeelOutRegion { get; set; }
		public bool? DoOppositeTurn { get; set; }
		public double? InitialForwardAccelerationPercentage { get; set; }
		public double? RadiusProportionalGrowthConstant { get; set; }
		public double? InitialTurnRadiusAsMaxTurnRadiusPercentage { get; set; }
		public double? MaxTurnRatePercentage { get; set; }
	}
}
