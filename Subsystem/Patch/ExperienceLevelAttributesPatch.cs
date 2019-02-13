using Subsystem.Wrappers;
using BBI.Core.Data;
using System.Collections.Generic;
using System.Linq;

namespace Subsystem.Patch
{
	public class ExperienceLevelAttributesPatch : SubsystemPatch, IRemovable
	{
		protected override void Apply(AttributeLoader loader, object wrapper)
		{
			if (!(wrapper is ExperienceLevelAttributesWrapper experienceLevelAttributesWrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(BuffTooltipLocID, () => experienceLevelAttributesWrapper.BuffTooltipLocID);
			loader.ApplyPropertyPatch(RequiredExperience, () => experienceLevelAttributesWrapper.RequiredExperience);

			var attributeBuffSetWrapper = new AttributeBuffSetWrapper(experienceLevelAttributesWrapper.Buff);
			loader.ApplyListPatch(Buff.ToDictionary(x => x.Key, x => (SubsystemPatch)x.Value), attributeBuffSetWrapper.Buffs, () => new AttributeBuffWrapper(), nameof(AttributeBuff));
			experienceLevelAttributesWrapper.Buff = attributeBuffSetWrapper;
		}

		public string BuffTooltipLocID { get; set; }
		public int? RequiredExperience { get; set; }
		public Dictionary<string, AttributeBuffPatch> Buff { get; set; } = new Dictionary<string, AttributeBuffPatch>();

		public bool Remove { get; set; }
	}
}
