using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject optionsCanvas, menuCanvas;
    public void ChangeScene(string nscene)
    {
        SceneManager.LoadScene(nscene);
    }
    public void OpenOptionsCanvas()
    {
        optionsCanvas.gameObject.SetActive(true);
        menuCanvas.gameObject.SetActive(false);
    }
    public void CloseOptionsCanvas()
    {
        optionsCanvas.gameObject.SetActive(false);
        menuCanvas.gameObject.SetActive(true);
    }
    public void Quit()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
