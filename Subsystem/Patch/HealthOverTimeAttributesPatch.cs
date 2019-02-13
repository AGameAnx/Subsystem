using BBI.Game.Data;

namespace Subsystem.Patch
{
	public class HealthOverTimeAttributesPatch: SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapper)
		{
			if (!(wrapper is HealthOverTimeAttributes healthOverTimeAttributes))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(ID, ref healthOverTimeAttributes.ID, "ID");
			loader.ApplyPropertyPatch(Amount, ref healthOverTimeAttributes.Amount, "Amount");
			loader.ApplyPropertyPatch(MSTickDuration, ref healthOverTimeAttributes.MSTickDuration, "MSTickDuration");
			loader.ApplyPropertyPatch(DamageType, ref healthOverTimeAttributes.DamageType, "DamageType");
		}

		public string ID { get; set; }
		public int? Amount { get; set; }
		public int? MSTickDuration { get; set; }
		public DamageType? DamageType;
	}
}
