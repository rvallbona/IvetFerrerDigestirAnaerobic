using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoController : MonoBehaviour
{
    [SerializeField] private GameObject infoButton, infoText, infoPanel, nextButton, mobilePieces, solutionPieces;
    public void OpenInfoObjects()
    {
        infoButton.gameObject.SetActive(false);
        mobilePieces.gameObject.SetActive(false);
        solutionPieces.gameObject.SetActive(false);
        infoPanel.gameObject.SetActive(true);
        infoText.gameObject.SetActive(true);
        nextButton.gameObject.SetActive(true);
    }
}
