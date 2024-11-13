using UnityEngine;
public class CloseInventory : MonoBehaviour
{
    [SerializeField] GameObject CanvasInventory, openInvetory;
    [SerializeField] PauseController pauseController;

    private float startPosX, startPosY;

    [SerializeField] GameObject[] objectsNoUse;
    public bool isClosed;

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;

            SelectCloseInventory();
        }
    }
    private void SelectCloseInventory()
    {
        CanvasInventory.gameObject.SetActive(false);
        ObjectsNoUse();
        this.gameObject.SetActive(false);
        openInvetory.gameObject.SetActive(true);
        pauseController.inventoryCanvasIsOpen = false;
    }
    public void ObjectsNoUse()
    {
        for (int i = 0; i < objectsNoUse.Length; i++)
        {
            objectsNoUse[i].gameObject.SetActive(true);
        }
    }
}
