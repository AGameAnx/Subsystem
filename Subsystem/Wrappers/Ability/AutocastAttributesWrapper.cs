using BBI.Game.Data;

namespace Subsystem.Wrappers
{
	public class AutocastAttributesWrapper : AutocastAttributes
	{
		public AutocastAttributesWrapper(AutocastAttributes other)
		{
			IsAutocastable = other.IsAutocastable;
			AutocastEnabledOnSpawn = other.AutocastEnabledOnSpawn;
		}

		public bool IsAutocastable { get; set; }
		public bool AutocastEnabledOnSpawn { get; set; }
	}
}
