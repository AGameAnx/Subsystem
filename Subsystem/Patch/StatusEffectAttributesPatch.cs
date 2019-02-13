using Subsystem.Wrappers;
using BBI.Core.Utility.FixedPoint;
using BBI.Game.Data;
using System.Collections.Generic;
using System.Linq;

namespace Subsystem.Patch
{
	public class StatusEffectAttributesPatch : SubsystemPatch, IRemovable
	{
		protected override void Apply(AttributeLoader loader, object wrapper)
		{
			if (!(wrapper is StatusEffectAttributesWrapper statusEffectAttributesWrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(Lifetime, () => statusEffectAttributesWrapper.Lifetime);
			loader.ApplyPropertyPatch(Duration, () => statusEffectAttributesWrapper.Duration, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(WeaponFireTriggerEndEvent, () => statusEffectAttributesWrapper.WeaponFireTriggerEndEvent);
			loader.ApplyPropertyPatch(MaxStacks, () => statusEffectAttributesWrapper.MaxStacks);
			loader.ApplyPropertyPatch(StackingBehaviour, () => statusEffectAttributesWrapper.StackingBehaviour);

			var buffsToApplyToTarget = statusEffectAttributesWrapper.BuffsToApplyToTarget.Select(x => new UnitTypeBuffWrapper(x)).ToList();
			loader.ApplyListPatch(BuffsToApplyToTarget.ToDictionary(x => x.Key, x => (SubsystemPatch)x.Value), buffsToApplyToTarget, () => new UnitTypeBuffWrapper(), "BuffsToApplyToTarget");
			statusEffectAttributesWrapper.BuffsToApplyToTarget = buffsToApplyToTarget.ToArray();

			var unitTypeBuffsToApply = statusEffectAttributesWrapper.UnitTypeBuffsToApply.Select(x => new UnitTypeBuffWrapper(x)).ToList();
			loader.ApplyListPatch(UnitTypeBuffsToApply.ToDictionary(x => x.Key, x => (SubsystemPatch)x.Value), unitTypeBuffsToApply, () => new UnitTypeBuffWrapper(), "UnitTypeBuffsToApply");
			statusEffectAttributesWrapper.UnitTypeBuffsToApply = unitTypeBuffsToApply.ToArray();

			if (Modifiers != null)
			{
				var wrapperModifiers = statusEffectAttributesWrapper.Modifiers.ToList();

				var parsed = new Dictionary<int, ModifierAttributesPatch>();

				foreach (var kvp in Modifiers)
				{
					if (!int.TryParse(kvp.Key, out var index))
					{
						loader.logger.Log($"ERROR: Non-integer key: {kvp.Key}");
						break;
					}

					parsed[index] = kvp.Value;
				}

				var toDelete = new Stack<ModifierAttributes>();

				foreach (var kvp in parsed.OrderBy(p => p.Key))
				{
					var index = kvp.Key;
					var elementPatch = kvp.Value;

					using (loader.logger.BeginScope($"Modifiers: {index}"))
					{
						var remove = elementPatch.Remove;

						if (index < wrapperModifiers.Count)
						{
							if (remove)
							{
								loader.logger.Log("(removed)");
								toDelete.Push(wrapperModifiers[index]);
								continue;
							}

							elementPatch.Apply(loader, wrapperModifiers[index], null);
						}
						else if (index == wrapperModifiers.Count)
						{
							if (remove)
							{
								loader.logger.Log("WARNING: Remove flag set for non-existent entry");
								continue;
							}

							loader.logger.Log("(created)");

							ModifierAttributes newValue = new ModifierAttributes();
							elementPatch.Apply(loader, newValue, null);

							wrapperModifiers.Add(newValue);
						}
						else // if (index > wrapperModifiers.Count)
						{
							loader.logger.Log("ERROR: Non-consecutive index");
							continue;
						}
					}
				}

				wrapperModifiers.RemoveAll(x => toDelete.Contains(x));

				statusEffectAttributesWrapper.Modifiers = wrapperModifiers.ToArray();
			}
		}

		public StatusEffectLifetime? Lifetime { get; set; }
		public double? Duration { get; set; }
		public WeaponFireTrigger? WeaponFireTriggerEndEvent { get; set; }
		public int? MaxStacks { get; set; }
		public StackingBehaviour? StackingBehaviour { get; set; }

		public Dictionary<string, UnitTypeBuffPatch> BuffsToApplyToTarget { get; set; } = new Dictionary<string, UnitTypeBuffPatch>();
		public Dictionary<string, UnitTypeBuffPatch> UnitTypeBuffsToApply { get; set; } = new Dictionary<string, UnitTypeBuffPatch>();

		public Dictionary<string, ModifierAttributesPatch> Modifiers { get; set; } = new Dictionary<string, ModifierAttributesPatch>();

		public bool Remove { get; set; }
	}
}
