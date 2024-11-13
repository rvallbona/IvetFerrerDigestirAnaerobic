using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryControllerPuzzle3 : MonoBehaviour
{
    [SerializeField]private InventoryUI inventoryUI;
    [SerializeField] private InventoryItemData itemDataPickAxe, itemDataCoordMap, infoBook;
    private void Start()
    {
        InventoryManager._INVENTORY_MANAGER.onInventoryChangedEventCallback += inventoryUI.OnUpdateInventory;

        InventoryManager._INVENTORY_MANAGER.Add(infoBook);
        InventoryManager._INVENTORY_MANAGER.Add(itemDataPickAxe);
        InventoryManager._INVENTORY_MANAGER.Add(itemDataCoordMap);
    }
}
