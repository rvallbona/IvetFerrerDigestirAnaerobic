using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
public class GameController_Puzzle1 : MonoBehaviour
{
    GameObject piece;
    [SerializeField] List<GameObject> mobilePieces, solutionPieces;

    float rayDistance;
    bool isPressed, allowsPlay, isWin, piecesOn;
    public bool usingCoat, infoBook;
    int lastPieceOrder, counterCorrectSolutions;

    [HideInInspector] public bool puzzleIsOn = false;

    [SerializeField] float snap;
    [SerializeField] GameObject canvasPuzzle, dialogueCanvas, inventoryCanvas;

    private Vector3 positionObj;

    [SerializeField] PauseController pauseController;

    private DialogueController dialogueController;
    [SerializeField] private Dialogue dialogue;
    private PlayerController player;

    [SerializeField] private OpenInventory openInventory;
    [SerializeField] private InitializePuzzle initPuzzle;
    [SerializeField] private ItemObject itemBata;
    [SerializeField] private GameObject infobookCanvas;
    

    [HideInInspector] public float timer;
    [SerializeField] private float maxTimeWaringText;
    public GameObject warningText;
    [SerializeField] private AudioSource selectPiece, dropPiece;
    private void Start()
    {
        usingCoat = false; infoBook = false;

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
        InfoBook();
        if (puzzleIsOn)
        {
            DisarrangePieces();
            puzzleIsOn = false;
        }
        if (Input.GetMouseButtonDown(0) && allowsPlay)
            SelectPiece();
        if (Input.GetMouseButtonUp(0))
            DropPiece();
        if (isPressed)
            MovePiece();
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
        if (dialogueCanvas.gameObject.activeInHierarchy || infoBook)
        {
            openInventory.CantInteract();
            player.CantInteract();
        }
        else
        {
            openInventory.CanInteract();
            player.CanInteract();
        } 
        if (inventoryCanvas.gameObject.activeInHierarchy || infoBook)
            initPuzzle.CantInteract();
        else
            initPuzzle.CanInteract();
        if (dialogueController.dialogue[1].dialogueFinished && !infoBook)
            itemBata.CanInteract();
        else
            itemBata.CantInteract();
    }
    private void SelectPiece()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Piece"))
            {
                lastPieceOrder++;
                isPressed = true;

                rayDistance = hit.distance;
                piece = hit.collider.gameObject;
                selectPiece.Play();
            }
        }

    }
    private void MovePiece()
    {
        Ray rayo = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 limiteRayo = rayo.GetPoint(rayDistance);
        limiteRayo = new Vector3(limiteRayo.x, limiteRayo.y, 0);
        piece.transform.position = limiteRayo;
    }
    private void DropPiece()
    {
        if (isPressed)
        {
            CheckDrop();
            isPressed = false;
            piece = null;
        }
    }
    public void CheckDrop()
    {
        for (int i = 0; i < solutionPieces.Count; i++)
        {
            if (piece.name == solutionPieces[i].name)
            {
                if (Vector2.Distance(piece.transform.position, solutionPieces[i].transform.position) < snap)
                {
                    piece.transform.position = solutionPieces[i].transform.position;

                    counterCorrectSolutions++;
                    if (counterCorrectSolutions == mobilePieces.Count)
                        isWin = true;
                    piece.GetComponent<BoxCollider2D>().enabled = false;
                    dropPiece.Play();
                    break;
                }
            }
        }
    }
    void DisarrangePieces()
    {
        for (int i = 0; i < mobilePieces.Count; i++)
        {
            mobilePieces[i].transform.position = new Vector3(Random.Range(-8, 8), Random.Range(-3, -1), 0);
        }
        allowsPlay = true;
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
    private void InfoBook()
    {
        //Debug.Log(infoBook);
        Debug.Log(usingCoat);
        if (infoBook)
        {
            infobookCanvas.gameObject.SetActive(true);
        }
        else
        {
            infobookCanvas.gameObject.SetActive(false);
        }
    }
    public void SetInfoBook(bool ib)
    {
        infoBook = ib;
    }
}