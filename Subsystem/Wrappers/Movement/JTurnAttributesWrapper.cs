using BBI.Game.Data;

namespace Subsystem.Wrappers
{
	public class JTurnAttributesWrapper : JTurnAttributes
	{
		public JTurnAttributesWrapper(JTurnAttributes other)
		{
			TurnStyle = other.TurnStyle;
			JTurnRegion = other.JTurnRegion;
		}

		public TurnStyle TurnStyle { get; set; }
		public ManeuverRegionAttributes JTurnRegion { get; set; }
	}
}
