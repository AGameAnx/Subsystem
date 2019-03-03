using Subsystem.Wrappers;
using BBI.Core.Utility.FixedPoint;
using System.Collections.Generic;

namespace Subsystem.Patch
{
	public class UnitHangarAttributesPatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapper)
		{
			if (!(wrapper is UnitHangarAttributesWrapper unitHangarAttributesWrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(AlignmentTime, () => unitHangarAttributesWrapper.AlignmentTime, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(ApproachTime, () => unitHangarAttributesWrapper.ApproachTime, x => Fixed64.UnsafeFromDouble(x));

			for (var i = 0; i < unitHangarAttributesWrapper.HangarBays.Length; i++)
			{
				var hangarBay = unitHangarAttributesWrapper.HangarBays[i];
				if (HangarBays.TryGetValue(hangarBay.Name, out HangarBayPatch hangarBayPatch))
				{
					using (loader.logger.BeginScope($"HangarBay: {hangarBay.Name}"))
					{
						var hangarBayWrapper = new HangarBayWrapper(hangarBay);
						hangarBayPatch.Apply(loader, hangarBayWrapper, null);
						unitHangarAttributesWrapper.HangarBays[i] = hangarBayWrapper;
					}
				}
			}
		}

		public Dictionary<string, HangarBayPatch> HangarBays { get; set; } = new Dictionary<string, HangarBayPatch>();
		public double? AlignmentTime { get; set; }
		public double? ApproachTime { get; set; }
	}
}
