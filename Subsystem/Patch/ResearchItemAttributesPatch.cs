﻿using Subsystem.Wrappers;
using BBI.Game.Data;
using BBI.Core.Utility.FixedPoint;

namespace Subsystem.Patch
{
	public class ResearchItemAttributesPatch: SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapper)
		{
			if (!(wrapper is ResearchItemAttributesWrapper researchItemAttributesWrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(TypeOfResearch, () => researchItemAttributesWrapper.TypeOfResearch);
			loader.ApplyPropertyPatch(IconSpriteName, () => researchItemAttributesWrapper.IconSpriteName);
			loader.ApplyPropertyPatch(LocalizedResearchTitleStringID, () => researchItemAttributesWrapper.LocalizedResearchTitleStringID);
			loader.ApplyPropertyPatch(LocalizedShortDescriptionStringID, () => researchItemAttributesWrapper.LocalizedShortDescriptionStringID);
			loader.ApplyPropertyPatch(LocalizedLongDescriptionStringID, () => researchItemAttributesWrapper.LocalizedLongDescriptionStringID);
			loader.ApplyPropertyPatch(ResearchTime, () => researchItemAttributesWrapper.ResearchTime, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(Dependencies, () => researchItemAttributesWrapper.Dependencies);
			loader.ApplyPropertyPatch(ResearchVOCode, () => researchItemAttributesWrapper.ResearchVOCode);
			loader.ApplyPropertyPatch(Resource1Cost, () => researchItemAttributesWrapper.Resource1Cost);
			loader.ApplyPropertyPatch(Resource2Cost, () => researchItemAttributesWrapper.Resource2Cost);
		}

		public ResearchType? TypeOfResearch { get; set; }
		public string IconSpriteName { get; set; }
		public string LocalizedResearchTitleStringID { get; set; }
		public string LocalizedShortDescriptionStringID { get; set; }
		public string LocalizedLongDescriptionStringID { get; set; }
		public double? ResearchTime { get; set; }
		public string[] Dependencies { get; set; }
		public string ResearchVOCode { get; set; }

		public int? Resource1Cost { get; set; }
		public int? Resource2Cost { get; set; }
	}
}
