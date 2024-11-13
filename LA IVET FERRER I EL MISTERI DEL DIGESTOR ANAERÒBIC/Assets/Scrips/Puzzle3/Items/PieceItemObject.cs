using UnityEngine;

public class PieceItemObject : MonoBehaviour
{
    [SerializeField] private InventoryItemData itemData;
    [HideInInspector] public bool pickedUp = false;

    private float startPosX, startPosY;
    private GameController_Puzzle3 GameController;
    private void Start()
    {
        GameController = GameObject.Find("GameController").GetComponent<GameController_Puzzle3>();
    }
    public void OnHandlePickUp()
    {
        if (!pickedUp && GameController.usingPickaxe)
        {
            InventoryManager._INVENTORY_MANAGER.Add(itemData);
            pickedUp = true;
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;
            OnHandlePickUp();
        }
    }

}