using UnityEngine;
public class CursorControllerPuzzle3 : MonoBehaviour
{
    [SerializeField] private Texture2D cursorTexture1, cursorTexture2, cursorTexturePico;
    private GameController_Puzzle3 gameController;
    [SerializeField] private GameObject[] quizCanvas;
    private void Start()
    {
        gameController = GetComponent<GameController_Puzzle3>();
        if (!gameController.usingPickaxe)
            SetCursor(cursorTexture1);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !gameController.usingPickaxe)
            SetCursor(cursorTexture2);
        if (Input.GetMouseButtonUp(0) && !gameController.usingPickaxe)
            SetCursor(cursorTexture1);

        if (Input.GetMouseButtonDown(0) && gameController.usingPickaxe)
            SetCursor(cursorTexturePico);

        if (Input.GetMouseButtonUp(0) && gameController.usingPickaxe)
            SetCursor(cursorTexturePico);

        for (int i = 0; i < quizCanvas.Length; i++)
        {
            if (quizCanvas[i].activeInHierarchy && Input.GetMouseButtonUp(0) && gameController.usingPickaxe)
                SetCursor(cursorTexture1);
            else if (quizCanvas[i].activeInHierarchy && Input.GetMouseButtonDown(0) && gameController.usingPickaxe)
                SetCursor(cursorTexture2);
        }
    }
    private void SetCursor(Texture2D cursorTexture) { Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto); }
}
