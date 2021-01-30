using Subsystem.Wrappers;
using BBI.Game.Data;
using BBI.Core.Utility.FixedPoint;
using System.Collections.Generic;
using System.Linq;

namespace Subsystem.Patch
{
	public class AbilityAttributesPatch : SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapperObj)
		{
			if (!(wrapperObj is AbilityAttributesWrapper wrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(AbilityType, () => wrapper.AbilityType);
			loader.ApplyPropertyPatch(TargetingType, () => wrapper.TargetingType);
			loader.ApplyPropertyPatch(TargetAlignment, () => wrapper.TargetAlignment);
			loader.ApplyPropertyPatch(AbilityMapTargetLayers, () => wrapper.AbilityMapTargetLayers);
			loader.ApplyPropertyPatch(GroundAutoTargetAlignment, () => wrapper.GroundAutoTargetAlignment);
			loader.ApplyPropertyPatch(EdgeOfTargetShapeMinDistance, () => wrapper.EdgeOfTargetShapeMinDistance, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(CasterMovesToTarget, () => wrapper.CasterMovesToTarget);
			loader.ApplyPropertyPatch(GroupActivationType, () => wrapper.GroupActivationType);
			loader.ApplyPropertyPatch(StartsRemovedInGameMode, () => wrapper.StartsRemovedInGameMode);
			loader.ApplyPropertyPatch(CooldownTimeSecs, () => wrapper.CooldownTimeSecs, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(WarmupTimeSecs, () => wrapper.WarmupTimeSecs, x => Fixed64.UnsafeFromDouble(x));
			loader.ApplyPropertyPatch(SharedCooldownChannel, () => wrapper.SharedCooldownChannel);
			loader.ApplyPropertyPatch(SkipCastOnArrivalConditions, () => wrapper.SkipCastOnArrivalConditions);
			loader.ApplyPropertyPatch(IsToggleable, () => wrapper.IsToggleable);
			loader.ApplyPropertyPatch(CastOnDeath, () => wrapper.CastOnDeath);

			if (TargetHighlighting != null)
			{
				using (loader.logger.BeginScope($"TargetHighlighting:"))
				{
					var w = new TargetHighlightingAttributesWrapper(wrapper.TargetHighlighting);
					TargetHighlighting.Apply(loader, w, null);
					wrapper.TargetHighlighting = w;
				}
			}

			if (Resource1Cost != null || Resource2Cost != null)
			{
				var w = new CostAttributesWrapper(wrapper.Cost);
				loader.ApplyPropertyPatch(Resource1Cost, () => w.Resource1Cost);
				loader.ApplyPropertyPatch(Resource2Cost, () => w.Resource2Cost);
				wrapper.Cost = w;
			}

			if (Charges != null)
			{
				using (loader.logger.BeginScope($"Charges:"))
				{
					var w = new ChargeAttributesWrapper(wrapper.Charges);
					Charges.Apply(loader, w, null);
					wrapper.Charges = w;
				}
			}

			if (Autocast != null)
			{
				using (loader.logger.BeginScope($"Autocast:"))
				{
					var w = new AutocastAttributesWrapper(wrapper.Autocast);
					Autocast.Apply(loader, w, null);
					wrapper.Autocast = w;
				}
			}

			if (ProduceUnit != null)
			{
				using (loader.logger.BeginScope($"ProduceUnit:"))
				{
					var w = new ProduceUnitAttributesWrapper(wrapper.ProduceUnit);
					ProduceUnit.Apply(loader, w, null);
					wrapper.ProduceUnit = w;
				}
			}

			if (UseWeapon != null)
			{
				using (loader.logger.BeginScope($"UseWeapon:"))
				{
					var w = new UseWeaponAttributesWrapper(wrapper.UseWeapon);
					UseWeapon.Apply(loader, w, null);
					wrapper.UseWeapon = w;
				}
			}

			if (ChangeContext != null)
			{
				var w = new ChangeContextAttributesWrapper(wrapper.ChangeContext);
				loader.ApplyPropertyPatch(ChangeContext, () => w.TargetContext);
				wrapper.ChangeContext = w;
			}

			if (AirSortie != null)
			{
				using (loader.logger.BeginScope($"AirSortie:"))
				{
					var w = new AirSortieAttributesWrapper(wrapper.AirSortie);
					AirSortie.Apply(loader, w, null);
					wrapper.AirSortie = w;
				}
			}

			if (Salvage != null)
			{
				using (loader.logger.BeginScope($"Salvage:"))
				{
					var w = new SalvageAttributesWrapper(wrapper.Salvage);
					Salvage.Apply(loader, w, null);
					wrapper.Salvage = w;
				}
			}

			if (ApplyStatusEffect.Count > 0)
			{
				using (loader.logger.BeginScope($"ApplyStatusEffect:"))
				{
					var w = new ApplyStatusEffectAttributesWrapper(wrapper.ApplyStatusEffect);

					var statusEffectWrappers = w.StatusEffectsToApply?.Select(x => new StatusEffectAttributesWrapper(x)).ToList() ?? new List<StatusEffectAttributesWrapper>();
					loader.ApplyNamedListPatch(ApplyStatusEffect, statusEffectWrappers, (x) => new StatusEffectAttributesWrapper(x), nameof(StatusEffectAttributes));
					w.StatusEffectsToApply = statusEffectWrappers.ToArray();

					wrapper.ApplyStatusEffect = w;
				}
			}

			if (Repair != null)
			{
				var w = new RepairAttributesWrapper(wrapper.Repair);
				loader.ApplyPropertyPatch(Repair, () => w.WeaponID);
				wrapper.Repair = w;
			}

			if (SelfDestruct != null)
			{
				using (loader.logger.BeginScope($"SelfDestruct:"))
				{
					var w = new SelfDestructAttributesWrapper(wrapper.SelfDestruct);
					SelfDestruct.Apply(loader, w, null);
					wrapper.SelfDestruct = w;
				}
			}

			if (ModifyInventory != null)
			{
				using (loader.logger.BeginScope($"ModifyInventory:"))
				{
					var w = new ModifyInventoryAttributesWrapper(wrapper.ModifyInventory);
					ModifyInventory.Apply(loader, w, null);
					wrapper.ModifyInventory = w;
				}
			}

			if (RequiredResearch != null)
			{
				var w = new ResearchDependenciesAttributesWrapper(wrapper.ResearchDependencies);
				loader.ApplyArrayPropertyPatch(RequiredResearch, w, "RequiredResearch");
				wrapper.ResearchDependencies = w;
			}

			if (ActivationDependencies != null)
			{
				using (loader.logger.BeginScope($"ActivationDependencies:"))
				{
					var w = new ActivationDependenciesAttributesWrapper(wrapper.ActivationDependencies);
					ActivationDependencies.Apply(loader, w, null);
					wrapper.ActivationDependencies = w;
				}
			}

			if (AutoToggleOffConditions != null)
			{
				using (loader.logger.BeginScope($"AutoToggleOffConditions:"))
				{
					var w = new AutoToggleOffConditionsAttributesWrapper(wrapper.AutoToggleOffConditions);
					AutoToggleOffConditions.Apply(loader, w, null);
					wrapper.AutoToggleOffConditions = w;
				}
			}

			if (ChainCasting != null)
			{
				using (loader.logger.BeginScope($"ChainCasting:"))
				{
					var w = new ChainCastingAttributesWrapper(wrapper.ChainCasting);
					ChainCasting.Apply(loader, w, null);
					wrapper.ChainCasting = w;
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
