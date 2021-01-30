using Subsystem.Wrappers;
using BBI.Core.Utility.FixedPoint;

namespace Subsystem.Patch
{
	public class UnitDynamicsRandomizationParametersPatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapperObj)
		{
			if (!(wrapperObj is UnitDynamicsRandomizationParametersWrapper wrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(AccelerationTimeRandomVariancePercentage, () => wrapper.AccelerationTimeRandomVariancePercentage, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(MaxSpeedTurnRadiusRandomVariancePercentage, () => wrapper.MaxSpeedTurnRadiusRandomVariancePercentage, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(DriftTypeRandomVariancePercentage, () => wrapper.DriftTypeRandomVariancePercentage, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(DriftOvershootFactorRandomVariancePercentage, () => wrapper.DriftOvershootFactorRandomVariancePercentage, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(MinDriftSlipSpeedRandomVariancePercentage, () => wrapper.MinDriftSlipSpeedRandomVariancePercentage, x => Fixed64.UnsafeFromDouble(x));
		}

		public double? AccelerationTimeRandomVariancePercentage { get; set; }
		public double? MaxSpeedTurnRadiusRandomVariancePercentage { get; set; }
		public double? DriftTypeRandomVariancePercentage { get; set; }
		public double? DriftOvershootFactorRandomVariancePercentage { get; set; }
		public double? MinDriftSlipSpeedRandomVariancePercentage { get; set; }

		//public Dictionary<string, CruiseDriveVariationAttributesPatch> CruiseSpeedVariationRandomization { get; set; } = new Dictionary<string, CruiseDriveVariationAttributesPatch>();
		//public Dictionary<string, CruiseDriveVariationAttributesPatch> CruiseDirectionVariationRandomization { get; set; } = new Dictionary<string, CruiseDriveVariationAttributesPatch>();
		//public CruiseDriveVariationAttributes[] CruiseSpeedVariationRandomization { get; set; }
		//public CruiseDriveVariationAttributes[] CruiseDirectionVariationRandomization { get; set; }
	}
}
