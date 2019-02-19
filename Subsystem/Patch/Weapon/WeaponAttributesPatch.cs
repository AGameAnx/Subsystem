using Subsystem.Wrappers;
using BBI.Core.Data;
using BBI.Core.Utility.FixedPoint;
using BBI.Game.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Subsystem.Patch
{
	public class WeaponAttributesPatch: SubsystemPatch
	{
		public override void Apply(AttributeLoader loader, object wrapper, EntityTypeAttributes entityType)
		{
			base.Apply(loader, wrapper, entityType);

			RebindWeaponAttributes(entityType, wrapper as WeaponAttributesWrapper);
		}

		protected override void Apply(AttributeLoader loader, object wrapper)
		{
			if (!(wrapper is WeaponAttributesWrapper weaponAttributesWrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(ExcludeFromAutoTargetAcquisition, () => weaponAttributesWrapper.ExcludeFromAutoTargetAcquisition);
			loader.ApplyPropertyPatch(ExcludeFromAutoFire, () => weaponAttributesWrapper.ExcludeFromAutoFire);
			loader.ApplyPropertyPatch(ExcludeFromHeightAdvantage, () => weaponAttributesWrapper.ExcludeFromHeightAdvantage);
			loader.ApplyPropertyPatch(DamageType, () => weaponAttributesWrapper.DamageType);
			loader.ApplyPropertyPatch(IsTracer, () => weaponAttributesWrapper.IsTracer);
			loader.ApplyPropertyPatch(TracerSpeed, () => weaponAttributesWrapper.TracerSpeed, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(TracerLength, () => weaponAttributesWrapper.TracerLength, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(BaseDamagePerRound, () => weaponAttributesWrapper.BaseDamagePerRound, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(BaseWreckDamagePerRound, () => weaponAttributesWrapper.BaseWreckDamagePerRound, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(FiringRecoil, () => weaponAttributesWrapper.FiringRecoil);
			loader.ApplyPropertyPatch(WindUpTimeMS, () => weaponAttributesWrapper.WindUpTimeMS);
			loader.ApplyPropertyPatch(RateOfFire, () => weaponAttributesWrapper.RateOfFire);
			loader.ApplyPropertyPatch(NumberOfBursts, () => weaponAttributesWrapper.NumberOfBursts);
			loader.ApplyPropertyPatch(DamagePacketsPerShot, () => weaponAttributesWrapper.DamagePacketsPerShot);
			loader.ApplyPropertyPatch(BurstPeriodMinTimeMS, () => weaponAttributesWrapper.BurstPeriodMinTimeMS);
			loader.ApplyPropertyPatch(BurstPeriodMaxTimeMS, () => weaponAttributesWrapper.BurstPeriodMaxTimeMS);
			loader.ApplyPropertyPatch(CooldownTimeMS, () => weaponAttributesWrapper.CooldownTimeMS);
			loader.ApplyPropertyPatch(WindDownTimeMS, () => weaponAttributesWrapper.WindDownTimeMS);
			loader.ApplyPropertyPatch(ReloadTimeMS, () => weaponAttributesWrapper.ReloadTimeMS);
			loader.ApplyPropertyPatch(LineOfSightRequired, () => weaponAttributesWrapper.LineOfSightRequired);
			loader.ApplyPropertyPatch(LeadsTarget, () => weaponAttributesWrapper.LeadsTarget);
			loader.ApplyPropertyPatch(KillSkipsUnitDeathSequence, () => weaponAttributesWrapper.KillSkipsUnitDeathSequence);
			loader.ApplyPropertyPatch(RevealTriggers, () => weaponAttributesWrapper.RevealTriggers);
			loader.ApplyPropertyPatch(UnitStatusAttackingTriggers, () => weaponAttributesWrapper.UnitStatusAttackingTriggers);
			loader.ApplyPropertyPatch(TargetStyle, () => weaponAttributesWrapper.TargetStyle);

			if (Modifiers != null)
			{
				var modifiers = weaponAttributesWrapper.Modifiers.Select(x => new WeaponModifierInfoWrapper(x)).ToList();
				loader.ApplyListPatch(Modifiers.ToDictionary(x => x.Key, x => (SubsystemPatch)x.Value), modifiers, () => new WeaponModifierInfoWrapper(), nameof(WeaponModifierInfo));
				weaponAttributesWrapper.Modifiers = modifiers.ToArray();
			}

			loader.ApplyPropertyPatch(AreaOfEffectFalloffType, () => weaponAttributesWrapper.AreaOfEffectFalloffType);
			loader.ApplyPropertyPatch(AreaOfEffectRadius, () => weaponAttributesWrapper.AreaOfEffectRadius, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(ExcludeWeaponOwnerFromAreaOfEffect, () => weaponAttributesWrapper.ExcludeWeaponOwnerFromAreaOfEffect);
			loader.ApplyPropertyPatch(FriendlyFireDamageScalar, () => weaponAttributesWrapper.FriendlyFireDamageScalar, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(WeaponOwnerFriendlyFireDamageScalar, () => weaponAttributesWrapper.WeaponOwnerFriendlyFireDamageScalar, x => Fixed64.UnsafeFromDouble(x));

			if (Turret != null)
			{
				using (loader.logger.BeginScope($"Turret:"))
				{
					var turretWrapper = new TurretAttributesWrapper(weaponAttributesWrapper.Turret);
					Turret.Apply(loader, turretWrapper, null);
					weaponAttributesWrapper.Turret = turretWrapper;
				}
			}

			ApplyRangeAttributes(loader, WeaponRange.Short, RangeAttributesShort, weaponAttributesWrapper);
			ApplyRangeAttributes(loader, WeaponRange.Medium, RangeAttributesMedium, weaponAttributesWrapper);
			ApplyRangeAttributes(loader, WeaponRange.Long, RangeAttributesLong, weaponAttributesWrapper);

			loader.ApplyPropertyPatch(ProjectileEntityTypeToSpawn, () => weaponAttributesWrapper.ProjectileEntityTypeToSpawn);
			loader.ApplyPropertyPatch(StatusEffectsTargetAlignment, () => weaponAttributesWrapper.StatusEffectsTargetAlignment);
			loader.ApplyPropertyPatch(StatusEffectsExcludeTargetType, () => weaponAttributesWrapper.StatusEffectsExcludeTargetType);
			loader.ApplyPropertyPatch(ActiveStatusEffectsIndex, () => weaponAttributesWrapper.ActiveStatusEffectsIndex);

			if (StatusEffectsSets != null)
			{
				var wrappers = weaponAttributesWrapper.StatusEffectsSets.Select(x => new StatusEffectsSetAttributesWrapper(x)).ToList();
				loader.ApplyListPatch(StatusEffectsSets.ToDictionary(x => x.Key, x => (SubsystemPatch)x.Value), wrappers, () => new StatusEffectsSetAttributesWrapper(), nameof(StatusEffectsSetAttributes));
				weaponAttributesWrapper.StatusEffectsSets = wrappers.Where(x => x != null).ToArray();
			}

			/*if (EntityTypesToSpawnOnImpact != null)
			{
				var wrappers = weaponAttributesWrapper.EntityTypesToSpawnOnImpact.Select(x => new EntityTypeToSpawnAttributesWrapper(x)).ToList();
				loader.ApplyListPatch(EntityTypesToSpawnOnImpact.ToDictionary(x => x.Key, x => (SubsystemPatch)x.Value), wrappers, () => new EntityTypeToSpawnAttributesWrapper(), nameof(EntityTypeToSpawnAttributes));
				weaponAttributesWrapper.EntityTypesToSpawnOnImpact = wrappers.Where(x => x != null).ToArray();
			}*/

			if (TargetPrioritizationAttributes != null)
			{
				using (loader.logger.BeginScope($"TargetPrioritizationAttributes:"))
				{
					var targetPrioritizationWrapper = new TargetPriorizationAttributesWrapper(weaponAttributesWrapper.TargetPriorizationAttributes);
					TargetPrioritizationAttributes.Apply(loader, targetPrioritizationWrapper, null);
					weaponAttributesWrapper.TargetPriorizationAttributes = targetPrioritizationWrapper;
				}
			}

			if (OutputDPS == true)
			{
				OutputWeaponDPS(loader, weaponAttributesWrapper);
			}
		}

		private static void RebindWeaponAttributes(EntityTypeAttributes entityType, WeaponAttributesWrapper weaponAttributesWrapper)
		{
			var unitAttributes = entityType.Get<UnitAttributes>();
			if (unitAttributes != null)
			{
				var unitAttributesWrapper = new UnitAttributesWrapper(unitAttributes);
				for (var i = 0; i < unitAttributesWrapper.WeaponLoadout.Length; i++)
				{
					var weaponBinding = unitAttributesWrapper.WeaponLoadout[i];
					if (weaponBinding.Weapon.Name == weaponAttributesWrapper.Name)
					{
						unitAttributesWrapper.WeaponLoadout[i] = new WeaponBinding(
							weaponID: weaponBinding.WeaponID,
							weaponBindingIndex: weaponBinding.WeaponBindingIndex,
							weapon: weaponAttributesWrapper,
							ammoID: weaponBinding.AmmoID,
							turretIndex: weaponBinding.TurretIndex,
							defaultTurretAngleOffsetRadians: weaponBinding.DefaultTurretAngleOffsetRadians,
							disabledOnSpawn: weaponBinding.DisabledOnSpawn,
							weaponOffsetFromUnitOrigin: weaponBinding.OffsetFromUnitCenterInLocalSpace,
							showAmmoOnHUD: weaponBinding.ShowAmmoOnHUD
						);
					}
				}
				entityType.Replace(unitAttributes, unitAttributesWrapper);
			}
		}

		private void ApplyRangeAttributes(AttributeLoader loader, WeaponRange weaponRange, RangeBasedWeaponAttributesPatch rangePatch, WeaponAttributesWrapper weaponWrapper)
		{
			if (rangePatch == null) { return; }

			var ranges = weaponWrapper.Ranges;

			var newRanges = ranges.Where(r => r.Range < weaponRange);

			var range = ranges.SingleOrDefault(r => r.Range == weaponRange);

			using (loader.logger.BeginScope($"RangeAttributes{weaponRange}:"))
			{
				if (rangePatch.Remove)
				{
					loader.logger.Log("(removed)");
				}
				else
				{
					RangeBasedWeaponAttributesWrapper rangeWrapper;

					if (range != null)
					{
						rangeWrapper = new RangeBasedWeaponAttributesWrapper(range);
					}
					else
					{
						loader.logger.Log("(created)");
						rangeWrapper = new RangeBasedWeaponAttributesWrapper(weaponRange);
					}

					rangePatch.Apply(loader, rangeWrapper, null);

					newRanges = newRanges.Concat(new[] { rangeWrapper });
				}
			}

			newRanges = newRanges.Concat(ranges.Where(r => r.Range > weaponRange));

			weaponWrapper.Ranges = newRanges.ToArray();
		}

		public void OutputWeaponDPS(AttributeLoader loader, WeaponAttributesWrapper weaponAttributesWrapper)
		{
			using (loader.logger.BeginScope($"DPS info:"))
			{
				loader.logger.Log($"BaseDamagePerRound {weaponAttributesWrapper.BaseDamagePerRound}");
				loader.logger.Log($"RateOfFire {weaponAttributesWrapper.RateOfFire}");
				loader.logger.Log($"Burst: {weaponAttributesWrapper.BurstPeriodMinTimeMS} - {weaponAttributesWrapper.BurstPeriodMaxTimeMS}");
				loader.logger.Log($"NumberOfBursts {weaponAttributesWrapper.NumberOfBursts}");
				loader.logger.Log($"CooldownTimeMS: {weaponAttributesWrapper.CooldownTimeMS}");
				loader.logger.Log($"WindUpTimeMS: {weaponAttributesWrapper.WindUpTimeMS}");
				loader.logger.Log($"WindDownTimeMS: {weaponAttributesWrapper.WindDownTimeMS}");
				loader.logger.Log($"ReloadTimeMS: {weaponAttributesWrapper.ReloadTimeMS}");
				loader.logger.Log($"DamagePacketsPerShot: {weaponAttributesWrapper.DamagePacketsPerShot}");
				loader.logger.Log($"AreaOfEffectFalloffType: {weaponAttributesWrapper.AreaOfEffectFalloffType}");
				loader.logger.Log($"AreaOfEffectRadius: {weaponAttributesWrapper.AreaOfEffectRadius}");

				if (weaponAttributesWrapper.RateOfFire > 0)
				{
					loader.logger.Log("");

					int burstVariance = weaponAttributesWrapper.BurstPeriodMaxTimeMS - weaponAttributesWrapper.BurstPeriodMinTimeMS;

					int shotDuration = Math.Max(1, 1000 / weaponAttributesWrapper.RateOfFire);

					int shotsMin = Math.Max(1, weaponAttributesWrapper.BurstPeriodMinTimeMS / shotDuration);
					int shotsMax = Math.Max(1, weaponAttributesWrapper.BurstPeriodMaxTimeMS / shotDuration);

					int lowBracket = Math.Min(weaponAttributesWrapper.BurstPeriodMinTimeMS, shotDuration - 1 - (weaponAttributesWrapper.BurstPeriodMinTimeMS - shotsMin * shotDuration));
					int midBracket = Math.Max(0, shotsMax - shotsMin - 1) * shotDuration;
					int highBracket = shotsMin < shotsMax ? weaponAttributesWrapper.BurstPeriodMaxTimeMS - shotsMax * shotDuration + 1 : 0;

					double avgBurst = (weaponAttributesWrapper.BurstPeriodMaxTimeMS + weaponAttributesWrapper.BurstPeriodMinTimeMS) * 0.5;

					double averageShotsPerBurst = burstVariance == 0 ? shotsMin : (double)(shotsMin * lowBracket + (shotsMax + shotsMin) / 2 * midBracket + shotsMax * highBracket) / (lowBracket + midBracket + highBracket);
					double trueROF = averageShotsPerBurst / avgBurst * 1000;

					double sequenceDuration = (weaponAttributesWrapper.WindUpTimeMS + (avgBurst + weaponAttributesWrapper.CooldownTimeMS) * (weaponAttributesWrapper.NumberOfBursts - 1) + avgBurst + weaponAttributesWrapper.ReloadTimeMS) / 1000;

					loader.logger.Log($"averageShotsPerBurst: {averageShotsPerBurst:F4}");
					loader.logger.Log($"trueROF: {trueROF:F4}");
					loader.logger.Log($"sequenceDuration: {sequenceDuration:F4}");

					for (double armor = 0; armor <= 18; armor += 6)
					{
						using (loader.logger.BeginScope($"Armor {armor} DPS:"))
						{
							double dps = Math.Max(1, Fixed64.UnsafeDoubleValue(weaponAttributesWrapper.BaseDamagePerRound) - armor * weaponAttributesWrapper.DamagePacketsPerShot) * averageShotsPerBurst * weaponAttributesWrapper.NumberOfBursts / sequenceDuration;
							foreach (var range in weaponAttributesWrapper.Ranges)
							{
								loader.logger.Log($"{range.Range,6} ({range.Distance,5:D} /{(int)Fixed64.UnsafeDoubleValue(range.Accuracy),3:F2}%): {dps * Fixed64.UnsafeDoubleValue(range.Accuracy) / 100:F4}");
							}
						}
					}
				}
			}
		}
		
		public bool? ExcludeFromAutoTargetAcquisition { get; set; }
		public bool? ExcludeFromAutoFire { get; set; }
		public bool? ExcludeFromHeightAdvantage { get; set; }
		public DamageType? DamageType { get; set; }
		public bool? IsTracer { get; set; }
		public double? TracerSpeed { get; set; }
		public double? TracerLength { get; set; }
		public double? BaseDamagePerRound { get; set; }
		public double? BaseWreckDamagePerRound { get; set; }
		public float? FiringRecoil { get; set; }
		public int? WindUpTimeMS { get; set; }
		public int? RateOfFire { get; set; }
		public int? NumberOfBursts { get; set; }
		public int? DamagePacketsPerShot { get; set; }
		public int? BurstPeriodMinTimeMS { get; set; }
		public int? BurstPeriodMaxTimeMS { get; set; }
		public int? CooldownTimeMS { get; set; }
		public int? WindDownTimeMS { get; set; }
		public int? ReloadTimeMS { get; set; }
		public bool? LineOfSightRequired { get; set; }
		public TargetAimingType? LeadsTarget { get; set; }
		public bool? KillSkipsUnitDeathSequence { get; set; }
		public RevealTrigger? RevealTriggers { get; set; }
		public UnitStatusAttackingTrigger? UnitStatusAttackingTriggers { get; set; }
		public WeaponTargetStyle? TargetStyle { get; set; }
		public Dictionary<string, WeaponModifierInfoPatch> Modifiers { get; set; } = new Dictionary<string, WeaponModifierInfoPatch>();
		public AOEFalloffType? AreaOfEffectFalloffType { get; set; }
		public double? AreaOfEffectRadius { get; set; }
		public bool? ExcludeWeaponOwnerFromAreaOfEffect { get; set; }
		public double? FriendlyFireDamageScalar { get; set; }
		public double? WeaponOwnerFriendlyFireDamageScalar { get; set; }
		public TurretAttributesPatch Turret { get; set; }
		public RangeBasedWeaponAttributesPatch RangeAttributesShort { get; set; }
		public RangeBasedWeaponAttributesPatch RangeAttributesMedium { get; set; }
		public RangeBasedWeaponAttributesPatch RangeAttributesLong { get; set; }
		public string ProjectileEntityTypeToSpawn { get; set; }
		public AbilityTargetAlignment? StatusEffectsTargetAlignment { get; set; }
		public UnitClass? StatusEffectsExcludeTargetType { get; set; }
		public int? ActiveStatusEffectsIndex { get; set; }
		public Dictionary<string, StatusEffectsSetAttributesPatch> StatusEffectsSets { get; set; } = new Dictionary<string, StatusEffectsSetAttributesPatch>();
		public TargetPrioritizationAttributesPatch TargetPrioritizationAttributes { get; set; }

		//Disabled for concerns of people spawning DLC entities
		//public Dictionary<string, EntityTypeToSpawnAttributesPatch> EntityTypesToSpawnOnImpact { get; set; } = new Dictionary<string, EntityTypeToSpawnAttributesPatch>();

		public bool OutputDPS { get; set; }
	}
}
