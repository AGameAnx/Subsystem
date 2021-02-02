using BBI.Core.Utility.FixedPoint;
using BBI.Game.Data;

namespace Subsystem.Wrappers
{
	public class PeelOutAttributesWrapper : PeelOutAttributes
	{
		public PeelOutAttributesWrapper(PeelOutAttributes other)
		{
			UsePeelOut = other.UsePeelOut;
			PeelOutRegion = other.PeelOutRegion;
			DoOppositeTurn = other.DoOppositeTurn;
			InitialForwardAccelerationPercentage = other.InitialForwardAccelerationPercentage;
			RadiusProportionalGrowthConstant = other.RadiusProportionalGrowthConstant;
			InitialTurnRadiusAsMaxTurnRadiusPercentage = other.InitialTurnRadiusAsMaxTurnRadiusPercentage;
			MaxTurnRatePercentage = other.MaxTurnRatePercentage;
		}

		public bool UsePeelOut { get; set; }
		public ManeuverRegionAttributes PeelOutRegion { get; set; }
		public bool DoOppositeTurn { get; set; }
		public Fixed64 InitialForwardAccelerationPercentage { get; set; }
		public Fixed64 RadiusProportionalGrowthConstant { get; set; }
		public Fixed64 InitialTurnRadiusAsMaxTurnRadiusPercentage { get; set; }
		public Fixed64 MaxTurnRatePercentage { get; set; }
	}
}
