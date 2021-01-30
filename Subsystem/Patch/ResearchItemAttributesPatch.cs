using Subsystem.Wrappers;
using BBI.Game.Data;
using BBI.Core.Utility.FixedPoint;
using System.Collections.Generic;
using System.Linq;

namespace Subsystem.Patch
{
	public class ResearchItemAttributesPatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapperObj)
		{
			if (!(wrapperObj is ResearchItemAttributesWrapper wrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(TypeOfResearch, () => wrapper.TypeOfResearch);
			loader.ApplyPropertyPatch(IconSpriteName, () => wrapper.IconSpriteName);
			loader.ApplyPropertyPatch(LocalizedResearchTitleStringID, () => wrapper.LocalizedResearchTitleStringID);
			loader.ApplyPropertyPatch(LocalizedShortDescriptionStringID, () => wrapper.LocalizedShortDescriptionStringID);
			loader.ApplyPropertyPatch(LocalizedLongDescriptionStringID, () => wrapper.LocalizedLongDescriptionStringID);
			loader.ApplyPropertyPatch(ResearchTime, () => wrapper.ResearchTime, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(Dependencies, () => wrapper.Dependencies);
			loader.ApplyPropertyPatch(ResearchVOCode, () => wrapper.ResearchVOCode);
			loader.ApplyPropertyPatch(Resource1Cost, () => wrapper.Resource1Cost);
			loader.ApplyPropertyPatch(Resource2Cost, () => wrapper.Resource2Cost);

			if (UnitTypeBuffs != null)
			{
				var l = wrapper.UnitTypeBuffs?.Select(x => new UnitTypeBuffWrapper(x)).ToList() ?? new List<UnitTypeBuffWrapper>();
				loader.ApplyListPatch(UnitTypeBuffs, l, () => new UnitTypeBuffWrapper(), nameof(UnitTypeBuff));
				wrapper.UnitTypeBuffs = l.Where(x => x != null).ToArray();
			}
		}

		public ResearchType? TypeOfResearch { get; set; }
		public string IconSpriteName { get; set; }
		public string LocalizedResearchTitleStringID { get; set; }
		public string LocalizedShortDescriptionStringID { get; set; }
		public string LocalizedLongDescriptionStringID { get; set; }
		public double? ResearchTime { get; set; }
		public string[] Dependencies { get; set; }
		public string ResearchVOCode { get; set; }
		public Dictionary<string, UnitTypeBuffPatch> UnitTypeBuffs { get; set; } = new Dictionary<string, UnitTypeBuffPatch>();

		public int? Resource1Cost { get; set; }
		public int? Resource2Cost { get; set; }
	}
}
