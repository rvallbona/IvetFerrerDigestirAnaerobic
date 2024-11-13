using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class quzRespuesta : MonoBehaviour
{

    [SerializeField] private InventoryItemData itemReference;
    [SerializeField] private quizManger quizManager;

    [SerializeField] private List<GameObject> desatcivat;
    [SerializeField] private List<GameObject> activate;

    [SerializeField] private GameObject phone;

    [SerializeField]
    private List<string> list;

    [SerializeField]
    private List<bool> correctas;




    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private List<GameObject> respuestas = new List<GameObject>();


    private int NumeroDeRespuestas;
    void Start()
    {
       
        NumeroDeRespuestas = 3;
        for (int i = 0; i < NumeroDeRespuestas; i++)
        {
             GameObject temp = Instantiate(prefab, this.transform);
            temp.GetComponent<respuestas>().SetRespuestas(list[i]);
            temp.GetComponent<respuestas>().SetCorrecta(correctas[i]);

            respuestas.Add(temp);
        }
    }

    public void DesactivaRespostas()
    {
        for (int i = 0; i < respuestas.Count; i++)
        {
            if (respuestas[i].GetComponent<respuestas>().getSeleccionada())
            {
                respuestas[i].GetComponent<respuestas>().setSelectionada();
            }
           
        }
    }
    public void seeCorrecta()
    {
        for(int i = 0; i < respuestas.Count; i++)
        {
            if (respuestas[i].GetComponent<respuestas>().getCorrecta() == true && respuestas[i].GetComponent<respuestas>().getSeleccionada() == true)
            {
                for (int j = 0; j < desatcivat.Count; j++)
                {
                    desatcivat[j].SetActive(false);
                    Debug.Log("desactivate");

                }
                if (activate.Count > 0)
                {
                    for (int j = 0; j < activate.Count; j++)
                    {
                        activate[j].SetActive(true);

                    }
                }
                // InventoryManager._INVENTORY_MANAGER.Add(itemReference);
                Debug.Log("generar item");
                quizManager.AddQuizCount();
                return;
            }
         
        }
        SetPhone();
    }

    private void SetPhone()
    {
        if (phone.GetComponent<InteractuablePhone>())
        {
            phone.GetComponent<InteractuablePhone>().SelectPhone();
            Debug.Log("print phone 1");

        }
        else if (phone.GetComponent<InteractuablePhone2>())
        {
            phone.GetComponent<InteractuablePhone2>().SelectPhone();
            Debug.Log("print phone 2");
        }
        else if (phone.GetComponent<InteractuablePhone3>()) {
            Debug.Log("print phone 3");
            phone.GetComponent<InteractuablePhone3>().SelectPhone();
        }
    }
}
