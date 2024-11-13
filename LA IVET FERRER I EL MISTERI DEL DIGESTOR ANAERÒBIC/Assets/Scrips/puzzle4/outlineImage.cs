using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class outlineImage : MonoBehaviour
{
    [SerializeField]
   private Outline outline;

     


    private void Start()
    {
        outline = GetComponent<Outline>();
    }


    public void DesactivarOutline(bool resultado)
    {
        outline.enabled = resultado;
    }
}
