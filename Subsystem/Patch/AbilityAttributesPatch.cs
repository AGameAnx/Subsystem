using Subsystem.Wrappers;
using BBI.Game.Data;
using BBI.Core.Utility.FixedPoint;

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

			var cost = new CostAttributesWrapper(abilityAttributesWrapper.Cost);
			abilityAttributesWrapper.Cost = cost;

			loader.ApplyPropertyPatch(Resource1Cost, () => cost.Resource1Cost);
			loader.ApplyPropertyPatch(Resource2Cost, () => cost.Resource2Cost);
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

		public int? Resource1Cost { get; set; }
		public int? Resource2Cost { get; set; }
	}
}
