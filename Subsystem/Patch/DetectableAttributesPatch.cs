using Subsystem.Wrappers;
using BBI.Core.Utility.FixedPoint;
using BBI.Game.Data;

namespace Subsystem.Patch
{
	public class DetectableAttributesPatch: SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapper)
		{
			if (!(wrapper is DetectableAttributesWrapper detectableAttributesWrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(DisplayLastKnownLocation, () => detectableAttributesWrapper.DisplayLastKnownLocation);
			loader.ApplyPropertyPatch(LastKnownDuration, () => detectableAttributesWrapper.LastKnownDuration, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(TimeVisibleAfterFiring, () => detectableAttributesWrapper.TimeVisibleAfterFiring);
			loader.ApplyPropertyPatch(AlwaysVisible, () => detectableAttributesWrapper.AlwaysVisible);
			loader.ApplyPropertyPatch(MinimumStateAfterDetection, () => detectableAttributesWrapper.MinimumStateAfterDetection);
			loader.ApplyPropertyPatch(FOWFadeDuration, () => detectableAttributesWrapper.FOWFadeDuration, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(SetHasBeenSeenBeforeOnSpawn, () => detectableAttributesWrapper.SetHasBeenSeenBeforeOnSpawn);
		}

		public bool? DisplayLastKnownLocation { get; set; }
		public double? LastKnownDuration { get; set; }
		public int? TimeVisibleAfterFiring { get; set; }
		public bool? AlwaysVisible { get; set; }
		public DetectionState? MinimumStateAfterDetection { get; set; }
		public double? FOWFadeDuration { get; set; }
		public bool? SetHasBeenSeenBeforeOnSpawn { get; set; }
	}
}
