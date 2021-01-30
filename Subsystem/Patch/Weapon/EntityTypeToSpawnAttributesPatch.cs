using Subsystem.Wrappers;
using BBI.Core.Utility.FixedPoint;

namespace Subsystem.Patch
{
	public class EntityTypeToSpawnAttributesPatch : SubsystemPatch, IRemovable
	{
		protected override void Apply(AttributeLoader loader, object wrapperObj)
		{
			if (!(wrapperObj is EntityTypeToSpawnAttributesWrapper wrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(EntityTypeToSpawn, () => wrapper.EntityTypeToSpawn);
			loader.ApplyPropertyPatch(SpawnRotationOffsetDegrees, () => wrapper.SpawnRotationOffsetDegrees, Fixed64.UnsafeFromDouble);
		}

		public string EntityTypeToSpawn { get; set; }
		public double? SpawnRotationOffsetDegrees { get; set; }

		public bool Remove { get; set; }
	}
}
