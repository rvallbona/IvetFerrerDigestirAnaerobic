using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class GameController_Puzzle3 : MonoBehaviour
{
    [HideInInspector] public bool lose, infoBook;
    [HideInInspector] public float timer;
    [SerializeField] private float maxTimeWaringText;
    public GameObject warningText;

    [HideInInspector] public bool usingPickaxe, usingMapCoord;
    [HideInInspector] public int mineableObjectsToActivatePuzzle;
    [SerializeField] private GameObject PuzzleCanvas, MapCoord, dialogueCanvas, inventoryCanvas, infobookCanvas;
    [SerializeField] private GameObject[] ObjectsToDesactive;
    [SerializeField] private OpenInventory openInventory;
    private PlayerController3 player;
    [SerializeField] private PiecesMoveSystem[] piecesShadowPuzzle;
    [SerializeField] private DialogueController dialogueController;
    [SerializeField] private Dialogue dialogue3;
    [SerializeField] private MinebleObject[] minebleObjects;

    [SerializeField] private quizManger quizManger;

    [SerializeField] private GameObject mineableObjectQuiz1, mineableObjectQuiz2, mineableObjectQuiz3, mineableObjectQuiz4, notMinealbeObject1, notMinealbeObject2, notMinealbeObject3;
    [HideInInspector] public bool isMinedMineableObjectQuiz1, isMinedMineableObjectQuiz2, isMinedMineableObjectQuiz3, isMinedMineableObjectQuiz4, isMinednotMineableObject1, isMinednotMineableObject2, isMinednotMineableObject3;

    private bool startWaterLogic;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController3>();
        usingPickaxe = false;
        usingMapCoord = false;
        lose = false; infoBook = false;
        isMinedMineableObjectQuiz1 = false; isMinedMineableObjectQuiz2 = false; isMinedMineableObjectQuiz3 = false; isMinedMineableObjectQuiz4 = false;
        timer = 0;
        warningText.SetActive(false);
        SetstartWaterLogic(false);
    }
    private void Update()
    {
        Interactions();
        Timer();
        WarningTextLogic();
        LoseCheck();
        MineableObjectsWithPickAxe();
        ActivateMapCoord();
        InfoBook();
    } 

    public float GetTimer() { return timer; }
    public bool GetstartWaterLogic() { return startWaterLogic; }
    public void SetTimer(float ntimer) { timer = ntimer; }
    public void SetstartWaterLogic(bool sWaterLogic) { startWaterLogic = sWaterLogic; }
    private void Timer() { timer += Time.deltaTime; }
    private void WarningTextLogic()
    {
        if (timer >= maxTimeWaringText)
        {
            warningText.SetActive(false);
        }
    }
    private void LoseCheck()
    {
        if (lose)
            print("LOSE");
    }
    private void MineableObjectsWithPickAxe()
    {
        if (quizManger.quizSolved == 4)
        {
            PuzzleCanvas.gameObject.SetActive(true);
            dialogueController.dialoguesActive[2] = true;
            if (dialogue3.dialogueFinished)
                dialogueController.dialoguesActive[2] = false;
            usingMapCoord = false;
            for (int i = 0; i < ObjectsToDesactive.Length; i++)
            {
                ObjectsToDesactive[i].SetActive(false);
            }
        }
    }
    private void ActivateMapCoord()
    {
        if (usingMapCoord)
        {
            MapCoord.gameObject.SetActive(true);

            if (!isMinedMineableObjectQuiz1)
                mineableObjectQuiz1.SetActive(true);
            else if (isMinedMineableObjectQuiz1)
                mineableObjectQuiz1.SetActive(false);

            if (!isMinedMineableObjectQuiz2)
                mineableObjectQuiz2.SetActive(true);
            else if (isMinedMineableObjectQuiz2)
                mineableObjectQuiz2.SetActive(false);

            if (!isMinedMineableObjectQuiz3)
                mineableObjectQuiz3.SetActive(true);
            else if (isMinedMineableObjectQuiz3)
                mineableObjectQuiz3.SetActive(false);

            if (!isMinedMineableObjectQuiz4)
                mineableObjectQuiz4.SetActive(true);
            else if (isMinedMineableObjectQuiz4)
                mineableObjectQuiz4.SetActive(false);

            if (!isMinednotMineableObject1)
                notMinealbeObject1.SetActive(true);
            else if (isMinednotMineableObject1)
                notMinealbeObject1.SetActive(false);

            if (!isMinednotMineableObject2)
                notMinealbeObject2.SetActive(true);
            else if (isMinednotMineableObject2)
                notMinealbeObject2.SetActive(false);

            if (!isMinednotMineableObject3)
                notMinealbeObject3.SetActive(true);
            else if (isMinednotMineableObject3)
                notMinealbeObject3.SetActive(false);
        }
        else if (!usingMapCoord)
        {
            MapCoord.gameObject.SetActive(false);
            mineableObjectQuiz1.SetActive(false);
            mineableObjectQuiz2.SetActive(false);
            mineableObjectQuiz3.SetActive(false);
            mineableObjectQuiz4.SetActive(false);

            notMinealbeObject1.SetActive(false);
            notMinealbeObject2.SetActive(false);
            notMinealbeObject3.SetActive(false);
        }
    }
    private void Interactions()
    {
        if (dialogueCanvas.gameObject.activeInHierarchy)
        {
            openInventory.CantInteract();
            player.CantInteract();
            for (int i = 0; i < piecesShadowPuzzle.Length; i++)
            {
                piecesShadowPuzzle[i].CantInteract();
            }
            for (int i = 0; i < minebleObjects.Length; i++)
            {
                minebleObjects[i].CantInteract();
            }
        }
        else
        {
            openInventory.CanInteract();
            player.CanInteract();
            for (int i = 0; i < piecesShadowPuzzle.Length; i++)
            {
                piecesShadowPuzzle[i].CanInteract();
            }
            for (int i = 0; i < minebleObjects.Length; i++)
            {
                minebleObjects[i].CanInteract();
            }
        }
        if (infobookCanvas.gameObject.activeInHierarchy)
        {
            openInventory.CantInteract();
            player.CantInteract();
            for (int i = 0; i < piecesShadowPuzzle.Length; i++)
            {
                piecesShadowPuzzle[i].CantInteract();
            }
            for (int i = 0; i < minebleObjects.Length; i++)
            {
                minebleObjects[i].CantInteract();
            }
        }
        else
        {
            openInventory.CanInteract();
            player.CanInteract();
            for (int i = 0; i < piecesShadowPuzzle.Length; i++)
            {
                piecesShadowPuzzle[i].CanInteract();
            }
            for (int i = 0; i < minebleObjects.Length; i++)
            {
                minebleObjects[i].CanInteract();
            }
        }
    }
    private void InfoBook()
    {
        //Debug.Log(infoBook);
        if (infoBook)
        {
            infobookCanvas.gameObject.SetActive(true);
        }
        else
        {
            infobookCanvas.gameObject.SetActive(false);
        }
    }
    public void SetInfoBook(bool ib) { infoBook = ib; }
}