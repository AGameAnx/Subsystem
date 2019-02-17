using BBI.Game.Data;

namespace Subsystem.Wrappers
{
	public class ChangeContextAttributesWrapper : ChangeContextAttributes
	{
		public ChangeContextAttributesWrapper(ChangeContextAttributes other)
		{
			TargetContext = other.TargetContext;
		}

		public string TargetContext { get; set; }
	}
}
