using Subsystem.Wrappers;
using BBI.Core.Utility.FixedPoint;

namespace Subsystem.Patch
{
	public class EntityTypeToSpawnAttributesPatch : SubsystemPatch, IRemovable
	{
		protected override void Apply(AttributeLoader loader, object wrapper)
		{
			if (!(wrapper is EntityTypeToSpawnAttributesWrapper entityTypeToSpawnAttributesWrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(EntityTypeToSpawn, () => entityTypeToSpawnAttributesWrapper.EntityTypeToSpawn);
			loader.ApplyPropertyPatch(SpawnRotationOffsetDegrees, () => entityTypeToSpawnAttributesWrapper.SpawnRotationOffsetDegrees, Fixed64.UnsafeFromDouble);
		}

		public string EntityTypeToSpawn { get; set; }
		public double? SpawnRotationOffsetDegrees { get; set; }

		public bool Remove { get; set; }
	}
}
