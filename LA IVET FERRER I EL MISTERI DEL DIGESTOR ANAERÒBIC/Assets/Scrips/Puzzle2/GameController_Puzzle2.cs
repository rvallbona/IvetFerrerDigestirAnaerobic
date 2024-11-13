using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameController_Puzzle2 : MonoBehaviour
{
    [HideInInspector] public float timer;
    [SerializeField] private float maxTimeWaringText;
    public GameObject warningText;

    [SerializeField] private PauseController pauseController;
    [SerializeField] private GameObject dialogueCanvas, inventoryCanvas;
    [SerializeField] private GameObject[] ObjectsToDesactive;
    [SerializeField] private OpenInventory openInventory;
    private PlayerController3 player;
    [SerializeField] private GameObject infobookCanvas;
    [SerializeField] private InitializePuzzle2[] initPuzzle;

    public bool infoBook;

    private bool doFeedback;
    [SerializeField] private GameObject feedbackInventoryText;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController3>();
        timer = 0;
        warningText.SetActive(false);
        doFeedback = true;
        infoBook = false;
    }
    private void Update()
    {
        Interactions();
        Timer();
        InfoBook();
        WarningTextLogic();
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
        if (dialogueCanvas.gameObject.activeInHierarchy || infobookCanvas.gameObject.activeInHierarchy)
        {
            openInventory.CantInteract();
            player.CantInteract();
            for (int i = 0; i < initPuzzle.Length; i++)
            {
                initPuzzle[i].CantInteract();
            }
        }
        else
        {
            openInventory.CanInteract();
            player.CanInteract();
            for (int i = 0; i < initPuzzle.Length; i++)
            {
                initPuzzle[i].CanInteract();
            }
        }
    }
    public void ShowFeedbackInventory(GameObject gO) 
    {
        if (doFeedback)
        {
            gO.SetActive(true);
            doFeedback = false;
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
    public void SetInfoBook(bool ib)
    {
        infoBook = ib;
    }
}