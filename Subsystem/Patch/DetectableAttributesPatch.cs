using Subsystem.Wrappers;
using BBI.Core.Utility.FixedPoint;
using BBI.Game.Data;

namespace Subsystem.Patch
{
	public class DetectableAttributesPatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapperObj)
		{
			if (!(wrapperObj is DetectableAttributesWrapper wrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(DisplayLastKnownLocation, () => wrapper.DisplayLastKnownLocation);
			loader.ApplyPropertyPatch(LastKnownDuration, () => wrapper.LastKnownDuration, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(TimeVisibleAfterFiring, () => wrapper.TimeVisibleAfterFiring);
			loader.ApplyPropertyPatch(AlwaysVisible, () => wrapper.AlwaysVisible);
			loader.ApplyPropertyPatch(MinimumStateAfterDetection, () => wrapper.MinimumStateAfterDetection);
			loader.ApplyPropertyPatch(FOWFadeDuration, () => wrapper.FOWFadeDuration, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(SetHasBeenSeenBeforeOnSpawn, () => wrapper.SetHasBeenSeenBeforeOnSpawn);
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
