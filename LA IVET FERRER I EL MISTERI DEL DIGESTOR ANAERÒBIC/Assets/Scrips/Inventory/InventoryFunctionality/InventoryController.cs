using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField]private InventoryUI inventoryUI;
    private void Start()
    {
        InventoryManager._INVENTORY_MANAGER.onInventoryChangedEventCallback += inventoryUI.OnUpdateInventory;
    }
}
