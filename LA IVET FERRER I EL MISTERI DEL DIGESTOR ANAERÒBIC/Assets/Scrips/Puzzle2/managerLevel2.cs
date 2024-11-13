using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class managerLevel2 : MonoBehaviour
{
    [SerializeField] private GameObject luzUltraviuleta, TextCodi;

    [SerializeField] private bool activeLlinterna;
    [SerializeField] private GameObject pause;


    // Start is called before the first frame update
 

    // Update is called once per frame
    void Update()
    {
       
        if (activeLlinterna)
        {
            luzUltraviuleta.SetActive(true);
        }
        else
        {
            luzUltraviuleta.SetActive(false);   
        }
    }

    public void SetLlinterna()
    {
        if (activeLlinterna)
        {
            activeLlinterna = false;
        }
        else
            activeLlinterna = true;
    }

    public GameObject GetTextCodi()
    {
        return TextCodi;
    }



}
