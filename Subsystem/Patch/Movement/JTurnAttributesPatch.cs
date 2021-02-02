using Subsystem.Wrappers;
using BBI.Game.Data;

namespace Subsystem.Patch
{
	public class JTurnAttributesPatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapperObj)
		{
			if (!(wrapperObj is JTurnAttributesWrapper wrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(TurnStyle, () => wrapper.TurnStyle);

			if (JTurnRegion != null)
			{
				using (loader.logger.BeginScope($"JTurnRegion:"))
				{
					var w = new ManeuverRegionAttributesWrapper(wrapper.JTurnRegion);
					JTurnRegion.Apply(loader, w, null);
					wrapper.JTurnRegion = w;
				}
			}
		}

		public TurnStyle? TurnStyle { get; set; }
		public ManeuverRegionAttributesPatch JTurnRegion { get; set; }
	}
}
