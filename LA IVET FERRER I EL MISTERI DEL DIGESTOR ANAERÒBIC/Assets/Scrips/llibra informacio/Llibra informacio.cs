using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Llibrainformacio : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Paginas;

    [SerializeField]
    private int index = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextClick()
    {
        
        for(int i = 0; i < Paginas.Length; i++)
        {
            if(Paginas[i].activeInHierarchy == true)
            {
                Debug.Log(Paginas[i].activeSelf);
                if (index >= 8)
                {
                    index = 0;
                    Paginas[0].SetActive(true);
                    Paginas[i].SetActive(false);
                    break;
                }
                else
                {
                    Paginas[i + 1].SetActive(true);
                    index++;
                    Paginas[i].SetActive(false);
                    break;
                }
                
            }
        }
        
       

        
    }

    public void BackClick()
    {
        for (int i = 0; i < Paginas.Length; i++)
        {
            if (Paginas[i].activeInHierarchy == true)
            {
                Debug.Log(Paginas[i].activeSelf);
                if (index <= 0)
                {
                    index = 8;
                    Paginas[8].SetActive(true);
                    Paginas[i].SetActive(false);
                    break;
                }
                else
                {
                    Paginas[i - 1].SetActive(true);
                    index--;
                    Paginas[i].SetActive(false);
                    break;
                }

            }
        }
    }
}
