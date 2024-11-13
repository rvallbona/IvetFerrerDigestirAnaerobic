using UnityEngine;
public class FeedbackAddingInventory : MonoBehaviour
{
    [SerializeField] private GameObject feedbackObject;
    private void OnDestroy()
    {
        AddingInventory(feedbackObject);
    }
    public void AddingInventory(GameObject gO)
    {
        gO.SetActive(true);
    }
}
