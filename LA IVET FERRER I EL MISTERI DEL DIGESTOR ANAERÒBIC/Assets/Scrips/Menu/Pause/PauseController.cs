using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseController : MonoBehaviour
{
    [SerializeField] GameObject pauseCanvas, optionsCanvas, gameplayCanvas, puzzleCanvas, inventoryCanvas, infoBook;
    public bool isPaused = false, puzzleCanvasIsOpen = false, inventoryCanvasIsOpen = false;
    public void OpenPauseCanvas()
    {
        Time.timeScale = 0f;
        isPaused = true;
        pauseCanvas.gameObject.SetActive(true);

        gameplayCanvas.gameObject.SetActive(false);

        puzzleCanvas.gameObject.SetActive(false);

        inventoryCanvas.gameObject.SetActive(false);

        infoBook.gameObject.SetActive(false);
    }
    public void ClosePauseCanvas()
    {
        Time.timeScale = 1f;
        isPaused = false;
        pauseCanvas.gameObject.SetActive(false);
        gameplayCanvas.gameObject.SetActive(true);
        if (puzzleCanvasIsOpen)
            puzzleCanvas.gameObject.SetActive(true);
        if (inventoryCanvasIsOpen)
            inventoryCanvas.gameObject.SetActive(true);
    }
    public void OpenOptionsCanvas()
    {
        optionsCanvas.gameObject.SetActive(true);
        pauseCanvas.gameObject.SetActive(false);
    }
    public void CloseOptionsCanvas()
    {
        optionsCanvas.gameObject.SetActive(false);
        pauseCanvas.gameObject.SetActive(true);
    }
    public void Quit()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
