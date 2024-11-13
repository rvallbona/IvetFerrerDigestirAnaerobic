using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseInteractuable : MonoBehaviour
{
    private float startPosX, startPosY;
    [SerializeField] private PauseController pauseController;
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;
            SelectPause();
        }
    }
    private void SelectPause()
    {
        pauseController.OpenPauseCanvas();
    }
}
