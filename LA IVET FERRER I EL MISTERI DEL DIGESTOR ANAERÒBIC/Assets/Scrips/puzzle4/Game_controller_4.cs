using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_controller_4 : MonoBehaviour
{
    [SerializeField]
    private GameObject AlbumItem;

    [SerializeField] private GameObject infobookCanvas, dialogueCanvas;
    [HideInInspector] public bool infoBook; 
    [SerializeField] private OpenInventory openInventory;
    //private PlayerController3 player;
    [SerializeField] private InitializePuzzle2[] initPuzzle;

    void Start()
    {
        infoBook = false;
    }

    void Update()
    {
        InfoBook();
        Interactions();
    }
    private void Interactions()
    {
        if (dialogueCanvas.gameObject.activeInHierarchy)
        {
            openInventory.CantInteract();
            //player.CantInteract();
            for (int i = 0; i < initPuzzle.Length; i++)
            {
                initPuzzle[i].CantInteract();
            }
        }
        else
        {
            openInventory.CanInteract();
            //player.CanInteract();
            for (int i = 0; i < initPuzzle.Length; i++)
            {
                initPuzzle[i].CanInteract();
            }
        }
        if (infobookCanvas.gameObject.activeInHierarchy)
        {
            openInventory.CantInteract();
            //player.CantInteract();
            for (int i = 0; i < initPuzzle.Length; i++)
            {
                initPuzzle[i].CantInteract();
            }
        }
        else
        {
            openInventory.CanInteract();
            //player.CanInteract();
            for (int i = 0; i < initPuzzle.Length; i++)
            {
                initPuzzle[i].CanInteract();
            }
        }
    }
    public GameObject getItemAlbum()
    {
        return AlbumItem;  
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
