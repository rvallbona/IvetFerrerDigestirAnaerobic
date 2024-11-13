using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    public bool[] dialoguesActive;
    [SerializeField] private GameObject dialogueCanvas;
    [SerializeField] public GameObject[] dialoguesInfo;

    public Dialogue[] dialogue;
    private void Start()
    {
        for (int i = 0; i < dialoguesInfo.Length; i++)
        {
            dialoguesActive[i] = false;
        }
    }
    private void Update()
    {
        for (int i = 0; i < dialoguesInfo.Length; i++)
        {
            if (dialoguesActive[i])
            {
                StartDialogue(i);
            }
        }
    }
    void StartDialogue(int numDialogue)
    {
        {
            dialoguesInfo[numDialogue].SetActive(true);
            dialogueCanvas.gameObject.SetActive(true);
            dialoguesActive[numDialogue] = false;
        }
    }
}
