using UnityEngine;
using UnityEngine.UI;
public class PcLogic : MonoBehaviour
{
    [SerializeField] private float timeToPhone;
    private float timer;
    private DialogueController dialogueController;
    private bool stopDo;
    [SerializeField] private Button phone;
    private void Start()
    {
        timer = 0;
        stopDo = false;
        dialogueController = GameObject.FindGameObjectWithTag("DialogueController").GetComponent<DialogueController>();
        phone.enabled = false;
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeToPhone && !stopDo)
        {
            dialogueController.dialoguesActive[0] = true;
            timer = 0;
            stopDo = true;
        }
        else if (timer >= timeToPhone)
        {
            dialogueController.dialoguesActive[0] = false;
        }
    }
}
