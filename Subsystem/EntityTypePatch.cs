﻿using Subsystem.Patch;
using System.Collections.Generic;

namespace Subsystem
{
	public class EntityTypePatch
	{
		public string CloneFrom { get; set; }

		public ExperienceAttributesPatch ExperienceAttributes { get; set; }
		public UnitAttributesPatch UnitAttributes { get; set; }
		public ResearchItemAttributesPatch ResearchItemAttributes { get; set; }
		public UnitHangarAttributesPatch UnitHangarAttributes { get; set; }
		public DetectableAttributesPatch DetectableAttributes { get; set; }
		public UnitMovementAttributesPatch UnitMovementAttributes { get; set; }
		public StatusEffectAttributesPatch StatusEffectAttributes { get; set; }
		public PowerShuntAttributesPatch PowerShuntAttributes { get; set; }
		public ProjectileAttributesPatch ProjectileAttributes { get; set; }
		public ResourceAttributesPatch ResourceAttributes { get; set; }
		public RelicAttributesPatch RelicAttributes { get; set; }
		public TechTreeAttributesPatch TechTreeAttributes { get; set; }

		public Dictionary<string, AbilityAttributesPatch> AbilityAttributes { get; set; } = new Dictionary<string, AbilityAttributesPatch>();
		public Dictionary<string, AbilityViewAttributesPatch> AbilityViewAttributes { get; set; } = new Dictionary<string, AbilityViewAttributesPatch>();

		public Dictionary<string, StorageAttributesPatch> StorageAttributes { get; set; } = new Dictionary<string, StorageAttributesPatch>();
		public Dictionary<string, WeaponAttributesPatch> WeaponAttributes { get; set; } = new Dictionary<string, WeaponAttributesPatch>();
	}
}
