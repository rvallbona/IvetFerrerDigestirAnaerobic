using System.Collections;
using System.Collections.Generic;
using TMPro;

using UnityEngine;


public class preguntas : MonoBehaviour
{




    [SerializeField]
    string _preguntas;
  

    [SerializeField]
    private TextMeshProUGUI texto;
    // Start is called before the first frame update
    void Start()
    {
        texto.text = _preguntas;
    }

    // Update is called once per frame
  

   
}
