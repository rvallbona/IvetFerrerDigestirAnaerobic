using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaterLogic : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameController_Puzzle3 gm;
    private void Update()
    {
        if (gm.GetstartWaterLogic())
        {
            if (transform.position.y <= 0)
                transform.Translate(Vector2.up * speed * Time.deltaTime);
            if (transform.position.y >= 0)
                ResetScene();
        }
    }
    public void ResetScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentSceneIndex);
    }
}
