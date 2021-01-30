using Subsystem.Wrappers;
using BBI.Core.Utility.FixedPoint;
using BBI.Game.Data;
using System.Collections.Generic;
using System.Linq;

namespace Subsystem.Patch
{
	public class StatusEffectAttributesPatch : SubsystemPatch, IRemovable
	{
		protected override void Apply(AttributeLoader loader, object wrapperbj)
		{
			if (!(wrapperbj is StatusEffectAttributesWrapper wrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(Lifetime, () => wrapper.Lifetime);
			loader.ApplyPropertyPatch(Duration, () => wrapper.Duration, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(WeaponFireTriggerEndEvent, () => wrapper.WeaponFireTriggerEndEvent);
			loader.ApplyPropertyPatch(MaxStacks, () => wrapper.MaxStacks);
			loader.ApplyPropertyPatch(StackingBehaviour, () => wrapper.StackingBehaviour);

			if (BuffsToApplyToTarget != null)
			{
				var l = wrapper.BuffsToApplyToTarget?.Select(x => new UnitTypeBuffWrapper(x)).ToList() ?? new List<UnitTypeBuffWrapper>();
				loader.ApplyListPatch(BuffsToApplyToTarget, l, () => new UnitTypeBuffWrapper(), "BuffsToApplyToTarget");
				wrapper.BuffsToApplyToTarget = l.ToArray();
			}

			if (UnitTypeBuffsToApply != null)
			{
				var l = wrapper.UnitTypeBuffsToApply?.Select(x => new UnitTypeBuffWrapper(x)).ToList() ?? new List<UnitTypeBuffWrapper>();
				loader.ApplyListPatch(UnitTypeBuffsToApply, l, () => new UnitTypeBuffWrapper(), "UnitTypeBuffsToApply");
				wrapper.UnitTypeBuffsToApply = l.ToArray();
			}

			if (Modifiers != null)
			{
				var wrapperModifiers = wrapper.Modifiers?.ToList() ?? new List<ModifierAttributes>();

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

				var toRemove = new Stack<int>();

				foreach (var kvp in parsed.OrderBy(p => p.Key))
				{
					var index = kvp.Key;
					var elementPatch = kvp.Value;

					using (loader.logger.BeginScope($"Modifiers: {index}"))
					{
						var remove = elementPatch.Remove;

						ModifierAttributes newValue;

						if (index < wrapperModifiers.Count())
						{
							if (remove)
							{
								loader.logger.Log("(removed)");
								toRemove.Push(index);
								continue;
							}

							newValue = wrapperModifiers[index];
						}
						else if (index >= wrapperModifiers.Count())
						{
							if (remove)
							{
								loader.logger.Log("WARNING: Remove flag set for non-existent entry");
								continue;
							}

							loader.logger.BeginScope("(created)").Dispose();

							newValue = new ModifierAttributes();
						}
						else // if (index > wrapperModifiers.Count)
						{
							loader.logger.Log("ERROR: Non-consecutive index");
							continue;
						}

						loader.ApplyPropertyPatch(elementPatch.ModifierType, ref newValue.ModifierType, "ModifierType");
						loader.ApplyPropertyPatch(elementPatch.EnableWeapon_WeaponID, ref newValue.EnableWeaponAttributes.WeaponID, "EnableWeapon_WeaponID");
						loader.ApplyPropertyPatch(elementPatch.SwapFromWeaponID, ref newValue.SwapWeaponAttributes.SwapFromWeaponID, "SwapFromWeaponID");
						loader.ApplyPropertyPatch(elementPatch.SwapToWeaponID, ref newValue.SwapWeaponAttributes.SwapToWeaponID, "SwapToWeaponID");

						if (elementPatch.HealthOverTimeAttributes != null)
						{
							using (loader.logger.BeginScope("HealthOverTimeAttributes:"))
							{
								loader.ApplyPropertyPatch(elementPatch.HealthOverTimeAttributes.ID, ref newValue.HealthOverTimeAttributes.ID, "ID");
								loader.ApplyPropertyPatch(elementPatch.HealthOverTimeAttributes.Amount, ref newValue.HealthOverTimeAttributes.Amount, "Amount");
								loader.ApplyPropertyPatch(elementPatch.HealthOverTimeAttributes.MSTickDuration, ref newValue.HealthOverTimeAttributes.MSTickDuration, "MSTickDuration");
								loader.ApplyPropertyPatch(elementPatch.HealthOverTimeAttributes.DamageType, ref newValue.HealthOverTimeAttributes.DamageType, "DamageType");
							}
						}

						if (index < wrapperModifiers.Count)
							wrapperModifiers[index] = newValue;
						else
							wrapperModifiers.Add(newValue);
					}
				}

				foreach (var v in toRemove)
					wrapperModifiers.RemoveAt(v);

				wrapper.Modifiers = wrapperModifiers.ToArray();
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
