using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CodeText : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField InsertCodeText;

    [SerializeField]
    private TMP_Text error;

    [SerializeField]
    private GameObject ExitButton;

    private string code = "967i142A";

    // Start is called before the first frame update


    public void checkPassword()
    {
        if(InsertCodeText.text == code)
        {
            ExitButton.SetActive(true);
            error.gameObject.SetActive(true);
            error.text = "Acceptat";
            error.color = Color.green;
        }
        else
        {
            error.gameObject.SetActive(true);
            error.text = "Error: codigo incorrecto";
            error.color = Color.red;
        }


    }

}
