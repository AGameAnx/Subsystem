using Subsystem.Wrappers;
using BBI.Core.Data;
using BBI.Core.Utility.FixedPoint;
using BBI.Game.Data;
using System.Collections.Generic;
using System.Linq;

namespace Subsystem.Patch
{
	public class WeaponAttributesPatch : SubsystemPatch
	{
		public override void Apply(AttributeLoader loader, object wrapperObj, EntityTypeAttributes entityType)
		{
			base.Apply(loader, wrapperObj, entityType);

			RebindWeaponAttributes(entityType, wrapperObj as WeaponAttributesWrapper);
		}

		protected override void Apply(AttributeLoader loader, object wrapperObj)
		{
			if (!(wrapperObj is WeaponAttributesWrapper wrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(ExcludeFromAutoTargetAcquisition, () => wrapper.ExcludeFromAutoTargetAcquisition);
			loader.ApplyPropertyPatch(ExcludeFromAutoFire, () => wrapper.ExcludeFromAutoFire);
			loader.ApplyPropertyPatch(ExcludeFromHeightAdvantage, () => wrapper.ExcludeFromHeightAdvantage);
			loader.ApplyPropertyPatch(DamageType, () => wrapper.DamageType);
			loader.ApplyPropertyPatch(IsTracer, () => wrapper.IsTracer);
			loader.ApplyPropertyPatch(TracerSpeed, () => wrapper.TracerSpeed, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(TracerLength, () => wrapper.TracerLength, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(BaseDamagePerRound, () => wrapper.BaseDamagePerRound, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(BaseWreckDamagePerRound, () => wrapper.BaseWreckDamagePerRound, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(FiringRecoil, () => wrapper.FiringRecoil);
			loader.ApplyPropertyPatch(WindUpTimeMS, () => wrapper.WindUpTimeMS);
			loader.ApplyPropertyPatch(RateOfFire, () => wrapper.RateOfFire);
			loader.ApplyPropertyPatch(NumberOfBursts, () => wrapper.NumberOfBursts);
			loader.ApplyPropertyPatch(DamagePacketsPerShot, () => wrapper.DamagePacketsPerShot);
			loader.ApplyPropertyPatch(BurstPeriodMinTimeMS, () => wrapper.BurstPeriodMinTimeMS);
			loader.ApplyPropertyPatch(BurstPeriodMaxTimeMS, () => wrapper.BurstPeriodMaxTimeMS);
			loader.ApplyPropertyPatch(CooldownTimeMS, () => wrapper.CooldownTimeMS);
			loader.ApplyPropertyPatch(WindDownTimeMS, () => wrapper.WindDownTimeMS);
			loader.ApplyPropertyPatch(ReloadTimeMS, () => wrapper.ReloadTimeMS);
			loader.ApplyPropertyPatch(LineOfSightRequired, () => wrapper.LineOfSightRequired);
			loader.ApplyPropertyPatch(LeadsTarget, () => wrapper.LeadsTarget);
			loader.ApplyPropertyPatch(KillSkipsUnitDeathSequence, () => wrapper.KillSkipsUnitDeathSequence);
			loader.ApplyPropertyPatch(RevealTriggers, () => wrapper.RevealTriggers);
			loader.ApplyPropertyPatch(UnitStatusAttackingTriggers, () => wrapper.UnitStatusAttackingTriggers);
			loader.ApplyPropertyPatch(TargetStyle, () => wrapper.TargetStyle);

			if (Modifiers != null)
			{
				var l = wrapper.Modifiers?.Select(x => new WeaponModifierInfoWrapper(x)).ToList() ?? new List<WeaponModifierInfoWrapper>();
				loader.ApplyListPatch(Modifiers, l, () => new WeaponModifierInfoWrapper(), nameof(WeaponModifierInfo));
				wrapper.Modifiers = l.ToArray();
			}

			loader.ApplyPropertyPatch(AreaOfEffectFalloffType, () => wrapper.AreaOfEffectFalloffType);
			loader.ApplyPropertyPatch(AreaOfEffectRadius, () => wrapper.AreaOfEffectRadius, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(ExcludeWeaponOwnerFromAreaOfEffect, () => wrapper.ExcludeWeaponOwnerFromAreaOfEffect);
			loader.ApplyPropertyPatch(FriendlyFireDamageScalar, () => wrapper.FriendlyFireDamageScalar, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(WeaponOwnerFriendlyFireDamageScalar, () => wrapper.WeaponOwnerFriendlyFireDamageScalar, x => Fixed64.UnsafeFromDouble(x));

			if (Turret != null)
			{
				using (loader.logger.BeginScope($"Turret:"))
				{
					var w = new TurretAttributesWrapper(wrapper.Turret);
					Turret.Apply(loader, w, null);
					wrapper.Turret = w;
				}
			}

			ApplyRangeAttributes(loader, WeaponRange.Short, RangeAttributesShort, wrapper);
			ApplyRangeAttributes(loader, WeaponRange.Medium, RangeAttributesMedium, wrapper);
			ApplyRangeAttributes(loader, WeaponRange.Long, RangeAttributesLong, wrapper);

			loader.ApplyPropertyPatch(ProjectileEntityTypeToSpawn, () => wrapper.ProjectileEntityTypeToSpawn);
			loader.ApplyPropertyPatch(StatusEffectsTargetAlignment, () => wrapper.StatusEffectsTargetAlignment);
			loader.ApplyPropertyPatch(StatusEffectsExcludeTargetType, () => wrapper.StatusEffectsExcludeTargetType);
			loader.ApplyPropertyPatch(ActiveStatusEffectsIndex, () => wrapper.ActiveStatusEffectsIndex);

			if (StatusEffectsSets != null)
			{
				var l = wrapper.StatusEffectsSets?.Select(x => new StatusEffectsSetAttributesWrapper(x)).ToList() ?? new List<StatusEffectsSetAttributesWrapper>();
				loader.ApplyListPatch(StatusEffectsSets, l, () => new StatusEffectsSetAttributesWrapper(), nameof(StatusEffectsSetAttributes));
				wrapper.StatusEffectsSets = l.Where(x => x != null).ToArray();
			}

			/*if (EntityTypesToSpawnOnImpact != null)
			{
				var l = weaponAttributesWrapper.EntityTypesToSpawnOnImpact?.Select(x => new EntityTypeToSpawnAttributesWrapper(x)).ToList() ?? new List<EntityTypeToSpawnAttributesWrapper>();
				loader.ApplyListPatch(EntityTypesToSpawnOnImpact, l, () => new EntityTypeToSpawnAttributesWrapper(), nameof(EntityTypeToSpawnAttributes));
				weaponAttributesWrapper.EntityTypesToSpawnOnImpact = l.Where(x => x != null).ToArray();
			}*/

			if (TargetPrioritizationAttributes != null)
			{
				using (loader.logger.BeginScope($"TargetPrioritizationAttributes:"))
				{
					var w = new TargetPriorizationAttributesWrapper(wrapper.TargetPriorizationAttributes);
					TargetPrioritizationAttributes.Apply(loader, w, null);
					wrapper.TargetPriorizationAttributes = w;
				}
			}

			if (OutputDPS == true)
			{
				OutputWeaponDPS(loader, wrapper);
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
						loader.logger.BeginScope("(created)").Dispose();
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
					WeaponDPSInfo weaponDPSInfo = new WeaponDPSInfo(weaponAttributesWrapper);

					loader.logger.Log("");
					loader.logger.Log($"AverageShotsPerBurst: {weaponDPSInfo.AverageShotsPerBurst:F4}");
					loader.logger.Log($"TrueROF: {weaponDPSInfo.TrueROF:F4}");
					loader.logger.Log($"SequenceDuration: {weaponDPSInfo.SequenceDuration:F4}");
					loader.logger.Log($"PureDPS: {weaponDPSInfo.PureDPS:F4}");

					for (int armor = 0; armor <= 18; armor += 6)
					{
						using (loader.logger.BeginScope($"Armor{armor}DPS:"))
						{
							double armorDPS = weaponDPSInfo.ArmorDPS(armor);
							Dictionary<WeaponRange, double> rangeDPS = weaponDPSInfo.RangeDPS(armorDPS);
							loader.logger.Log($"pure: {armorDPS:F4}");
							foreach (var range in weaponAttributesWrapper.Ranges)
							{
								double accuracy = Fixed64.UnsafeDoubleValue(range.Accuracy) * 0.01;
								loader.logger.Log($"{range.Range,6} ({range.Distance,5:D} /{accuracy*100,3:F2}%): {rangeDPS[range.Range]:F4}");
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
