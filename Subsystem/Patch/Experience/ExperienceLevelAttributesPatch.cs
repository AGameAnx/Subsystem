using Subsystem.Wrappers;
using BBI.Core.Data;
using System.Collections.Generic;
using System.Linq;

namespace Subsystem.Patch
{
	public class ExperienceLevelAttributesPatch : SubsystemPatch, IRemovable
	{
		protected override void Apply(AttributeLoader loader, object wrapperObj)
		{
			if (!(wrapperObj is ExperienceLevelAttributesWrapper wrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(BuffTooltipLocID, () => wrapper.BuffTooltipLocID);
			loader.ApplyPropertyPatch(RequiredExperience, () => wrapper.RequiredExperience);

			{
				var l = new AttributeBuffSetWrapper(wrapper.Buff);
				loader.ApplyListPatch(Buff, l.Buffs, () => new AttributeBuffWrapper(), nameof(AttributeBuff));
				wrapper.Buff = l;
			}
		}

		public string BuffTooltipLocID { get; set; }
		public int? RequiredExperience { get; set; }
		public Dictionary<string, AttributeBuffPatch> Buff { get; set; } = new Dictionary<string, AttributeBuffPatch>();

		public bool Remove { get; set; }
	}
}
