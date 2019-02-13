using BBI.Core.Data;

namespace Subsystem
{
	public abstract class SubsystemPatch
	{
		public virtual void Apply(AttributeLoader loader, object wrapper, EntityTypeAttributes entityType)
		{
			Apply(loader, wrapper);
		}

		abstract protected void Apply(AttributeLoader loader, object wrapper);
	}
}
