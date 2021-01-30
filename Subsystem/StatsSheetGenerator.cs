
using Subsystem.Wrappers;
using System;
using System.Collections.Generic;
using System.IO;
using BBI.Core.Data;
using BBI.Game.Data;
using UnityEngine;

namespace Subsystem
{
	public class StatsSheetGenerator
	{
		public StatsSheetSettings settings;

		private readonly StringWriter writer;

		public StatsSheetGenerator()
		{
			writer = new StringWriter();
		}
		public StatsSheetGenerator(StatsSheetSettings settings)
		{
			writer = new StringWriter();

			this.settings = settings;
		}

		private int indent = 0;

		protected void WriteIndent()
		{
			for (var i = 0; i < indent; i++)
				writer.Write("  ");
		}

		public void IncreaseIndent()
		{
			++indent;
		}

		public void DecreaseIndent()
		{
			--indent;
		}

		private class ScopeDisposer : IDisposable
		{
			private readonly StatsSheetGenerator generator;

			public ScopeDisposer(StatsSheetGenerator generator)
			{
				this.generator = generator;
			}

			public void Dispose()
			{
				generator.DecreaseIndent();
			}
		}

		protected void Print(string str)
		{
			WriteIndent();
			writer.WriteLine(str);
		}

		public IDisposable BeginScope(string name)
		{
			Print($"{name}:");
			IncreaseIndent();
			return new ScopeDisposer(this);
		}

		public IDisposable BeginScope()
		{
			Print($"-");
			IncreaseIndent();
			return new ScopeDisposer(this);
		}

		public void Generate(EntityTypeCollection entityTypeCollection)
		{
			System.Text.StringBuilder sb = writer.GetStringBuilder();

			indent = 0;

			// Tech / Research
			using (BeginScope("techTrees"))
			{
				foreach (var treeName in settings.TechTrees)
				{
					using (BeginScope(treeName))
					{
						EntityTypeAttributes entityTypeAttributes = entityTypeCollection.GetEntityType(treeName);
						if (entityTypeAttributes != null)
							OutputForTechTree(entityTypeAttributes);
					}
				}
			}
			using (BeginScope("tierResearch"))
			{
				foreach (var treeName in settings.TechTrees)
				{
					using (BeginScope(treeName))
					{
						EntityTypeAttributes entityTypeAttributes = entityTypeCollection.GetEntityType(treeName);
						if (entityTypeAttributes != null)
							OutputForTierResearch(entityTypeCollection, entityTypeAttributes);
					}
				}
			}
			using (BeginScope("upgradeResearch"))
			{
				foreach (var treeName in settings.TechTrees)
				{
					using (BeginScope(treeName))
					{
						EntityTypeAttributes entityTypeAttributes = entityTypeCollection.GetEntityType(treeName);
						if (entityTypeAttributes != null)
							OutputForUpgradeResearch(entityTypeCollection, entityTypeAttributes);
					}
				}
			}
			File.WriteAllText(Path.Combine(Application.dataPath, settings.FilenameResearch), writer.ToString());
			sb.Remove(0, sb.Length);

			// General
			foreach (var kvp in settings.UnitList)
			{
				EntityTypeAttributes entityTypeAttributes = entityTypeCollection.GetEntityType(kvp.Key);
				if (entityTypeAttributes == null)
					Debug.Log($"[SUBSYSTEM] StatsSheetGenerator: couldn't find EntityList entity type \"{kvp.Key}\"");
				else
					OutputForGeneral(entityTypeCollection, entityTypeAttributes, kvp.Value);
			}
			File.WriteAllText(Path.Combine(Application.dataPath, settings.FilenameGeneral), writer.ToString());
			sb.Remove(0, sb.Length);

			// Carrier
			foreach (var kvp in settings.CarrierList)
			{
				EntityTypeAttributes entityTypeAttributes = entityTypeCollection.GetEntityType(kvp.Key);
				if (entityTypeAttributes == null)
					Debug.Log($"[SUBSYSTEM] StatsSheetGenerator: couldn't find EntityList entity type \"{kvp.Key}\"");
				else
					OutputForCarrier(entityTypeCollection, entityTypeAttributes, kvp.Value);
			}
			File.WriteAllText(Path.Combine(Application.dataPath, settings.FilenameCarrier), writer.ToString());
			sb.Remove(0, sb.Length);

			// Experience
			foreach (var kvp in settings.UnitList)
			{
				EntityTypeAttributes entityTypeAttributes = entityTypeCollection.GetEntityType(kvp.Key);
				if (entityTypeAttributes == null)
					Debug.Log($"[SUBSYSTEM] StatsSheetGenerator: couldn't find EntityList entity type \"{kvp.Key}\"");
				else
					OutputForExperience(entityTypeCollection, entityTypeAttributes, kvp.Value);
			}
			File.WriteAllText(Path.Combine(Application.dataPath, settings.FilenameExperience), writer.ToString());
			sb.Remove(0, sb.Length);

			// Movement
			foreach (var kvp in settings.UnitList)
			{
				EntityTypeAttributes entityTypeAttributes = entityTypeCollection.GetEntityType(kvp.Key);
				if (entityTypeAttributes == null)
					Debug.Log($"[SUBSYSTEM] StatsSheetGenerator: couldn't find EntityList entity type \"{kvp.Key}\"");
				else
					OutputForMovement(entityTypeCollection, entityTypeAttributes, kvp.Value);
			}
			File.WriteAllText(Path.Combine(Application.dataPath, settings.FilenameMovement), writer.ToString());
			sb.Remove(0, sb.Length);

			// DPS
			foreach (var kvp in settings.UnitList)
			{
				EntityTypeAttributes entityTypeAttributes = entityTypeCollection.GetEntityType(kvp.Key);
				if (entityTypeAttributes == null)
					Debug.Log($"[SUBSYSTEM] StatsSheetGenerator: couldn't find EntityList entity type \"{kvp.Key}\"");
				else
					OutputForDPS(entityTypeCollection, entityTypeAttributes, kvp.Value);
			}
			File.WriteAllText(Path.Combine(Application.dataPath, settings.FilenameDPS), writer.ToString());
			sb.Remove(0, sb.Length);

			// Other
			/*using (BeginScope("ranges"))
			{
				WeaponRange[] allRanges = (WeaponRange[])Enum.GetValues(typeof(WeaponRange));
				for (int i = 0; i < allRanges.Length; ++i)
					Print($"{allRanges[i]}");
			}
			using (BeginScope("falloffTypes"))
			{
				AOEFalloffType[] allFallofftypes = (AOEFalloffType[])Enum.GetValues(typeof(AOEFalloffType));
				for (int i = 0; i < allFallofftypes.Length; ++i)
					Print($"{allFallofftypes[i]}");
			}
			File.WriteAllText(Path.Combine(Application.dataPath, settings.FilenameOther), writer.ToString());
			sb.Remove(0, sb.Length);*/
		}

		protected void OutputForTechTree(EntityTypeAttributes entityTypeAttributes)
		{
			using (BeginScope(entityTypeAttributes.Name))
			{
				using (BeginScope("entries"))
				{
					TechTreeAttributes techTreeAttributes = entityTypeAttributes.Get<TechTreeAttributes>();
					for (int i = 0; i < techTreeAttributes.TechTrees.Length; ++i)
					{
						TechTree techTree = techTreeAttributes.TechTrees[i];
						using (BeginScope(techTree.TechTreeName))
						{
							Print($"icon: {techTree.IconSpriteName}");
							using (BeginScope("tiers"))
							{
								for (int j = 0; j < techTree.Tiers.Length; ++j)
								{
									TechTreeTier tier = techTree.Tiers[j];
									using (BeginScope(tier.TierName))
									{
										for (int k = 0; k < tier.ResearchItems.Length; ++k)
											Print($"- {tier.ResearchItems[k]}");
									}
								}
							}
							using (BeginScope("upgrades"))
							{
								for (int j = 0; j < techTree.Upgrades.Length; ++j)
								{
									TechUpgrade upgrade = techTree.Upgrades[j];
									using (BeginScope(upgrade.UpgradeName))
									{
										Print($"researchItem: {upgrade.ResearchItem}");
									}
								}
							}
						}
					}
				}
			}
		}
		
		protected void OutputForTierResearch(EntityTypeCollection entityTypeCollection, EntityTypeAttributes entityTypeAttributes)
		{
			TechTreeAttributes techTreeAttributes = entityTypeAttributes.Get<TechTreeAttributes>();
			for (int i = 0; i < techTreeAttributes.TechTrees.Length; ++i)
			{
				TechTree techTree = techTreeAttributes.TechTrees[i];
				for (int j = 0; j < techTree.Tiers.Length; ++j)
				{
					TechTreeTier tier = techTree.Tiers[j];
					for (int k = 0; k < tier.ResearchItems.Length; ++k)
					{
						EntityTypeAttributes researchItemEntityTypeAttributes = entityTypeCollection.GetEntityType(tier.ResearchItems[k]);
						ResearchItemAttributes researchItemAttributes = researchItemEntityTypeAttributes.Get<ResearchItemAttributes>();
						OutputForResearchItem(researchItemAttributes);
					}
				}
			}
		}

		protected void OutputForUpgradeResearch(EntityTypeCollection entityTypeCollection, EntityTypeAttributes entityTypeAttributes)
		{
			TechTreeAttributes techTreeAttributes = entityTypeAttributes.Get<TechTreeAttributes>();
			for (int i = 0; i < techTreeAttributes.TechTrees.Length; ++i)
			{
				TechTree techTree = techTreeAttributes.TechTrees[i];
				for (int j = 0; j < techTree.Upgrades.Length; ++j)
				{
					TechUpgrade upgrade = techTree.Upgrades[j];
					EntityTypeAttributes researchItemEntityTypeAttributes = entityTypeCollection.GetEntityType(upgrade.ResearchItem);
					ResearchItemAttributes researchItemAttributes = researchItemEntityTypeAttributes.Get<ResearchItemAttributes>();
					OutputForResearchItem(researchItemAttributes);
				}
			}
		}

		protected void OutputForResearchItem(ResearchItemAttributes researchItemAttributes)
		{
			using (BeginScope(researchItemAttributes.Name))
			{
				Print($"cu: {researchItemAttributes.Resource1Cost}");
				Print($"ru: {researchItemAttributes.Resource2Cost}");
				Print($"time: {researchItemAttributes.ResearchTime}");
				Print($"type: {researchItemAttributes.TypeOfResearch}");
				Print($"dependencies: [{String.Join(", ", researchItemAttributes.Dependencies)}]");
				if (researchItemAttributes.UnitTypeBuffs.Length > 0)
				{
					using (BeginScope("unitTypeBuffs"))
					{
						for (int i = 0; i < researchItemAttributes.UnitTypeBuffs.Length; ++i)
							OutputForUnitTypeBuff(researchItemAttributes.UnitTypeBuffs[i]);
					}
				}
			}
		}

		protected void OutputForStatusEffect(StatusEffectAttributes statusEffect)
		{
			Print($"lifetime: {statusEffect.Lifetime}");
			Print($"duration: {statusEffect.Duration}");
			Print($"stackingBehaviour: {statusEffect.StackingBehaviour}");
			Print($"maxStacks: {statusEffect.MaxStacks}");
			Print($"weaponFireTriggerEndEvent: {statusEffect.WeaponFireTriggerEndEvent}");

			if (statusEffect.UnitTypeBuffsToApply.Length > 0)
			{
				using (BeginScope("unitTypeBuffs"))
				{
					for (int i = 0; i < statusEffect.UnitTypeBuffsToApply.Length; ++i)
						OutputForUnitTypeBuff(statusEffect.UnitTypeBuffsToApply[i]);
				}
			}

			if (statusEffect.BuffsToApplyToTarget.Length > 0)
			{
				using (BeginScope("buffsToApplyToTarget"))
				{
					for (int i = 0; i < statusEffect.BuffsToApplyToTarget.Length; ++i)
						OutputForUnitTypeBuff(statusEffect.BuffsToApplyToTarget[i]);
				}
			}

			if (statusEffect.Modifiers.Length > 0)
			{
				using (BeginScope("modifiers"))
				{
					for (int i = 0; i < statusEffect.Modifiers.Length; ++i)
					{
						ModifierAttributes modifier = statusEffect.Modifiers[i];
						using (BeginScope())
						{
							Print($"modifierType: {modifier.ModifierType}");
							switch (modifier.ModifierType)
							{
								case ModifierType.EnableWeapon:
									Print($"weaponID: {modifier.EnableWeaponAttributes.WeaponID}");
									break;
								case ModifierType.SwapWeapons:
									Print($"swapFromWeaponID: {modifier.SwapWeaponAttributes.SwapFromWeaponID}");
									Print($"swapToWeaponID: {modifier.SwapWeaponAttributes.SwapToWeaponID}");
									break;
								case ModifierType.HealthOverTime:
									Print($"id: {modifier.HealthOverTimeAttributes.ID}");
									Print($"tickDurationMS: {modifier.HealthOverTimeAttributes.MSTickDuration}");
									Print($"damageType: {modifier.HealthOverTimeAttributes.DamageType}");
									Print($"amount: {modifier.HealthOverTimeAttributes.Amount}");
									break;
								default:
									break;
							}
						}
					}
				}
			}
		}

		protected void OutputForBuff(AttributeBuffWrapper buff)
		{
			Print($"attribute: {Buff.BuffCategoryAndIDFromCategoryAndAttributeID(buff.Category, buff.AttributeID)}");
			Print($"attributeID: {buff.AttributeID}");
			Print($"category: {buff.Category}");
			Print($"name: {buff.Name}");
			Print($"mode: {buff.Mode}");
			Print($"value: {buff.Value}");
		}

		protected void OutputForUnitTypeBuff(UnitTypeBuff buff)
		{
			using (BeginScope())
			{
				Print($"classOperator: {buff.ClassOperator}");
				Print($"unitClass: {buff.UnitClass}");
				Print($"unitType: {buff.UnitType}");
				Print($"useAsPrefix: {buff.UseAsPrefix}");
				using (BeginScope($"buffSet"))
				{
					OutputForAttributeBuffSet(new AttributeBuffSetWrapper(buff.BuffSet));
				}
			}
		}

		protected void OutputForAttributeBuffSet(AttributeBuffSetWrapper buffSet)
		{
			//Print($"uniqueTypeName: {buffSet.UniqueTypeName}");
			//using (BeginScope($"buffs"))
			foreach (var buff in buffSet.Buffs)
			{
				using (BeginScope())
				{
					OutputForBuff(buff);
				}
			}
		}

		protected void OutputForExperienceAttributes(ExperienceAttributes experience)
		{
			using (BeginScope($"experience"))
			{
				for (int i = 0; i < experience.Levels.Length; ++i)
				{
					ExperienceLevelAttributes level = experience.Levels[i];
					using (BeginScope(i.ToString()))
					{
						Print($"requiredxp: {level.RequiredExperience}");
						if (level.Buff != null)
						{
							using (BeginScope("buffSet"))
							{
								OutputForAttributeBuffSet(new AttributeBuffSetWrapper(level.Buff));
							}
						}
					}
				}
			}
		}

		protected void OutputForWeapons(EntityTypeCollection entityTypeCollection, EntityTypeAttributes entityTypeAttributes, string[] selectedWeapons, bool dps = false)
		{
			using (BeginScope("weapons"))
			{
				WeaponAttributes[] weaponAttributes = entityTypeAttributes.GetAll<WeaponAttributes>();
				for (int i = 0; i < weaponAttributes.Length; ++i)
				{
					WeaponAttributes w = weaponAttributes[i];
					if (selectedWeapons == null || Array.IndexOf(selectedWeapons, w.Name) >= 0)
					{
						using (BeginScope(w.Name))
						{
							Print($"damageType: {w.DamageType}");
							Print($"dmg: {w.BaseDamagePerRound}");
							Print($"packets: {w.DamagePacketsPerShot}");
							Print($"excludeFromHighGround: {w.ExcludeFromHeightAdvantage}");
							Print($"lineOfSightRequired: {w.LineOfSightRequired}");
							Print($"friendlyFireDamageScalar: {w.FriendlyFireDamageScalar}");
							Print($"leadsTarget: {w.LeadsTarget}");
							Print($"windUp: {w.WindUpTimeMS}");
							Print($"windDown: {w.WindDownTimeMS}");
							Print($"rof: {w.RateOfFire}");
							Print($"burstMin: {w.BurstPeriodMinTimeMS}");
							Print($"burstMax: {w.BurstPeriodMaxTimeMS}");
							Print($"numBursts: {w.NumberOfBursts}");
							Print($"cooldown: {w.CooldownTimeMS}");
							Print($"reload: {w.ReloadTimeMS}");
							Print($"aoe: {w.AreaOfEffectRadius}");
							Print($"falloff: {Enum.GetName(typeof(AOEFalloffType), w.AreaOfEffectFalloffType)}");

							using (BeginScope($"ranges"))
							{
								foreach (var r in w.Ranges)
								{
									using (BeginScope(Enum.GetName(typeof(WeaponRange), r.Range)))
									{
										Print($"distance: {r.Distance}");
										Print($"accuracy: {r.Accuracy}");
									}
								}
							}

							if (!dps)
							{
								using (BeginScope($"turret"))
								{
									Print($"fieldOfView: {w.Turret.FieldOfView}");
									Print($"fieldOfFire: {w.Turret.FieldOfFire}");
									Print($"rotationSpeed: {w.Turret.RotationSpeed}");
								}

								if (w.Modifiers.Length > 0)
								{
									using (BeginScope($"modifiers"))
									{
										for (int j = 0; j < w.Modifiers.Length; ++j)
										{
											WeaponModifierInfo modifierInfo = w.Modifiers[j];
											using (BeginScope(j.ToString()))
											{
												Print($"targetClass: {modifierInfo.TargetClass}");
												Print($"classOperator: {modifierInfo.ClassOperator}");
												Print($"modifierType: {modifierInfo.Modifier}");
												Print($"amount: {modifierInfo.Amount}");
											}
										}
									}
								}
								if (w.StatusEffectsSets.Length > 0)
								{
									Print($"statusEffectsExcludeTargetType: {w.StatusEffectsExcludeTargetType}");
									Print($"statusEffectsTargetAlignment: {w.StatusEffectsTargetAlignment}");
									using (BeginScope("statusEffectSets"))
									{
										for (int j = 0; j < w.StatusEffectsSets.Length; ++j)
										{
											for (int k = 0; k < w.StatusEffectsSets[j].StatusEffects.Length; ++k)
											{
												using (BeginScope(w.StatusEffectsSets[j].StatusEffects[k]))
												{
													EntityTypeAttributes seEntityTypeAttributes = entityTypeCollection.GetEntityType(w.StatusEffectsSets[j].StatusEffects[k]);
													StatusEffectAttributes[] statusEffectAttributes = seEntityTypeAttributes.GetAll<StatusEffectAttributes>();
													if (statusEffectAttributes.Length > 0)
														OutputForStatusEffect(statusEffectAttributes[0]);
												}
											}
										}
									}
								}
							}

							WeaponDPSInfo weaponDPSInfo = new WeaponDPSInfo(w);
							using (BeginScope("dpsInfo"))
							{
								Print($"avgShots: {weaponDPSInfo.AverageShotsPerBurst}");
								Print($"trueROF: {weaponDPSInfo.TrueROF}");
								Print($"sequenceDuration: {weaponDPSInfo.SequenceDuration}");
								if (dps)
								{
									using (BeginScope("dpsVsArmor"))
									{
										int[] armorVals = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 12, 15, 18, 21, 25, 50, 75, 100 };
										for (int j = 0; j < armorVals.Length; ++j)
										{
											using (BeginScope(armorVals[j].ToString()))
											{
												double armorDPS = weaponDPSInfo.ArmorDPS(armorVals[j]);
												Print($"dpsBeforeAccuracy: {armorDPS}");

												using (BeginScope("accuracyDps"))
												{
													Dictionary<WeaponRange, double> rangeDPS = weaponDPSInfo.RangeDPS(armorDPS);
													foreach (RangeBasedWeaponAttributes r in w.Ranges)
														Print($"{Enum.GetName(typeof(WeaponRange), r.Range)}: {rangeDPS[r.Range]}");
												}
											}
										}
									}
								}
								else
								{
									double armorDPS = weaponDPSInfo.ArmorDPS(0);
									Print($"dpsBeforeAccuracy: {armorDPS}");

									using (BeginScope("accuracyDps"))
									{
										Dictionary<WeaponRange, double> rangeDPS = weaponDPSInfo.RangeDPS(armorDPS);
										foreach (RangeBasedWeaponAttributes r in w.Ranges)
											Print($"{Enum.GetName(typeof(WeaponRange), r.Range)}: {rangeDPS[r.Range]}");
									}
								}
							}

						}
					}
				}
			}
		}

		protected void OutputForPowerShuntAttributes(PowerShuntAttributes powerShunt)
		{
			Print($"powerLevelChargeTime: {powerShunt.PowerLevelChargeTimeSeconds}");
			Print($"powerLevelDrainTime: {powerShunt.PowerLevelDrainTimeSeconds}");
			Print($"heatThreshold: {powerShunt.HeatThreshold}");
			Print($"cooldownRate: {powerShunt.CooldownRate}");
			Print($"overheatDamage: {powerShunt.OverheatDamage}");
			Print($"nearOverheatWarningMargin: {powerShunt.NearOverheatWarningMargin}");
			Print($"overheatReminderPeriod: {powerShunt.OverheatReminderPeriod}");
			using (BeginScope("reservePowerPool"))
			{
				OutputForInventory(powerShunt.ReservePowerPool);
			}
			using (BeginScope("overheatingPool"))
			{
				OutputForInventory(powerShunt.OverheatingPool);
			}
			using (BeginScope("heatSystem"))
			{
				OutputForInventory(powerShunt.HeatSystem);
			}
			using (BeginScope("powerSystems"))
			{
				for (var i = 0; i < powerShunt.PowerSystems.Length; ++i)
				{
					PowerSystemAttributes powerSystem = powerShunt.PowerSystems[i];
					using (BeginScope(i.ToString()))
					{
						Print($"type: {powerSystem.PowerSystemType}");
						Print($"startingPowerLevelIndex: {powerSystem.StartingPowerLevelIndex}");
						Print($"startingMaxPowerLevelIndex: {powerSystem.StartingMaxPowerLevelIndex}");
						using (BeginScope("powerLevels"))
						{
							for (var j = 0; j < powerSystem.PowerLevels.Length; ++j)
							{
								PowerLevelAttributes powerLevel = powerSystem.PowerLevels[j];
								using (BeginScope(j.ToString()))
								{
									Print($"powerUnitsRequired: {powerLevel.PowerUnitsRequired}");
									Print($"heatPointsProvided: {powerLevel.HeatPointsProvided}");
									using (BeginScope("statusEffects"))
									{
										if (powerLevel.StatusEffectsToApply != null)
										{
											for (var k = 0; k < powerLevel.StatusEffectsToApply.Length; ++k)
											{
												using (BeginScope(powerLevel.StatusEffectsToApply[k].Name))
												{
													OutputForStatusEffect(powerLevel.StatusEffectsToApply[k]);
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}

		protected void OutputForInventory(InventoryAttributes inventory)
		{
			Print($"name: {inventory.Name}");
			Print($"id: {inventory.InventoryID}");
			Print($"unlimitedCapacity: {inventory.HasUnlimitedCapacity}");
			Print($"capacity: {inventory.Capacity}");
			Print($"startingAmount: {inventory.StartingAmount}");
		}

		protected void OutputForMovementAttributes(UnitMovementAttributes movement, bool advanced = false)
		{
			using (BeginScope("movement"))
			{
				Print($"driveType: {movement.DriveType}");
				using (BeginScope("dynamics"))
				{
					Print($"permanentlyImmobile: {movement.Dynamics.PermanentlyImmobile}");
					Print($"minCruiseSpeed: {movement.Dynamics.MinCruiseSpeed}");
					Print($"maxEaseIntoTurnTime: {movement.Dynamics.MaxEaseIntoTurnTime}");
					Print($"maxSpeedTurnRadius: {movement.Dynamics.MaxSpeedTurnRadius}");
					Print($"brakingTime: {movement.Dynamics.BrakingTime}");
					Print($"accelerationTime: {movement.Dynamics.AccelerationTime}");
					Print($"reverseFactor: {movement.Dynamics.ReverseFactor}");
					Print($"maxSpeed: {movement.Dynamics.MaxSpeed}");
					Print($"width: {movement.Dynamics.Width}");
					Print($"length: {movement.Dynamics.Length}");
					if (advanced)
					{
						Print($"driveType: {movement.Dynamics.DriveType}");
						Print($"deathDriftTime: {movement.Dynamics.DeathDriftTime}");
						Print($"maxDriftRecoverTime: {movement.Dynamics.MaxDriftRecoverTime}");
						Print($"minDriftSlipSpeed: {movement.Dynamics.MinDriftSlipSpeed}");
						Print($"fishTailControlRecover: {movement.Dynamics.FishTailControlRecover}");
						Print($"fishTailingTimeIntervals: {movement.Dynamics.FishTailingTimeIntervals}");
						Print($"driftOvershootFactor: {movement.Dynamics.DriftOvershootFactor}");
						Print($"reverseDriftMultiplier: {movement.Dynamics.ReverseDriftMultiplier}");
						Print($"driftType: {movement.Dynamics.DriftType}");
					}
				}
				if (advanced)
				{
					using (BeginScope("hover"))
					{
						Print($"turnAcceleration: {movement.Hover.TurnAcceleration}");
						Print($"turnMaxLookAheadTime: {movement.Hover.TurnMaxLookAheadTime}");
						Print($"noTurnDistance: {movement.Hover.NoTurnDistance}");
						Print($"faceTargetOnlyInCombat: {movement.Hover.FaceTargetOnlyInCombat}");
						Print($"turnHeuristic: {movement.Hover.TurnHeuristic}");
					}
					using (BeginScope("combat"))
					{
						Print($"passiveCombatApproachMode: {movement.Combat.PassiveCombatApproachMode}");
						Print($"activeCombatApproachMode: {movement.Combat.ActiveCombatApproachMode}");
						Print($"minDesiredCombatRange: {movement.Combat.MinDesiredCombatRange}");
						Print($"maxDesiredCombatRange: {movement.Combat.MaxDesiredCombatRange}");
						Print($"hoverStrafeCycleDuration: {movement.Combat.HoverStrafeCycleDuration}");
						Print($"hoverStrafeLateralDisplacement: {movement.Combat.HoverStrafeLateralDisplacement}");
						Print($"advanceThroughSmokeScreen: {movement.Combat.AdvanceThroughSmokeScreen}");
					}
					using (BeginScope("avoidance"))
					{
						Print($"avoidsCarriers: {movement.Avoidance.AvoidsCarriers}");
						Print($"avoidsWrecks: {movement.Avoidance.AvoidsWrecks}");
						Print($"avoidanceDistance: {movement.Avoidance.AvoidanceDistance}");
					}
					using (BeginScope("reversePolarity"))
					{
						Print($"enabled: {movement.ReversePolarity.Enabled}");
						Print($"relativeWeight: {movement.ReversePolarity.RelativeWeight}");
						Print($"pushRadiusMultiplier: {movement.ReversePolarity.PushRadiusMultiplier}");
						Print($"squishinessFactor: {movement.ReversePolarity.SquishinessFactor}");
					}
				}
			}
		}

		protected void OutputForGeneral(EntityTypeCollection entityTypeCollection, EntityTypeAttributes entityTypeAttributes, StatsSheetSettings.UnitSetting unitSetting = null)
		{
			UnitAttributes unitAttributes = entityTypeAttributes.Get<UnitAttributes>();
			if (unitAttributes == null)
				return;

			using (BeginScope(entityTypeAttributes.Name))
			{
				// Unit Attributes
				Print($"readableName: {unitSetting.readableName}");
				Print($"cu: {unitAttributes.Resource1Cost}");
				Print($"ru: {unitAttributes.Resource2Cost}");
				Print($"time: {unitAttributes.ProductionTime}");
				Print($"pop: {unitAttributes.PopCapCost}");
				Print($"hp: {unitAttributes.MaxHealth}");
				Print($"armor: {unitAttributes.Armour}");
				Print($"sensor: {unitAttributes.SensorRadius}");
				Print($"contact: {unitAttributes.ContactRadius}");
				Print($"xp: {unitAttributes.ExperienceValue}");

				// Movement Attributes
				UnitMovementAttributes movement = entityTypeAttributes.Get<UnitMovementAttributes>();
				if (movement != null)
					OutputForMovementAttributes(movement);

				// Weapons
				if (unitAttributes.WeaponLoadout.Length > 0 && (unitSetting.weapons == null || unitSetting.weapons.Length > 0))
					OutputForWeapons(entityTypeCollection, entityTypeAttributes, unitSetting.weapons);
			}
		}

		protected void OutputForCarrier(EntityTypeCollection entityTypeCollection, EntityTypeAttributes entityTypeAttributes, StatsSheetSettings.UnitSetting unitSetting = null)
		{
			UnitAttributes unitAttributes = entityTypeAttributes.Get<UnitAttributes>();
			if (unitAttributes == null)
				return;

			using (BeginScope(entityTypeAttributes.Name))
			{
				// Unit Attributes
				Print($"readableName: {unitSetting.readableName}");
				Print($"cu: {unitAttributes.Resource1Cost}");
				Print($"ru: {unitAttributes.Resource2Cost}");
				Print($"time: {unitAttributes.ProductionTime}");
				Print($"pop: {unitAttributes.PopCapCost}");
				Print($"hp: {unitAttributes.MaxHealth}");
				Print($"armor: {unitAttributes.Armour}");
				Print($"sensor: {unitAttributes.SensorRadius}");

				// Power Shunt Attributes
				PowerShuntAttributes powerShunt = entityTypeAttributes.Get<PowerShuntAttributes>();
				if (powerShunt != null)
					OutputForPowerShuntAttributes(powerShunt);
			}
		}

		protected void OutputForMovement(EntityTypeCollection entityTypeCollection, EntityTypeAttributes entityTypeAttributes, StatsSheetSettings.UnitSetting unitSetting = null)
		{
			UnitAttributes unitAttributes = entityTypeAttributes.Get<UnitAttributes>();
			if (unitAttributes == null)
				return;

			UnitMovementAttributes movement = entityTypeAttributes.Get<UnitMovementAttributes>();
			if (movement == null)
				return;

			using (BeginScope(entityTypeAttributes.Name))
			{
				// Unit Attributes
				Print($"readableName: {unitSetting.readableName}");
				Print($"cu: {unitAttributes.Resource1Cost}");
				Print($"ru: {unitAttributes.Resource2Cost}");
				Print($"time: {unitAttributes.ProductionTime}");
				Print($"pop: {unitAttributes.PopCapCost}");
				Print($"hp: {unitAttributes.MaxHealth}");
				Print($"armor: {unitAttributes.Armour}");
				Print($"sensor: {unitAttributes.SensorRadius}");

				OutputForMovementAttributes(movement, true);
			}
		}

		protected void OutputForExperience(EntityTypeCollection entityTypeCollection, EntityTypeAttributes entityTypeAttributes, StatsSheetSettings.UnitSetting unitSetting = null)
		{
			UnitAttributes unitAttributes = entityTypeAttributes.Get<UnitAttributes>();
			if (unitAttributes == null)
				return;

			using (BeginScope(entityTypeAttributes.Name))
			{
				// Unit Attributes
				Print($"readableName: {unitSetting.readableName}");
				Print($"cu: {unitAttributes.Resource1Cost}");
				Print($"ru: {unitAttributes.Resource2Cost}");
				Print($"time: {unitAttributes.ProductionTime}");
				Print($"pop: {unitAttributes.PopCapCost}");
				Print($"hp: {unitAttributes.MaxHealth}");
				Print($"armor: {unitAttributes.Armour}");
				Print($"sensor: {unitAttributes.SensorRadius}");
				Print($"contact: {unitAttributes.ContactRadius}");
				Print($"xp: {unitAttributes.ExperienceValue}");

				// Experience Attributes
				ExperienceAttributes experience = entityTypeAttributes.Get<ExperienceAttributes>();
				if (experience != null)
					OutputForExperienceAttributes(experience);
			}
		}

		protected void OutputForDPS(EntityTypeCollection entityTypeCollection, EntityTypeAttributes entityTypeAttributes, StatsSheetSettings.UnitSetting unitSetting = null)
		{
			UnitAttributes unitAttributes = entityTypeAttributes.Get<UnitAttributes>();
			if (unitAttributes == null)
				return;

			if (unitAttributes.WeaponLoadout.Length == 0 || !(unitSetting.weapons == null || unitSetting.weapons.Length > 0))
				return;

			using (BeginScope(entityTypeAttributes.Name))
			{
				// Unit Attributes
				Print($"readableName: {unitSetting.readableName}");
				Print($"cu: {unitAttributes.Resource1Cost}");
				Print($"ru: {unitAttributes.Resource2Cost}");
				Print($"time: {unitAttributes.ProductionTime}");
				Print($"pop: {unitAttributes.PopCapCost}");
				Print($"hp: {unitAttributes.MaxHealth}");
				Print($"armor: {unitAttributes.Armour}");
				Print($"sensor: {unitAttributes.SensorRadius}");

				// Weapons
				OutputForWeapons(entityTypeCollection, entityTypeAttributes, unitSetting.weapons, true);
			}
		}

	}
}
