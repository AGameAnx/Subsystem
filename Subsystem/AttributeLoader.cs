using BBI.Core;
using BBI.Core.Data;
using BBI.Game.Data;
using BBI.Unity.Game.Data;
using LitJson;
using Subsystem.Wrappers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using UnityEngine;

namespace Subsystem
{
	public class AttributeLoader
	{
		public StatsSheetSettings statsSheetSettings = new StatsSheetSettings();

		public readonly StringLogger logger;
		private readonly StringWriter writer;

		public static string PatchOverrideData { get; set; } = "";

		public AttributeLoader()
		{
			writer = new StringWriter();
			logger = new StringLogger(writer);
		}

		public void LoadAttributes(EntityTypeCollection entityTypeCollection)
		{
			AttributesPatch attributesPatch = GetPatchObject(GetPatchData());
			if (attributesPatch != null)
			{
				statsSheetSettings = attributesPatch.StatsSheetSettings;

				ApplyAttributesPatch(entityTypeCollection, attributesPatch);

				if (statsSheetSettings.Generate)
				{
					Console.WriteLine("[SUBSYSTEM] Generating stats sheet...");
					new StatsSheetGenerator(statsSheetSettings).Generate(entityTypeCollection);
					Console.WriteLine("[SUBSYSTEM] Stats sheet generated!");
				}
			}
			else
			{
				writer.WriteLine("Patch file empty, not found or json parse failed. See output_log.txt for details");
			}

			File.WriteAllText(Path.Combine(Application.dataPath, "Subsystem.log"), writer.ToString());
		}

		public static AttributesPatch GetPatchObject(string patchData)
		{
			if (patchData.Length > 0)
			{
				try
				{
					return JsonMapper.ToObject<AttributesPatch>(patchData);
				}
				catch (Exception e)
				{
					Debug.LogWarning($"[SUBSYSTEM] Json error: {e}");
				}
			}

			return null;
		}

		public static string GetPatchData()
		{
			if (AttributeLoader.PatchOverrideData != "")
			{
				return AttributeLoader.PatchOverrideData;
			}
			else
			{
				try
				{
					return File.ReadAllText(Path.Combine(Path.Combine(Application.dataPath, (Application.platform == RuntimePlatform.OSXPlayer) ? "Resources/Data" : ""), "patch.json"));
				}
				catch (Exception e)
				{
					Debug.LogWarning("[SUBSYSTEM] Patch file not found or read failed: {e}");
				}
			}
			return "";
		}

		public void ApplyAttributesPatch(EntityTypeCollection entityTypeCollection, AttributesPatch attributesPatch)
		{
			foreach (var kvp in attributesPatch.Entities)
			{
				string entityTypeName = kvp.Key;
				EntityTypePatch entityTypePatch = kvp.Value;

				EntityTypeAttributes entityType;
				if (!entityTypePatch.CloneFrom.IsNullOrEmpty())
				{
					EntityTypeAttributes toClone = entityTypeCollection.GetEntityType(entityTypePatch.CloneFrom);
					if (toClone == null)
					{
						logger.Log($"ERROR: CloneFrom {entityTypePatch.CloneFrom} attributes not found");
						continue;
					}

					entityType = new EntityTypeAttributes(entityTypeName) { Flags = toClone.Flags };

					var attributes = toClone.GetAll<object>();
					foreach (var w in attributes)
						entityType.Add(w);

					entityTypeCollection.Add(entityType);

					logger.BeginScope($"Cloned {entityTypeName} from {entityTypePatch.CloneFrom}").Dispose();
				}
				else
				{
					entityType = entityTypeCollection.GetEntityType(entityTypeName);
				}

				using (logger.BeginScope($"EntityType: {entityTypeName}"))
				{
					if (entityType == null)
					{
						if (entityTypePatch.CloneFrom.IsNullOrEmpty())
							logger.Log("NOTICE: EntityType not found");
						else
							logger.Log("ERROR: Entity cloning failed");
						continue;
					}

					applyUnnamedComponentPatch<ExperienceAttributes, ExperienceAttributesWrapper>(
						entityType, entityTypePatch.ExperienceAttributes, x => new ExperienceAttributesWrapper(x));
					applyUnnamedComponentPatch<UnitAttributes, UnitAttributesWrapper>(
						entityType, entityTypePatch.UnitAttributes, x => new UnitAttributesWrapper(x));
					applyUnnamedComponentPatch<ResearchItemAttributes, ResearchItemAttributesWrapper>(
						entityType, entityTypePatch.ResearchItemAttributes, x => new ResearchItemAttributesWrapper(x));
					applyUnnamedComponentPatch<UnitHangarAttributes, UnitHangarAttributesWrapper>(
						entityType, entityTypePatch.UnitHangarAttributes, x => new UnitHangarAttributesWrapper(x));
					applyUnnamedComponentPatch<DetectableAttributes, DetectableAttributesWrapper>(
						entityType, entityTypePatch.DetectableAttributes, x => new DetectableAttributesWrapper(x));
					applyUnnamedComponentPatch<UnitMovementAttributes, UnitMovementAttributesWrapper>(
						entityType, entityTypePatch.UnitMovementAttributes, x => new UnitMovementAttributesWrapper(x));
					applyUnnamedComponentPatch<StatusEffectAttributes, StatusEffectAttributesWrapper>(
						entityType, entityTypePatch.StatusEffectAttributes, x => new StatusEffectAttributesWrapper(x));
					applyUnnamedComponentPatch<PowerShuntAttributes, PowerShuntAttributesWrapper>(
						entityType, entityTypePatch.PowerShuntAttributes, x => new PowerShuntAttributesWrapper(x));
					applyUnnamedComponentPatch<ProjectileAttributes, ProjectileAttributesWrapper>(
						entityType, entityTypePatch.ProjectileAttributes, x => new ProjectileAttributesWrapper(x));
					applyUnnamedComponentPatch<ResourceAttributes, ResourceAttributesWrapper>(
						entityType, entityTypePatch.ResourceAttributes, x => new ResourceAttributesWrapper(x));
					applyUnnamedComponentPatch<RelicAttributes, RelicAttributesWrapper>(
						entityType, entityTypePatch.RelicAttributes, x => new RelicAttributesWrapper(x));
					applyUnnamedComponentPatch<TechTreeAttributes, TechTreeAttributesWrapper>(
						entityType, entityTypePatch.TechTreeAttributes, x => new TechTreeAttributesWrapper(x));

					applyNamedComponentPatch<AbilityAttributes, AbilityAttributesWrapper, Patch.AbilityAttributesPatch>(
						entityType, entityTypePatch.AbilityAttributes, x => new AbilityAttributesWrapper(x));
					applyNamedComponentPatch<AbilityViewAttributes, AbilityViewAttributes, Patch.AbilityViewAttributesPatch>(
						entityType, entityTypePatch.AbilityViewAttributes, x => x);

					applyNamedComponentPatch<StorageAttributes, StorageAttributesWrapper, Patch.StorageAttributesPatch>(
						entityType, entityTypePatch.StorageAttributes, x => new StorageAttributesWrapper(x));
					applyNamedComponentPatch<WeaponAttributes, WeaponAttributesWrapper, Patch.WeaponAttributesPatch>(
						entityType, entityTypePatch.WeaponAttributes, x => new WeaponAttributesWrapper(x));
				}
			}

			Debug.Log($"[SUBSYSTEM] Applied attributes patch. See Subsystem.log for details.");
		}

		private void applyUnnamedComponentPatch<TAttributes, TWrapper>(
			EntityTypeAttributes entityType, SubsystemPatch patch, Func<TAttributes, TWrapper> createWrapper)
			where TAttributes : class
			where TWrapper : TAttributes
		{
			if (patch != null)
				applyComponentPatch(entityType, patch, createWrapper);
		}
		
		private void applyNamedComponentPatch<TAttributes, TWrapper, TSubsystemPatch>(
			EntityTypeAttributes entityType, Dictionary<string, TSubsystemPatch> patch, Func<TAttributes, TWrapper> createWrapper)
			where TAttributes : class
			where TWrapper : TAttributes
			where TSubsystemPatch : SubsystemPatch
		{
			foreach (var kvp in patch)
				applyComponentPatch(entityType, kvp.Value, createWrapper, kvp.Key);
		}

		private void applyComponentPatch<TAttributes, TWrapper>(
			EntityTypeAttributes entityType, SubsystemPatch patch, Func<TAttributes, TWrapper> createWrapper, string name = null)
			where TAttributes : class
			where TWrapper : TAttributes
		{
			using (logger.BeginScope($"{typeof(TAttributes).Name}: {name}"))
			{
				var attributes = name != null
					? entityType.Get<TAttributes>(name)
					: entityType.Get<TAttributes>();

				if (attributes == null)
				{
					logger.Log($"ERROR: {typeof(TAttributes).Name}" + (name != null ? $": {name}" : "") + " not found");
					return;
				}

				var wrapper = createWrapper(attributes);

				patch.Apply(this, wrapper, entityType);

				entityType.Replace(attributes, wrapper);
			}
		}

		public void ApplyPropertyPatch<TProperty>(TProperty? newValue, ref TProperty value, string fieldName) where TProperty : struct
		{
			if (newValue.HasValue)
				SetValue(newValue.Value, ref value, fieldName);
		}

		public void ApplyPropertyPatch<TProperty>(TProperty newValue, ref TProperty value, string fieldName) where TProperty : class
		{
			if (newValue != null)
				SetValue(newValue, ref value, fieldName);
		}

		public void ApplyPropertyPatch<TProperty>(TProperty? newValue, Expression<Func<TProperty>> expression) where TProperty : struct
		{
			if (newValue.HasValue)
				SetProperty(newValue.Value, expression, x => x);
		}

		public void ApplyPropertyPatch<TProperty>(TProperty newValue, Expression<Func<TProperty>> expression) where TProperty : class
		{
			if (newValue != null)
				SetProperty(newValue, expression, x => x);
		}

		public void ApplyPropertyPatch<TValue, TProperty>(TValue? newValue, Expression<Func<TProperty>> expression, Func<TValue, TProperty> projection) where TValue : struct
		{
			if (newValue.HasValue)
				SetProperty(newValue.Value, expression, projection);
		}

		public void ApplyPropertyPatch<TValue, TProperty>(TValue newValue, Expression<Func<TProperty>> expression, Func<TValue, TProperty> projection) where TValue : class
		{
			if (newValue != null)
				SetProperty(newValue, expression, projection);
		}

		public void SetProperty<TValue, TProperty>(TValue newValue, Expression<Func<TProperty>> expression, Func<TValue, TProperty> projection)
		{
			var value = projection(newValue);

			var accessor = new PropertyAccessor<TProperty>(expression);

			var oldValue = accessor.Get();
			accessor.Set(value);

			logger.Log($"{accessor.Name}: {value} (was: {oldValue})");
		}

		public void SetValue<TValue>(TValue newValue, ref TValue value, string fieldName)
		{
			logger.Log($"{fieldName}: {newValue} (was: {value})");
			value = newValue;
		}

		public void ApplyArrayPropertyPatch<TWrapper, TArrayType>(TArrayType[] patchArray, TWrapper wrapper, string elementName)
		{
			if (patchArray == null)
				return;

			using (logger.BeginScope($"{elementName}:"))
			{
				var wrapperArrayProperty = wrapper.GetType().GetProperty(elementName);
				TArrayType[] wrapperArray = wrapperArrayProperty.GetValue(wrapper, null) as TArrayType[];
				if (wrapperArray == null)
				{
					logger.Log($"old: null");
				}
				else
				{
					var oldValues = wrapperArray.Select(x => x.ToString()).ToArray();
					logger.Log($"old: {string.Join(", ", oldValues)}");
				}
				var newValues = patchArray.Select(x => x.ToString()).ToArray();
				if (newValues.Length == 0)
				{
					logger.Log($"new: null");
					wrapperArrayProperty.SetValue(wrapper, null, null);
				}
				else
				{
					logger.Log($"new: {string.Join(", ", newValues)}");
					wrapperArrayProperty.SetValue(wrapper, patchArray, null);
				}
			}
		}

		public void ApplyListPatch<TWrapper, TPatchType>(
			Dictionary<string, TPatchType> patch, List<TWrapper> wrappers, Func<TWrapper> createWrapper, string elementName, bool disableCreation = false)
			where TWrapper : class
			where TPatchType: SubsystemPatch
		{
			var parsed = new Dictionary<int, TPatchType>();

			foreach (var kvp in patch)
			{
				if (!int.TryParse(kvp.Key, out var index))
				{
					logger.Log($"ERROR: Non-integer key: {kvp.Key}");
					break;
				}

				parsed[index] = kvp.Value;
			}

			foreach (var kvp in parsed.OrderBy(p => p.Key))
			{
				int index = kvp.Key;
				TPatchType elementPatch = kvp.Value;

				using (logger.BeginScope($"{elementName}: {index}"))
				{
					var remove = elementPatch is IRemovable removable && removable.Remove;

					if (index < wrappers.Count)
					{
						if (remove)
						{
							logger.Log("(removed)");
							wrappers[index] = null;
							continue;
						}

						var elementWrapper = wrappers[index];

						elementPatch.Apply(this, elementWrapper, null);

						wrappers[index] = elementWrapper;
					}
					else if (index == wrappers.Count)
					{
						if (disableCreation)
						{
							logger.Log("WARNING: Creation of new elements is disabled for this list");
							continue;
						}

						if (remove)
						{
							logger.Log("WARNING: Remove flag set for non-existent entry");
							continue;
						}

						logger.BeginScope("(created)").Dispose();
						var elementWrapper = createWrapper(); // Deal with INamed?

						elementPatch.Apply(this, elementWrapper, null);

						wrappers.Add(elementWrapper);
					}
					else // if (index > wrappers.Count)
					{
						logger.Log("ERROR: Non-consecutive index");
						continue;
					}
				}
			}

			wrappers.RemoveAll(x => x == null);
		}

		public void ApplyNamedListPatch<TWrapper, TPatchType>(
			Dictionary<string, TPatchType> patch, List<TWrapper> wrappers, Func<string, TWrapper> createWrapper, string elementName)
			where TWrapper : NamedObjectBase
			where TPatchType : SubsystemPatch
		{
			logger.BeginScope($"Existing entry list: {String.Join(", ", wrappers.Select(x => x.Name).ToArray())}").Dispose();

			foreach (var kvp in patch)
			{
				string key = kvp.Key;
				TPatchType elementPatch = kvp.Value;

				using (logger.BeginScope($"{elementName}: {key}"))
				{
					var remove = elementPatch is IRemovable removable && removable.Remove;

					int index = -1;

					foreach (var w in wrappers)
					{
						if (w.Name == key)
						{
							index = wrappers.IndexOf(w);
							break;
						}
					}

					if (index >= 0)
					{
						if (remove)
						{
							logger.Log("(removed)");
							wrappers[index] = null;
							continue;
						}

						var elementWrapper = wrappers[index];

						elementPatch.Apply(this, elementWrapper, null);

						wrappers[index] = elementWrapper;
					}
					else
					{
						if (remove)
						{
							logger.Log("WARNING: Remove flag set for non-existent entry");
							continue;
						}

						logger.BeginScope("(created)").Dispose();
						var elementWrapper = createWrapper(key);

						elementPatch.Apply(this, elementWrapper, null);

						wrappers.Add(elementWrapper);
					}
				}
			}

			wrappers.RemoveAll(x => x == null);
		}
	}
}
