using Subsystem.Wrappers;
using BBI.Core.Utility.FixedPoint;
using BBI.Game.Data;

namespace Subsystem.Patch
{
	public class ReverseOptionAttributesPatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapperObj)
		{
			if (!(wrapperObj is ReverseOptionAttributesWrapper wrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(Use, () => wrapper.Use);
			loader.ApplyPropertyPatch(AllowUseWhenMovingForward, () => wrapper.AllowUseWhenMovingForward);
			loader.ApplyPropertyPatch(MustReachMinSpeedBeforeTurn, () => wrapper.MustReachMinSpeedBeforeTurn);

			if (Region != null)
			{
				using (loader.logger.BeginScope($"Region:"))
				{
					var w = new ManeuverRegionAttributesWrapper(wrapper.Region);
					Region.Apply(loader, w, null);
					wrapper.Region = w;
				}
			}
		}

		public bool? Use { get; set; }
		public bool? AllowUseWhenMovingForward { get; set; }
		public bool? MustReachMinSpeedBeforeTurn { get; set; }
		public ManeuverRegionAttributesPatch Region { get; set; }
	}
}
