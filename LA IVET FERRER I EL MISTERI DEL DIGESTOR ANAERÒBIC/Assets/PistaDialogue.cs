using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistaDialogue : MonoBehaviour
{
    [SerializeField] private DialogueController dialogueController;
    public void Pista(int nPista)
    {
        for (int i = 0; i < dialogueController.dialoguesActive.Length; i++)
        {
            dialogueController.dialoguesActive[i] = false;
            dialogueController.dialoguesInfo[i].SetActive(false);
        }
        if (nPista == 1)
        {
            Debug.Log("Pista 1");
            dialogueController.dialoguesActive[3] = true;
        }
        if (nPista == 2)
        {
            Debug.Log("Pista 2");
            dialogueController.dialoguesActive[4] = true;
        }
        if (nPista == 3)
        {
            Debug.Log("Pista 3");
            dialogueController.dialoguesActive[5] = true;
        }
        if (nPista == 4)
        {
            Debug.Log("Pista 4");
            dialogueController.dialoguesActive[6] = true;
        }
    }
}
