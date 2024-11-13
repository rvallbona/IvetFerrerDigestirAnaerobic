using UnityEngine;

public class ItemObject : MonoBehaviour
{
    [SerializeField] private InventoryItemData itemData;
    [HideInInspector] public bool pickedUp = false;

    private float startPosX, startPosY;

    private bool canInteract;
    private void Start()
    {
        canInteract = false;
    }
    public void OnHandlePickUp()
    {
        if (!pickedUp)
        {
            InventoryManager._INVENTORY_MANAGER.Add(itemData);
            pickedUp = true;
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && canInteract)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;
            OnHandlePickUp();
        }
    }

    public void GenerateItem()
    {
        InventoryManager._INVENTORY_MANAGER.Add(itemData);
    }
    public void CanInteract()
    {
        canInteract = true;
    }
    public void CantInteract()
    {
        canInteract = false;
    }
}