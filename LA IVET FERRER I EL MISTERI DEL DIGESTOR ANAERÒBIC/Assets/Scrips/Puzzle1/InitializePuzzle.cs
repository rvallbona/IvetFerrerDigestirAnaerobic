using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class InitializePuzzle : MonoBehaviour
{
    [SerializeField] private GameObject CanvasPuzzle, InventoryCanvasObject;
    [SerializeField] private PauseController pauseController;
    [SerializeField] private GameController_Puzzle1 gameController;
    [SerializeField] private GameObject[] dontUseObjects;
    private float startPosX, startPosY;
    private bool canInteract, canInteractNoUse;
    private void Start()
    {
        CantInteractNoUse();
    }
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && !gameController.usingCoat && !InventoryCanvasObject.activeInHierarchy && canInteract && canInteractNoUse)
        {
            gameController.warningText.SetActive(true);
            gameController.warningText.gameObject.GetComponent<TextMeshProUGUI>().text = "És necessari portar la Bata";
            gameController.SetTimer(0);
        }
        if (Input.GetMouseButtonDown(0) && gameController.usingCoat && canInteract)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;
            SelectStart();
        }
    }
    private void SelectStart()
    {
        CanvasPuzzle.gameObject.SetActive(true);
        gameController.puzzleIsOn = true;
        pauseController.puzzleCanvasIsOpen = true;
        for (int i = 0; i < dontUseObjects.Length; i++)
        {
            dontUseObjects[i].gameObject.SetActive(false);
        }
        this.gameObject.SetActive(false);
    }
    public void CanInteract()
    {
        canInteract = true;
    }
    public void CantInteract()
    {
        canInteract = false;
    }
    public void CanInteractNoUse()
    {
        canInteractNoUse = true;
    }
    public void CantInteractNoUse()
    {
        canInteractNoUse = false;
    }
}