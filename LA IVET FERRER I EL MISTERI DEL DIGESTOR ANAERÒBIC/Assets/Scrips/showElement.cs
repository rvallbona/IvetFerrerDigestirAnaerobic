using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showElement : MonoBehaviour
{
    [SerializeField]
    public GameObject puzzle;
    [SerializeField]
    public GameObject thisCanvas;

    // Start is called before the first frame update
    public void generatePuzzle()
    {
       
        puzzle.SetActive(true);
        thisCanvas.SetActive(false);
    }
}
