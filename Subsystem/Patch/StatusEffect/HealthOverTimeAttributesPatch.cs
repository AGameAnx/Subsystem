using BBI.Game.Data;

namespace Subsystem.Patch
{
	public class HealthOverTimeAttributesPatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapperObj)
		{ } // Does nothing because HealthOverTimeAttributes is a struct, see StatusEffectAttributesPatch class

		public string ID { get; set; }
		public int? Amount { get; set; }
		public int? MSTickDuration { get; set; }
		public DamageType? DamageType;
	}
}
