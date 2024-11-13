using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryControllerPuzzle2 : MonoBehaviour
{
    [SerializeField]private InventoryUI inventoryUI;
    [SerializeField] private InventoryItemData idLlibre;
    private void Start()
    {
        InventoryManager._INVENTORY_MANAGER.onInventoryChangedEventCallback += inventoryUI.OnUpdateInventory;

        InventoryManager._INVENTORY_MANAGER.Add(idLlibre);
    }
}
