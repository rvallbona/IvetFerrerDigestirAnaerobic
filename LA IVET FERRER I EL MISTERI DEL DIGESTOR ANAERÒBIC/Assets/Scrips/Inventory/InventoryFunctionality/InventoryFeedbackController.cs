using UnityEngine;
public class InventoryFeedbackController : MonoBehaviour
{
    private float timer;
    [SerializeField] private GameObject itemWarningTextObject;
    public float maxTimeFeedback;
    void Start() { SetTimer(0);}
    void Update() 
    {
        timer += Time.deltaTime;
        if (GetTimer() >= maxTimeFeedback)
        {
            itemTextDesactive();
        }
    }
    public float GetTimer() { return timer; }
    public void SetTimer(float value) { timer = value; }
    public void itemTextActive() { itemWarningTextObject.SetActive(true); }
    public void itemTextDesactive() { itemWarningTextObject.SetActive(false); }
}
