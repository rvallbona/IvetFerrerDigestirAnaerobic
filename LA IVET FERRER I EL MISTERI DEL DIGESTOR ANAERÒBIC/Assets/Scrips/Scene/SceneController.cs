using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SceneManager.LoadScene("ChangeScene");
        }
    }
    public void nextScene(string screene)
    {
        SceneManager.LoadScene(screene);
    }
}
