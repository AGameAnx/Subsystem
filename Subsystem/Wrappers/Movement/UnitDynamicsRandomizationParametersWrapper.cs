using BBI.Core.Utility.FixedPoint;
using BBI.Game.Data;
using System.Linq;

namespace Subsystem.Wrappers
{
	public class UnitDynamicsRandomizationParametersWrapper : UnitDynamicsRandomizationParameters
	{
		public UnitDynamicsRandomizationParametersWrapper(UnitDynamicsRandomizationParameters other)
		{
			AccelerationTimeRandomVariancePercentage = other.AccelerationTimeRandomVariancePercentage;
			MaxSpeedTurnRadiusRandomVariancePercentage = other.MaxSpeedTurnRadiusRandomVariancePercentage;
			DriftTypeRandomVariancePercentage = other.DriftTypeRandomVariancePercentage;
			DriftOvershootFactorRandomVariancePercentage = other.DriftOvershootFactorRandomVariancePercentage;
			MinDriftSlipSpeedRandomVariancePercentage = other.MinDriftSlipSpeedRandomVariancePercentage;
			CruiseSpeedVariationRandomization = other.CruiseSpeedVariationRandomization?.ToArray();
			CruiseDirectionVariationRandomization = other.CruiseDirectionVariationRandomization?.ToArray();
		}

		public Fixed64 AccelerationTimeRandomVariancePercentage { get; set; }
		public Fixed64 MaxSpeedTurnRadiusRandomVariancePercentage { get; set; }
		public Fixed64 DriftTypeRandomVariancePercentage { get; set; }
		public Fixed64 DriftOvershootFactorRandomVariancePercentage { get; set; }
		public Fixed64 MinDriftSlipSpeedRandomVariancePercentage { get; set; }
		public CruiseDriveVariationAttributes[] CruiseSpeedVariationRandomization { get; set; }
		public CruiseDriveVariationAttributes[] CruiseDirectionVariationRandomization { get; set; }
	}
}
