using Subsystem.Wrappers;
using BBI.Game.Data;
using BBI.Core.Utility.FixedPoint;
using System.Collections.Generic;
using System.Linq;

namespace Subsystem.Patch
{
	public class AbilityAttributesPatch: SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapper)
		{
			if (!(wrapper is AbilityAttributesWrapper abilityAttributesWrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(AbilityType, () => abilityAttributesWrapper.AbilityType);
			loader.ApplyPropertyPatch(TargetingType, () => abilityAttributesWrapper.TargetingType);
			loader.ApplyPropertyPatch(TargetAlignment, () => abilityAttributesWrapper.TargetAlignment);
			loader.ApplyPropertyPatch(AbilityMapTargetLayers, () => abilityAttributesWrapper.AbilityMapTargetLayers);
			loader.ApplyPropertyPatch(GroundAutoTargetAlignment, () => abilityAttributesWrapper.GroundAutoTargetAlignment);
			loader.ApplyPropertyPatch(EdgeOfTargetShapeMinDistance, () => abilityAttributesWrapper.EdgeOfTargetShapeMinDistance, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(CasterMovesToTarget, () => abilityAttributesWrapper.CasterMovesToTarget);
			loader.ApplyPropertyPatch(GroupActivationType, () => abilityAttributesWrapper.GroupActivationType);
			loader.ApplyPropertyPatch(StartsRemovedInGameMode, () => abilityAttributesWrapper.StartsRemovedInGameMode);
			loader.ApplyPropertyPatch(CooldownTimeSecs, () => abilityAttributesWrapper.CooldownTimeSecs, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(WarmupTimeSecs, () => abilityAttributesWrapper.WarmupTimeSecs, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(SharedCooldownChannel, () => abilityAttributesWrapper.SharedCooldownChannel);
			loader.ApplyPropertyPatch(SkipCastOnArrivalConditions, () => abilityAttributesWrapper.SkipCastOnArrivalConditions);
			loader.ApplyPropertyPatch(IsToggleable, () => abilityAttributesWrapper.IsToggleable);
			loader.ApplyPropertyPatch(CastOnDeath, () => abilityAttributesWrapper.CastOnDeath);

			if (TargetHighlighting != null)
			{
				using (loader.logger.BeginScope($"TargetHighlighting:"))
				{
					var targetHighlightingWrapper = new TargetHighlightingAttributesWrapper(abilityAttributesWrapper.TargetHighlighting);
					TargetHighlighting.Apply(loader, targetHighlightingWrapper, null);
					abilityAttributesWrapper.TargetHighlighting = targetHighlightingWrapper;
				}
			}

			if (Resource1Cost != null || Resource2Cost != null)
			{
				var costAttributesWrapper = new CostAttributesWrapper(abilityAttributesWrapper.Cost);
				loader.ApplyPropertyPatch(Resource1Cost, () => costAttributesWrapper.Resource1Cost);
				loader.ApplyPropertyPatch(Resource2Cost, () => costAttributesWrapper.Resource2Cost);
				abilityAttributesWrapper.Cost = costAttributesWrapper;
			}

			if (Charges != null)
			{
				using (loader.logger.BeginScope($"Charges:"))
				{
					var chargeAttributesWrapper = new ChargeAttributesWrapper(abilityAttributesWrapper.Charges);
					Charges.Apply(loader, chargeAttributesWrapper, null);
					abilityAttributesWrapper.Charges = chargeAttributesWrapper;
				}
			}

			if (Autocast != null)
			{
				using (loader.logger.BeginScope($"Autocast:"))
				{
					var autocastAttributesWrapper = new AutocastAttributesWrapper(abilityAttributesWrapper.Autocast);
					Autocast.Apply(loader, autocastAttributesWrapper, null);
					abilityAttributesWrapper.Autocast = autocastAttributesWrapper;
				}
			}

			if (ProduceUnit != null)
			{
				using (loader.logger.BeginScope($"ProduceUnit:"))
				{
					var produceUnitAttributesWrapper = new ProduceUnitAttributesWrapper(abilityAttributesWrapper.ProduceUnit);
					ProduceUnit.Apply(loader, produceUnitAttributesWrapper, null);
					abilityAttributesWrapper.ProduceUnit = produceUnitAttributesWrapper;
				}
			}

			if (UseWeapon != null)
			{
				using (loader.logger.BeginScope($"UseWeapon:"))
				{
					var useWeaponAttributesWrapper = new UseWeaponAttributesWrapper(abilityAttributesWrapper.UseWeapon);
					UseWeapon.Apply(loader, useWeaponAttributesWrapper, null);
					abilityAttributesWrapper.UseWeapon = useWeaponAttributesWrapper;
				}
			}

			if (ChangeContext != null)
			{
				var changeContextAttributesWrapper = new ChangeContextAttributesWrapper(abilityAttributesWrapper.ChangeContext);
				loader.ApplyPropertyPatch(ChangeContext, () => changeContextAttributesWrapper.TargetContext);
				abilityAttributesWrapper.ChangeContext = changeContextAttributesWrapper;
			}

			if (AirSortie != null)
			{
				using (loader.logger.BeginScope($"AirSortie:"))
				{
					var airSortieAttributesWrapper = new AirSortieAttributesWrapper(abilityAttributesWrapper.AirSortie);
					AirSortie.Apply(loader, airSortieAttributesWrapper, null);
					abilityAttributesWrapper.AirSortie = airSortieAttributesWrapper;
				}
			}

			if (Salvage != null)
			{
				using (loader.logger.BeginScope($"Salvage:"))
				{
					var salvageAttributesWrapper = new SalvageAttributesWrapper(abilityAttributesWrapper.Salvage);
					Salvage.Apply(loader, salvageAttributesWrapper, null);
					abilityAttributesWrapper.Salvage = salvageAttributesWrapper;
				}
			}

			if (ApplyStatusEffect.Count > 0)
			{
				using (loader.logger.BeginScope($"ApplyStatusEffect:"))
				{
					var applyStatusEffectAttributesWrapper = new ApplyStatusEffectAttributesWrapper(abilityAttributesWrapper.ApplyStatusEffect);

					var statusEffectWrappers = applyStatusEffectAttributesWrapper.StatusEffectsToApply?.Select(x => new StatusEffectAttributesWrapper(x)).ToList() ?? new List<StatusEffectAttributesWrapper>();
					loader.ApplyListPatch(ApplyStatusEffect, statusEffectWrappers, () => new StatusEffectAttributesWrapper(), nameof(StatusEffectAttributes));
					applyStatusEffectAttributesWrapper.StatusEffectsToApply = statusEffectWrappers.ToArray();

					abilityAttributesWrapper.ApplyStatusEffect = applyStatusEffectAttributesWrapper;
				}
			}

			if (Repair != null)
			{
				var repairAttributesWrapper = new RepairAttributesWrapper(abilityAttributesWrapper.Repair);
				loader.ApplyPropertyPatch(Repair, () => repairAttributesWrapper.WeaponID);
				abilityAttributesWrapper.Repair = repairAttributesWrapper;
			}

			if (SelfDestruct != null)
			{
				using (loader.logger.BeginScope($"SelfDestruct:"))
				{
					var selfDestructAttributesWrapper = new SelfDestructAttributesWrapper(abilityAttributesWrapper.SelfDestruct);
					SelfDestruct.Apply(loader, selfDestructAttributesWrapper, null);
					abilityAttributesWrapper.SelfDestruct = selfDestructAttributesWrapper;
				}
			}

			if (ModifyInventory != null)
			{
				using (loader.logger.BeginScope($"ModifyInventory:"))
				{
					var modifyInventoryAttributesWrapper = new ModifyInventoryAttributesWrapper(abilityAttributesWrapper.ModifyInventory);
					ModifyInventory.Apply(loader, modifyInventoryAttributesWrapper, null);
					abilityAttributesWrapper.ModifyInventory = modifyInventoryAttributesWrapper;
				}
			}

			if (RequiredResearch != null)
			{
				var researchDependenciesAttributesWrapper = new ResearchDependenciesAttributesWrapper(abilityAttributesWrapper.ResearchDependencies);
				loader.ApplyArrayPropertyPatch(RequiredResearch, researchDependenciesAttributesWrapper, "RequiredResearch");
				abilityAttributesWrapper.ResearchDependencies = researchDependenciesAttributesWrapper;
			}

			if (ActivationDependencies != null)
			{
				using (loader.logger.BeginScope($"ActivationDependencies:"))
				{
					var activationDependenciesAttributesWrapper = new ActivationDependenciesAttributesWrapper(abilityAttributesWrapper.ActivationDependencies);
					ActivationDependencies.Apply(loader, activationDependenciesAttributesWrapper, null);
					abilityAttributesWrapper.ActivationDependencies = activationDependenciesAttributesWrapper;
				}
			}

			if (AutoToggleOffConditions != null)
			{
				using (loader.logger.BeginScope($"AutoToggleOffConditions:"))
				{
					var autoToggleOffConditionsAttributesWrapper = new AutoToggleOffConditionsAttributesWrapper(abilityAttributesWrapper.AutoToggleOffConditions);
					AutoToggleOffConditions.Apply(loader, autoToggleOffConditionsAttributesWrapper, null);
					abilityAttributesWrapper.AutoToggleOffConditions = autoToggleOffConditionsAttributesWrapper;
				}
			}

			if (ChainCasting != null)
			{
				using (loader.logger.BeginScope($"ChainCasting:"))
				{
					var chainCastingAttributesWrapper = new ChainCastingAttributesWrapper(abilityAttributesWrapper.ChainCasting);
					ChainCasting.Apply(loader, chainCastingAttributesWrapper, null);
					abilityAttributesWrapper.ChainCasting = chainCastingAttributesWrapper;
				}
			}
		}

		public AbilityClass? AbilityType { get; set; }
		public AbilityTargetingType? TargetingType { get; set; }
		public AbilityTargetAlignment? TargetAlignment { get; set; }
		public UnitClass? AbilityMapTargetLayers { get; set; }
		public GroundAutoTargetAlignmentType? GroundAutoTargetAlignment { get; set; }
		public double? EdgeOfTargetShapeMinDistance { get; set; }
		public bool? CasterMovesToTarget { get; set; }
		public AbilityGroupActivationType? GroupActivationType { get; set; }
		public AbilityRemovedInMode? StartsRemovedInGameMode { get; set; }
		public double? CooldownTimeSecs { get; set; }
		public double? WarmupTimeSecs { get; set; }
		public int? SharedCooldownChannel { get; set; }
		public SkipCastOnArrivalConditions? SkipCastOnArrivalConditions { get; set; }
		public bool? IsToggleable { get; set; }
		public bool? CastOnDeath { get; set; }

		public TargetHighlightingAttributesPatch TargetHighlighting { get; set; }
		public int? Resource1Cost { get; set; }
		public int? Resource2Cost { get; set; }
		public ChargeAttributesPatch Charges { get; set; }
		public AutocastAttributesPatch Autocast { get; set; }
		public ProduceUnitAttributesPatch ProduceUnit { get; set; }
		public UseWeaponAttributesPatch UseWeapon { get; set; }
		public string ChangeContext { get; set; }
		public AirSortieAttributesPatch AirSortie { get; set; }
		public SalvageAttributesPatch Salvage { get; set; }
		public Dictionary<string, StatusEffectAttributesPatch> ApplyStatusEffect { get; set; } = new Dictionary<string, StatusEffectAttributesPatch>();
		public string Repair { get; set; }
		public SelfDestructAttributesPatch SelfDestruct { get; set; }
		public ModifyInventoryAttributesPatch ModifyInventory { get; set; }
		public string[] RequiredResearch { get; set; }
		public ActivationDependenciesAttributesPatch ActivationDependencies { get; set; }
		public AutoToggleOffConditionsAttributesPatch AutoToggleOffConditions { get; set; }
		public ChainCastingAttributesPatch ChainCasting { get; set; }
	}
}
