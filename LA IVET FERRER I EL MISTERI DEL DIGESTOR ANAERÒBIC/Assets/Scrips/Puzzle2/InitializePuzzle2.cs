using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InitializePuzzle2 : MonoBehaviour
{
    [SerializeField] GameObject CanvasPuzzle;
    [SerializeField] PauseController pauseController;
    [SerializeField] GameObject[] dontUseObjects;

    [Header("Events")]
    [SerializeField] UnityEvent ActivateEvents;

    private float startPosX, startPosY;

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
            SelectStart();
        }
    }
    private void SelectStart()
    {
        CanvasPuzzle.gameObject.SetActive(true);
        pauseController.puzzleCanvasIsOpen = true;
        ActivateEvents.Invoke();
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
}