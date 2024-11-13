using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenInventory : MonoBehaviour
{
    [SerializeField] GameObject CanvasInventory,closeInventory;

    [SerializeField] PauseController pauseController;

    private float startPosX, startPosY;

    [SerializeField] GameObject[] objectsNoUse;
    private bool canInteract;
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && canInteract)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;
            SelectInventory();
        }
    }
    private void SelectInventory()
    {
        CanvasInventory.gameObject.SetActive(true);
        for (int i = 0; i < objectsNoUse.Length; i++)
        {
            objectsNoUse[i].gameObject.SetActive(false);
        }
        this.gameObject.SetActive(false);
        closeInventory.gameObject.SetActive(true);

        pauseController.inventoryCanvasIsOpen = true;
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
