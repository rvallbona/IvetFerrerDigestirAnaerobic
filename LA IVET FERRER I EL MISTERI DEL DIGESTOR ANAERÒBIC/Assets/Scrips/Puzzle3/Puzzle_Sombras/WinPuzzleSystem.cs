using UnityEngine;
using UnityEngine.SceneManagement;
public class WinPuzzleSystem : MonoBehaviour
{
    private int pointsToWin, currentPoints;
    [SerializeField] private GameObject puzzle, blackPieces, pieces;

    private DialogueController dialogueController;
    private GameController_Puzzle3 gameController;
    [SerializeField] private Dialogue dialogue;

    private bool ToDoDialogue = true;

    [SerializeField] private GameObject[] winObjects;
    void Start()
    {
        pointsToWin = puzzle.transform.childCount;
        dialogueController = GameObject.FindGameObjectWithTag("DialogueController").GetComponent<DialogueController>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController_Puzzle3>();
        gameController.usingPickaxe = false;
    }
    void Update()
    {
        if (currentPoints >= pointsToWin)
        {
            dialogue.gameObject.SetActive(true);

            for (int i = 0; i < winObjects.Length; i++)
                winObjects[i].SetActive(true);
            blackPieces.gameObject.SetActive(false);
            pieces.gameObject.SetActive(false);
        }
    }
    public void AddPoints()
    {
        currentPoints++;
    }
    public void ChangeScene(string nscene)
    {
        SceneManager.LoadScene(nscene);
    }
}
