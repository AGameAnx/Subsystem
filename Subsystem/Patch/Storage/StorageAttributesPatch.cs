using Subsystem.Wrappers;
using BBI.Game.Data;
using System.Collections.Generic;
using System.Linq;

namespace Subsystem.Patch
{
	public class StorageAttributesPatch: SubsystemPatch
	{
		protected override void Apply(AttributeLoader loader, object wrapper)
		{
			if (!(wrapper is StorageAttributesWrapper storageAttributesWrapper))
				throw new System.InvalidCastException();

			loader.ApplyPropertyPatch(LinkToPlayerBank, () => storageAttributesWrapper.LinkToPlayerBank);
			loader.ApplyPropertyPatch(IsResourceController, () => storageAttributesWrapper.IsResourceController);

			var loadout = storageAttributesWrapper.InventoryLoadout.ToList();

			foreach (var kvp in InventoryLoadout)
			{
				var inventoryId = kvp.Key;
				var inventoryPatch = kvp.Value;

				using (loader.logger.BeginScope($"InventoryBinding: {inventoryId}"))
				{
					var index = loadout.FindIndex(b => b.InventoryID == inventoryId);

					InventoryAttributesWrapper inventoryAttributesWrapper;

					if (index < 0)
					{
						index = loadout.Count;

						var name = $"SUBSYSTEM-{storageAttributesWrapper.Name}-{inventoryId}";
						loader.logger.Log($"(created InventoryAttributes: {name})");

						inventoryAttributesWrapper = new InventoryAttributesWrapper(
							name: name,
							inventoryId: inventoryId
						);
					}
					else
					{
						var inventoryBinding = loadout[index];
						inventoryAttributesWrapper = new InventoryAttributesWrapper(inventoryBinding.InventoryAttributes);
					}

					inventoryPatch.Apply(loader, inventoryAttributesWrapper, null);

					var newBinding = new InventoryBinding(
						inventoryID: inventoryId,
						inventoryBindingIndex: index,
						inventoryAttributes: inventoryAttributesWrapper
					);

					if (index == loadout.Count)
					{
						loadout.Add(newBinding);
					}
					else
					{
						loadout[index] = newBinding;
					}
				}
			}

			storageAttributesWrapper.InventoryLoadout = loadout.ToArray();
		}

		public bool? LinkToPlayerBank { get; set; }
		public bool? IsResourceController { get; set; }
		public Dictionary<string, InventoryAttributesPatch> InventoryLoadout { get; set; } = new Dictionary<string, InventoryAttributesPatch>();
	}
}
