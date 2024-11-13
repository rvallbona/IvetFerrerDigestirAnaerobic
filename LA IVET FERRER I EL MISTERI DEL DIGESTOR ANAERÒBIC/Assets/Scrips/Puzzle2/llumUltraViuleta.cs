using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class llumUltraViuleta : MonoBehaviour
{

    private SpriteRenderer sprteRenderer;
    [SerializeField] private GameObject button, fondo, optionsMenu;
    

    private Collider2D col;

    [SerializeField] private int letersReviled, letersToRevile;

  
    // Start is called before the first frame update

    private void Awake()
    {
        col = GetComponent<Collider2D>();
        letersToRevile = fondo.transform.childCount;
        sprteRenderer = GetComponent<SpriteRenderer>();

    }
   

    // Update is called once per frame
    void Update()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);



        transform.position = new Vector3(worldPosition.x, worldPosition.y, -1);

        ChekOptionsMenu();
        if (letersReviled >= letersToRevile)
        {
            button.SetActive(true);
            col.enabled = false;
        }
   
    }


    private void ChekOptionsMenu()
    {
        if (optionsMenu.activeSelf)
        {
            col.enabled = false;
        }
        else
            col.enabled = true;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {  
    
        if(collision.gameObject.tag == "TextLight")
        {
         TextMeshPro texto = collision.gameObject.GetComponent<TextMeshPro>();
            if (!texto.isActiveAndEnabled)
            {
                letersReviled++;
            }
            texto.enabled = true;
           
            

        }
    }




}
