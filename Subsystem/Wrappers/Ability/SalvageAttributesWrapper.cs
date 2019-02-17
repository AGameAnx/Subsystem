using BBI.Game.Data;
using BBI.Core.Utility.FixedPoint;

namespace Subsystem.Wrappers
{
	public class SalvageAttributesWrapper : SalvageAttributes
	{
		public SalvageAttributesWrapper(SalvageAttributes other)
		{
			TargetType = other.TargetType;
			ExcludedResourceTargetTypes = other.ExcludedResourceTargetTypes;
			AllowSearchingForNextNode = other.AllowSearchingForNextNode;
			SearchRelativeToClosestResourceControllerOnDropOff = other.SearchRelativeToClosestResourceControllerOnDropOff;
			TargetedSearchRange = other.TargetedSearchRange;
			UseFallbackResourcing = other.UseFallbackResourcing;
			FallbackResourceTargetType = other.FallbackResourceTargetType;
		}

		public SalvageTargetType TargetType { get; set; }
		public ResourceType[] ExcludedResourceTargetTypes { get; set; }
		public bool AllowSearchingForNextNode { get; set; }
		public bool SearchRelativeToClosestResourceControllerOnDropOff { get; set; }
		public Fixed64 TargetedSearchRange { get; set; }
		public bool UseFallbackResourcing { get; set; }
		public ResourceType[] FallbackResourceTargetType { get; set; }
	}
}
