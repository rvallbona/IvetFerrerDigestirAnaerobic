using UnityEngine;
public class FeedbackInventory : MonoBehaviour {
    private float timer;
    void Start(){ timer = 0; }
    void Update(){ timer += Time.deltaTime; if (timer >= 1.5f ) { this.gameObject.SetActive(false); timer = 0; } }
}