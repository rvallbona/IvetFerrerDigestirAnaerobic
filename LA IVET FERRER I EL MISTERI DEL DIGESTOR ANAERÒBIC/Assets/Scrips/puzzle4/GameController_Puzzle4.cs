using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
public class GameController_Puzzle4 : MonoBehaviour
{
    [SerializeField] GameObject canvasPuzzle, dialogueCanvas, inventoryCanvas;

    private Vector3 positionObj;

    [SerializeField] PauseController pauseController;

    private DialogueController dialogueController;
    [SerializeField] private Dialogue dialogue;
    private PlayerController player;

    [SerializeField] private OpenInventory openInventory;
    [SerializeField] private InitializePuzzle initPuzzle;

    [HideInInspector] public float timer;
    [SerializeField] private float maxTimeWaringText;
    public GameObject warningText;

    private bool isWin;
    private void Start()
    {
        dialogueController = GameObject.FindGameObjectWithTag("DialogueController").GetComponent<DialogueController>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        timer = 0;
        warningText.SetActive(false);
    }
    private void Update()
    {
        Timer();
        WarningTextLogic();
        Interactions();
        Win();
    }
    public float GetTimer() { return timer; }
    public void SetTimer(float ntimer) { timer = ntimer; }
    private void Timer()
    {
        timer += Time.deltaTime;
    }
    private void WarningTextLogic()
    {
        if (timer >= maxTimeWaringText)
        {
            warningText.SetActive(false);
        }
    }
    private void Interactions()
    {
        if (dialogueCanvas.gameObject.activeInHierarchy)
        {
            openInventory.CantInteract();
            player.CantInteract();
        }
        else
        {
            openInventory.CanInteract();
            player.CanInteract();
        } 
        if (inventoryCanvas.gameObject.activeInHierarchy)
            initPuzzle.CantInteract();
        else
            initPuzzle.CanInteract();
    }
    private void Win()
    {
        if (isWin)
        {
            dialogueController.dialoguesInfo[2].gameObject.SetActive(false);
            dialogueController.dialoguesActive[3] = true;
            if (dialogue.dialogueFinished)
            {
                dialogueController.dialoguesActive[3] = false;
            }
        }
    }
}