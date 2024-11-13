using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winCount : MonoBehaviour
{   
    [Header("SetUp")]
    [SerializeField] private InventoryItemData itemReference;
    [SerializeField] private GameObject puzzle, blackPieces, pieces, button;   
    [SerializeField] private Dialogue dialogue;

  
    [Header("InfoLevel")]
    [SerializeField] private int currentPoints;
    [SerializeField] private int pointsToWin;
    private DialogueController dialogueController;
    private bool ToDoDialogue = true;
    void Start()
    {
        pointsToWin = puzzle.transform.childCount;
        dialogueController = GameObject.FindGameObjectWithTag("DialogueController").GetComponent<DialogueController>();
    }
    void Update()
    {
        if (currentPoints >= pointsToWin)
        {    
            button.gameObject.SetActive(true);
            Debug.Log("Win");
           /* DoDialogue();
            transform.GetChild(0).gameObject.SetActive(true);
            if (dialogue.dialogueFinished)
            {
                dialogueController.dialoguesActive[7] = false;
            }
           */
        }
    }


    public void addItem()
    {
        InventoryManager._INVENTORY_MANAGER.Add(itemReference);
    }
    public void AddPoints()
    {
        currentPoints++;
    }
    private void DoDialogue()
    {
        if (ToDoDialogue)
        {
            for (int i = 0; i < dialogueController.dialoguesActive.Length; i++)
            {
                dialogueController.dialoguesActive[i] = false;
                dialogueController.dialoguesInfo[i].SetActive(false);
            }
            ToDoDialogue = false;
        }
        dialogueController.dialoguesActive[7] = true;
    }
}
