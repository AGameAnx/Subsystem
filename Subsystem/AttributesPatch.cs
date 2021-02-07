using System.Collections.Generic;

namespace Subsystem
{
	public class AttributesPatch
	{
		public PatchMetaInfo Meta { get; set; } = new PatchMetaInfo();
		public StatsSheetSettings StatsSheetSettings { get; set; } = new StatsSheetSettings();

		public Dictionary<string, EntityTypePatch> Entities { get; set; } = new Dictionary<string, EntityTypePatch>();

		public EntityTypePatch Global { get; set; } = new EntityTypePatch();
	}
}
