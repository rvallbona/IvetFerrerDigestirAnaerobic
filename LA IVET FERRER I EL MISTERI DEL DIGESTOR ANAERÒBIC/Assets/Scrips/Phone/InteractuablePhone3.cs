using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractuablePhone3 : MonoBehaviour
{
    private float startPosX, startPosY;

    private DialogueController dialogueController;
    private void Start()
    {
        dialogueController = GameObject.FindGameObjectWithTag("DialogueController").GetComponent<DialogueController>();
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
            SelectPhone();
        }
    }
    public void SelectPhone()
    {
        //Desactivando dialogo anterior
        dialogueController.dialoguesInfo[0].SetActive(false);
        dialogueController.dialoguesActive[0] = false;

        //Activando nuevo dialogo
        dialogueController.dialoguesActive[1] = true;
        if (!dialogueController.dialoguesActive[0] && dialogueController.dialoguesActive[2])
        {
            dialogueController.dialoguesInfo[1].gameObject.SetActive(false);
            dialogueController.dialoguesActive[1] = false;
        }
        this.gameObject.SetActive(false);
    }
}
