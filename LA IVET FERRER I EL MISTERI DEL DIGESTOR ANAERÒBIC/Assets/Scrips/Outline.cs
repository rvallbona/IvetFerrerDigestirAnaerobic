using UnityEngine;
using UnityEngine.UI;
public class OutLine : MonoBehaviour
{
    [SerializeField] private Sprite imageToChange;
    [SerializeField] private Sprite imageDefault;
    private void OnMouseEnter()
    {
        this.gameObject.GetComponent<Image>().sprite = imageToChange;
    }
    private void OnMouseExit()
    {
        this.gameObject.GetComponent<Image>().sprite = imageDefault;
    }
}
