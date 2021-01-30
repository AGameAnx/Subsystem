using Subsystem.Wrappers;
using BBI.Game.Data;
using BBI.Core.Utility.FixedPoint;

namespace Subsystem.Patch
{
	public class SalvageAttributesPatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapperObj)
		{
			if (!(wrapperObj is SalvageAttributesWrapper wrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(TargetType, () => wrapper.TargetType);
			loader.ApplyArrayPropertyPatch(ExcludedResourceTargetTypes, wrapper, "ExcludedResourceTargetTypes");
			loader.ApplyPropertyPatch(AllowSearchingForNextNode, () => wrapper.AllowSearchingForNextNode);
			loader.ApplyPropertyPatch(SearchRelativeToClosestResourceControllerOnDropOff, () => wrapper.SearchRelativeToClosestResourceControllerOnDropOff);
			loader.ApplyPropertyPatch(TargetedSearchRange, () => wrapper.TargetedSearchRange, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(UseFallbackResourcing, () => wrapper.UseFallbackResourcing);
			loader.ApplyArrayPropertyPatch(FallbackResourceTargetType, wrapper, "FallbackResourceTargetType");
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
