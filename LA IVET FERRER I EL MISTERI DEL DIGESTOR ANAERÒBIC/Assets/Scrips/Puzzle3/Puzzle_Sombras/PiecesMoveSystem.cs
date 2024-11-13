using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiecesMoveSystem : MonoBehaviour
{
    [SerializeField] GameObject correctForm;
    private bool moving, finish, canInteract = true;

    private float startPosX, startPosY;

    private Vector3 resetPosition;
    [SerializeField] private float snapPuzzle = 1.5f;

    void Start()
    {
        resetPosition = this.transform.position;
    }
    void Update()
    {
        if (finish == false)
        {
            if (moving)
            {
                Vector3 mousePos;
                mousePos = Input.mousePosition;
                mousePos = Camera.main.ScreenToWorldPoint(mousePos);

                this.gameObject.transform.position = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, this.gameObject.transform.position.z);
            }
        }
    }
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && canInteract)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.position.x;
            startPosY = mousePos.y - this.transform.position.y;

            moving = true;
            Debug.Log("Moving");
        }
    }
    private void OnMouseUp()
    {
        moving = false;

        if (Mathf.Abs(this.transform.position.x - correctForm.transform.position.x) <= snapPuzzle &&
            Mathf.Abs(this.transform.position.y - correctForm.transform.position.y) <= snapPuzzle)
        {
            this.transform.position = correctForm.transform.position;
            finish = true;

            GameObject.Find("PointsHandler").GetComponent<WinPuzzleSystem>().AddPoints();
            Debug.Log("Correct");
        }
        else
        {
            Debug.Log("Reset");
            this.transform.position = new Vector3(resetPosition.x, resetPosition.y, resetPosition.z);
        }
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
