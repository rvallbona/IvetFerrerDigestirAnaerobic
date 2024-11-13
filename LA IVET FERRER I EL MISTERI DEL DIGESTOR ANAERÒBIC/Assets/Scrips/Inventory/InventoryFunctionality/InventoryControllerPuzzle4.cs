using UnityEngine;

public class InventoryControllerPuzzle4 : MonoBehaviour
{
    [SerializeField]private InventoryUI inventoryUI;
    [SerializeField] private InventoryItemData infoBook;
    private void Start()
    {
        InventoryManager._INVENTORY_MANAGER.onInventoryChangedEventCallback += inventoryUI.OnUpdateInventory;

        InventoryManager._INVENTORY_MANAGER.Add(infoBook);
    }
}
