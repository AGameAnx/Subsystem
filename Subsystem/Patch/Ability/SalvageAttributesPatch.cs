using Subsystem.Wrappers;
using BBI.Game.Data;
using BBI.Core.Utility.FixedPoint;

namespace Subsystem.Patch
{
	public class SalvageAttributesPatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapper)
		{
			if (!(wrapper is SalvageAttributesWrapper salvageAttributesWrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(TargetType, () => salvageAttributesWrapper.TargetType);
			loader.ApplyArrayPropertyPatch(ExcludedResourceTargetTypes, salvageAttributesWrapper, "ExcludedResourceTargetTypes");
			loader.ApplyPropertyPatch(AllowSearchingForNextNode, () => salvageAttributesWrapper.AllowSearchingForNextNode);
			loader.ApplyPropertyPatch(SearchRelativeToClosestResourceControllerOnDropOff, () => salvageAttributesWrapper.SearchRelativeToClosestResourceControllerOnDropOff);
			loader.ApplyPropertyPatch(TargetedSearchRange, () => salvageAttributesWrapper.TargetedSearchRange, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(UseFallbackResourcing, () => salvageAttributesWrapper.UseFallbackResourcing);
			loader.ApplyArrayPropertyPatch(FallbackResourceTargetType, salvageAttributesWrapper, "FallbackResourceTargetType");
		}

		public SalvageTargetType? TargetType { get; set; }
		public ResourceType[] ExcludedResourceTargetTypes { get; set; }
		public bool? AllowSearchingForNextNode { get; set; }
		public bool? SearchRelativeToClosestResourceControllerOnDropOff { get; set; }
		public double? TargetedSearchRange { get; set; }
		public bool? UseFallbackResourcing { get; set; }
		public ResourceType[] FallbackResourceTargetType { get; set; }
	}
}
