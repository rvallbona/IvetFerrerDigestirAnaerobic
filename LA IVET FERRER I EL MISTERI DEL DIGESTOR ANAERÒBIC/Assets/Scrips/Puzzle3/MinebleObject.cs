using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class MinebleObject : MonoBehaviour
{
    [SerializeField] private GameController_Puzzle3 gameController;
    [SerializeField] private GameObject quiz1, quiz2, quiz3, quiz4, notQuiz1, notQuiz2, notQuiz3;
    private float startPosX, startPosY;
    [SerializeField] private GameObject InventoryCanvasObject, CoordMap, dialogueCanvas;
    [SerializeField] private GameObject quizsObject, notQuizsObject;

    [SerializeField] private ParticleSystem particulas1, particulas2, particulas3, particulas4, particulas5, particulas6, particulas7;

    [Header("Events")]
    [SerializeField] UnityEvent ActivateEvents;
    private bool canInteract;
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && !gameController.usingPickaxe && !InventoryCanvasObject.activeInHierarchy && canInteract)
        {
            gameController.warningText.SetActive(true);
            gameController.warningText.gameObject.GetComponent<TextMeshProUGUI>().text = "És necessari utilizar el Pic";
            gameController.SetTimer(0);
        }
        if (Input.GetMouseButtonDown(0) && gameController.usingPickaxe && !InventoryCanvasObject.activeInHierarchy)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;

            if (!dialogueCanvas.activeInHierarchy)
            {
                SelectMineable();
            }
        }
    }
    private void SelectMineable()
    {
        CoordMap.SetActive(false);
        ActivateEvents.Invoke();
        if (this.gameObject.tag == "Quiz1")
        {
            particulas1.Play();
            quiz1.gameObject.SetActive(true);
            gameController.isMinedMineableObjectQuiz1 = true;
            quizsObject.gameObject.SetActive(false);
            notQuizsObject.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }
        if (this.gameObject.tag == "Quiz2")
        {
            particulas2.Play();
            quiz2.gameObject.SetActive(true);
            gameController.isMinedMineableObjectQuiz2 = true;
            quizsObject.gameObject.SetActive(false);
            notQuizsObject.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }
        if (this.gameObject.tag == "Quiz3")
        {
            particulas3.Play();
            quiz3.gameObject.SetActive(true);
            gameController.isMinedMineableObjectQuiz3 = true;
            quizsObject.gameObject.SetActive(false);
            notQuizsObject.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }
        if (this.gameObject.tag == "Quiz4")
        {
            particulas4.Play();
            quiz4.gameObject.SetActive(true);
            gameController.isMinedMineableObjectQuiz4 = true;
            quizsObject.gameObject.SetActive(false);
            notQuizsObject.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }
        if (this.gameObject.tag == "NotQuiz1")
        {
            particulas5.Play();
            notQuiz1.gameObject.SetActive(true);
            gameController.isMinednotMineableObject1 = true;
            this.gameObject.SetActive(false);
        }
        if (this.gameObject.tag == "NotQuiz2")
        {
            particulas6.Play();
            notQuiz2.gameObject.SetActive(true);
            gameController.isMinednotMineableObject2 = true;
            this.gameObject.SetActive(false);
        }
        if (this.gameObject.tag == "NotQuiz3")
        {
            particulas7.Play();
            notQuiz3.gameObject.SetActive(true);
            gameController.isMinednotMineableObject3 = true;
            this.gameObject.SetActive(false);
        }
    }
    public void PlaySound(AudioSource audio) { audio.Play(); }
    public void CanInteract()
    {
        canInteract = true;
    }
    public void CantInteract()
    {
        canInteract = false;
    }
}
