using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class respuestas : MonoBehaviour
{
    private int numeroPregunta;
    public string respuesta;
    public bool selectionada = false;
    public bool correcta;

    private GameObject ReferenciaCanvasDialogo;


    [SerializeField]  private TextMeshProUGUI texto;
    [SerializeField] private GameObject Sprite;



 
    public bool getSeleccionada()
    {
        return selectionada;   
    }

    public bool getCorrecta()
    {
        return correcta;
    }
    

    public void SetRespuestas( string PasarRespuesta)
    {
        respuesta = PasarRespuesta;
    }

    public void SetCorrecta(bool pasarSet)
    {
        correcta = pasarSet;
    }

    public void DesactivateAllSelected()
    {
        quzRespuesta parentQuizScript = GetComponentInParent<quzRespuesta>();
    
        if (parentQuizScript != null)
        {
            Debug.Log(parentQuizScript);
            parentQuizScript.DesactivaRespostas();
        }

    }
    public void setSelectionada()
    {
        
        if (!selectionada)
        {
            selectionada = true;
            texto.color = Color.yellow;
            Sprite.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        }
        else
        {
            selectionada = false;
            texto.color = Color.black;
            Sprite.GetComponent<Image>().color = new Color(1, 1, 1, 0);
        }
       
        
    }
    public bool getSelectonada()
    {
        return selectionada;
    }
  
    // Start is called before the first frame update
    void Start()
    {
        numeroPregunta = 3;

        texto.text = respuesta;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
