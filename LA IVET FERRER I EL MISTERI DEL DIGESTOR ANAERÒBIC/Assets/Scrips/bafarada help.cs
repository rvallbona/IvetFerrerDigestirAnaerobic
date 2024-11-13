using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class bafaradahelp : MonoBehaviour
{
    [SerializeField]
    public GameObject bafaradaHelp;
    [SerializeField]
    private TMP_Text texto_bafarada;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void hepl(string texto)
    {

        if (bafaradaHelp.activeSelf == false)
        {
            bafaradaHelp.SetActive(true);

            texto_bafarada.text = texto;
        }
        else
        {
            bafaradaHelp.SetActive(false);  
        }

    }
}
