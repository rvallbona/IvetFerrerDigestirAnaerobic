using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generarlibro : MonoBehaviour
{
    [SerializeField]
    private InventoryItemData libro;

    public GameObject llibre_canvas;
    // Start is called before the first frame update
    void Start()
    {
        InventoryManager._INVENTORY_MANAGER.Add(libro); 
    }

}
