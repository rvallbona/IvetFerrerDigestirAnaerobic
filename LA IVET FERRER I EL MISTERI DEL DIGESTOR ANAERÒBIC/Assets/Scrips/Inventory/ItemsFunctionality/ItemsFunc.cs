using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemsFunc : MonoBehaviour, IPointerClickHandler
{
    private ItemSlot item;
    private float startPosX, startPosY;
    [SerializeField]
    private GameController_Puzzle1 GameControllerPuzzle1;
    [SerializeField]
    private GameController_Puzzle2 GameControllerPuzzle2;
    [SerializeField]
    private GameController_Puzzle3 GameControllerPuzzle3;
    [SerializeField]
    private managerLevel2 GameManagerPuzzle2;
    [SerializeField]
    private Game_controller_4 GameControllerPuzzle4;

    private generarlibro libro;

    private TextMeshProUGUI itemToUse;
    private InventoryFeedbackController inventoryFeedback;
    private GameObject inventoryObject;
    private GameObject closeInventory;
    private void Start()
    {
        item = GetComponent<ItemSlot>();
        inventoryFeedback = GameObject.FindGameObjectWithTag("InventoryController").GetComponent<InventoryFeedbackController>();
        GameControllerPuzzle1 = GameObject.Find("GameController").GetComponent<GameController_Puzzle1>();
        GameControllerPuzzle2 = GameObject.Find("GameController").GetComponent<GameController_Puzzle2>();
        GameControllerPuzzle3 = GameObject.Find("GameController").GetComponent<GameController_Puzzle3>();
        GameManagerPuzzle2 = GameObject.Find("GameController").GetComponent<managerLevel2>();
        GameControllerPuzzle4 = GameObject.Find("GameController").GetComponent<Game_controller_4>();
        inventoryObject = GameObject.Find("InventoryCanvas");
        closeInventory = GameObject.Find("CloseInventory");
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Vector3 mousePos = eventData.position;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;

            CheckItem();
        }
    }
    void CheckItem()
    {
        inventoryObject.SetActive(false);
        closeInventory.GetComponent<CloseInventory>().ObjectsNoUse();
        if (item._itemId == "pic")
        {
            if (!GameControllerPuzzle3.usingPickaxe)
            {
                inventoryFeedback.itemTextActive();
                itemToUse = GameObject.FindGameObjectWithTag("itemToUse").GetComponent<TextMeshProUGUI>();

                GameControllerPuzzle3.usingPickaxe = true;
                itemToUse.text = "Utilitzant Pic";

                inventoryFeedback.SetTimer(0);
                Feedback();
            }
            else
            {
                GameControllerPuzzle3.usingPickaxe = false;
                itemToUse.text = "No utilitzant Pic";

                inventoryFeedback.SetTimer(0);
                Feedback();
            }
        }
        else if (item._itemId == "bata")
        {
            if (!GameControllerPuzzle1.usingCoat)
            {
                inventoryFeedback.itemTextActive();
                itemToUse = GameObject.FindGameObjectWithTag("itemToUse").GetComponent<TextMeshProUGUI>();

                GameControllerPuzzle1.usingCoat = true;
                itemToUse.text = "Utilitzant Bata";

                inventoryFeedback.SetTimer(0);
                Feedback();
            }
            else
            {
                GameControllerPuzzle1.usingCoat = false;
                itemToUse.text = "No utilitzant Bata";

                inventoryFeedback.SetTimer(0);
                Feedback();
            }
        }
        else if (item._itemId == "llanterna" && GameManagerPuzzle2 != null)
        {

            inventoryFeedback.itemTextActive();
            itemToUse = GameObject.FindGameObjectWithTag("itemToUse").GetComponent<TextMeshProUGUI>();


            GameManagerPuzzle2.SetLlinterna();
            itemToUse.text = "Utilitzant llinterna";

            inventoryFeedback.SetTimer(0);
            Feedback();
        }
        else if (item._itemId == "Pista ordinador")
        {

            inventoryFeedback.itemTextActive();
            itemToUse = GameObject.FindGameObjectWithTag("itemToUse").GetComponent<TextMeshProUGUI>();

            GameManagerPuzzle2.GetTextCodi().SetActive(true);
            itemToUse.text = "Activant codi";

            inventoryFeedback.SetTimer(0);
            Feedback();

        }
        else if (item._itemId == "mapa_coordenades")
        {
            //Afegir logica del mapa de coordenades
            if (!GameControllerPuzzle3.usingMapCoord)
            {
                inventoryFeedback.itemTextActive();
                itemToUse = GameObject.FindGameObjectWithTag("itemToUse").GetComponent<TextMeshProUGUI>();

                GameControllerPuzzle3.usingMapCoord = true;
                itemToUse.text = "Utilitzant Mapa";

                inventoryFeedback.SetTimer(0);
                Feedback();
            }
            else
            {
                GameControllerPuzzle3.usingMapCoord = false;
                itemToUse.text = "No utilitzant Mapa";

                inventoryFeedback.SetTimer(0);
                Feedback();
            }
        }
        else if (item._itemId == "lineaDelTiempo")
        {
            inventoryFeedback.itemTextActive();
            itemToUse = GameObject.FindGameObjectWithTag("itemToUse").GetComponent<TextMeshProUGUI>();

            GameControllerPuzzle4.getItemAlbum().SetActive(true);
            itemToUse.text = "Album de fotos";

            inventoryFeedback.SetTimer(0);
            Feedback();
        }
        else if (item._itemId == "llibre" && GameControllerPuzzle1 != null)
        {
            if (!GameControllerPuzzle1.infoBook)
            {
                inventoryFeedback.itemTextActive();
                itemToUse = GameObject.FindGameObjectWithTag("itemToUse").GetComponent<TextMeshProUGUI>();

                GameControllerPuzzle1.infoBook = true;
                itemToUse.text = "Utilitzant Llibre";

                inventoryFeedback.SetTimer(0);
                Feedback();
            }
            else
            {
                GameControllerPuzzle1.infoBook = false;
                itemToUse.text = "No utilitzant Llibre";

                inventoryFeedback.SetTimer(0);
                Feedback();
            }

        }
        else if (item._itemId == "llibre" && GameManagerPuzzle2 != null)
        {
            if (!GameControllerPuzzle2.infoBook)
            {
                inventoryFeedback.itemTextActive();
                itemToUse = GameObject.FindGameObjectWithTag("itemToUse").GetComponent<TextMeshProUGUI>();

                GameControllerPuzzle2.infoBook = true;
                itemToUse.text = "Utilitzant Llibre";

                inventoryFeedback.SetTimer(0);
                Feedback();
            }
            else
            {
                GameControllerPuzzle2.infoBook = false;
                itemToUse.text = "No utilitzant Llibre";

                inventoryFeedback.SetTimer(0);
                Feedback();
            }
        }
        else if (item._itemId == "llibre" && GameControllerPuzzle3 != null)
        {
            if (!GameControllerPuzzle3.infoBook)
            {
                inventoryFeedback.itemTextActive();
                itemToUse = GameObject.FindGameObjectWithTag("itemToUse").GetComponent<TextMeshProUGUI>();

                GameControllerPuzzle3.infoBook = true;
                itemToUse.text = "Utilitzant Llibre";

                inventoryFeedback.SetTimer(0);
                Feedback();
            }
            else
            {
                GameControllerPuzzle3.infoBook = false;
                itemToUse.text = "No utilitzant Llibre";

                inventoryFeedback.SetTimer(0);
                Feedback();
            }
        }
        else if (item._itemId == "llibre" && GameControllerPuzzle4 != null)
        {
            if (!GameControllerPuzzle4.infoBook)
            {
                inventoryFeedback.itemTextActive();
                itemToUse = GameObject.FindGameObjectWithTag("itemToUse").GetComponent<TextMeshProUGUI>();

                GameControllerPuzzle4.infoBook = true;
                itemToUse.text = "Utilitzant Llibre";

                inventoryFeedback.SetTimer(0);
                Feedback();
            }
            else
            {
                GameControllerPuzzle4.infoBook = false;
                itemToUse.text = "No utilitzant Llibre";

                inventoryFeedback.SetTimer(0);
                Feedback();
            }
        }
    }
    private void Feedback(){ if (inventoryFeedback.GetTimer() <= inventoryFeedback.maxTimeFeedback){ inventoryFeedback.itemTextActive(); } }
}
