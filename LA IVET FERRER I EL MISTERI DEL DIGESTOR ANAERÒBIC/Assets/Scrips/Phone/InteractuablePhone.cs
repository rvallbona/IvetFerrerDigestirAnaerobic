using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InteractuablePhone : MonoBehaviour
{
    [SerializeField] private GameObject dialogueCanvas;
    [SerializeField] private List<Dialogue> dialogueList = new();
    [SerializeField] private int dialagNum;
    public void SelectPhone()
    {
        Debug.Log("SelectPhone");
        dialogueCanvas.SetActive(true);
        dialogueList[dialagNum].gameObject.SetActive(true);
        dialogueList[dialagNum].StartDialogue();
    }
    public void setDialagNum(int num){ dialagNum = num; }
}
