using BBI.Core;
using BBI.Core.Data;
using BBI.Game.Data;
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
		public readonly StringLogger logger;

		private readonly StringWriter writer;

		public AttributeLoader()
		{
			writer = new StringWriter();
			logger = new StringLogger(writer);
		}

		public void LoadAttributes(EntityTypeCollection entityTypeCollection)
		{
			try
			{
				AttributesPatch attributesPatch = JsonMapper.ToObject<AttributesPatch>(AttributeLoader.GetPatchData());
				ApplyAttributesPatch(entityTypeCollection, attributesPatch);
			}
			catch (Exception e)
			{
				Debug.LogWarning($"[SUBSYSTEM] Error applying patch file: {e}");
				writer.WriteLine();
				writer.WriteLine($"Error applying patch file: {e}");
				File.WriteAllText(Path.Combine(Application.dataPath, "Subsystem.log"), writer.ToString());
			}
		}

		public static string GetPatchData()
		{
			if (AttributeLoader.PatchOverrideData != "")
			{
				return AttributeLoader.PatchOverrideData;
			}
			string result;
			try
			{
				result = File.ReadAllText(Path.Combine(Path.Combine(Application.dataPath, (Application.platform == RuntimePlatform.OSXPlayer) ? "Resources/Data" : ""), "patch.json"));
			}
			catch (Exception)
			{
				Debug.LogWarning(string.Format("[SUBSYSTEM] Patch file not found", new object[0]));
				result = "";
			}
			return result;
		}

		public static bool IsPatchValid(string patch)
		{
			try
			{
				JsonMapper.ToObject<AttributesPatch>(patch);
			}
			catch
			{
				return false;
			}
			return true;
		}

		public void ApplyAttributesPatch(EntityTypeCollection entityTypeCollection, AttributesPatch attributesPatch)
		{
			foreach (var kvp in attributesPatch.Entities)
			{
				var entityTypeName = kvp.Key;
				var entityTypePatch = kvp.Value;

				var entityType = entityTypeCollection.GetEntityType(entityTypeName);

				using (logger.BeginScope($"EntityType: {entityTypeName}"))
				{
					if (entityType == null)
					{
						logger.Log($"NOTICE: EntityType not found");
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

					applyNamedComponentPatch<AbilityAttributes, AbilityAttributesWrapper>(
						entityType, entityTypePatch.AbilityAttributes.ToDictionary(x => x.Key, x => (SubsystemPatch)x.Value), x => new AbilityAttributesWrapper(x));
					applyNamedComponentPatch<StorageAttributes, StorageAttributesWrapper>(
						entityType, entityTypePatch.StorageAttributes.ToDictionary(x => x.Key, x => (SubsystemPatch)x.Value), x => new StorageAttributesWrapper(x));
					applyNamedComponentPatch<WeaponAttributes, WeaponAttributesWrapper>(
						entityType, entityTypePatch.WeaponAttributes.ToDictionary(x => x.Key, x => (SubsystemPatch)x.Value), x => new WeaponAttributesWrapper(x));
				}
			}

			File.WriteAllText(Path.Combine(Application.dataPath, "Subsystem.log"), writer.ToString());
			Debug.Log($"[SUBSYSTEM] Applied attributes patch. See Subsystem.log for details.");
		}

		private void applyUnnamedComponentPatch<TAttributes, TWrapper>(EntityTypeAttributes entityType, SubsystemPatch patch, Func<TAttributes, TWrapper> createWrapper)
			where TAttributes : class
			where TWrapper : TAttributes
		{
			if (patch != null)
				applyComponentPatch(entityType, patch, createWrapper);
		}

		private void applyNamedComponentPatch<TAttributes, TWrapper>(EntityTypeAttributes entityType, Dictionary<string, SubsystemPatch> patch, Func<TAttributes, TWrapper> createWrapper)
			where TAttributes : class
			where TWrapper : TAttributes
		{
			foreach (var kvp in patch)
				applyComponentPatch(entityType, kvp.Value, createWrapper, kvp.Key);
		}

		private void applyComponentPatch<TAttributes, TWrapper>(EntityTypeAttributes entityType, SubsystemPatch patch, Func<TAttributes, TWrapper> createWrapper, string name = null)
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
					logger.Log($"ERROR: {typeof(TAttributes).Name} not found");
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

		public void ApplyListPatch<TWrapper>(Dictionary<string, SubsystemPatch> patch, List<TWrapper> wrappers, Func<TWrapper> createWrapper, string elementName)
			where TWrapper : class
		{
			var parsed = new Dictionary<int, SubsystemPatch>();

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
				var index = kvp.Key;
				var elementPatch = kvp.Value;

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
						if (remove)
						{
							logger.Log("WARNING: Remove flag set for non-existent entry");
							continue;
						}

						logger.Log("(created)");
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
		
		public static string PatchOverrideData { get; set; } = "";
	}
}
