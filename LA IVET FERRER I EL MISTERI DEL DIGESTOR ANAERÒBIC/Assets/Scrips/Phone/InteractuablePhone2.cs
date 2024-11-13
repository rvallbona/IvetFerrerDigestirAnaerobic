using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InteractuablePhone2 : MonoBehaviour
{

    [SerializeField] private GameObject dialogueCanvas;
    [SerializeField] private List<Dialogue> dialogueList = new();
    [SerializeField] private int dialagNum;


    public void SelectPhone()
    {
       
        dialogueCanvas.SetActive(true);
        dialogueList[dialagNum].gameObject.SetActive(true);
        dialogueList[dialagNum].StartDialogue();
    }

    public void setDialagNum(int num)
    {
        dialagNum = num;
    }

}
