using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcFocLogic : MonoBehaviour
{
    [SerializeField] private float velocity;
    private bool destroyFlayer;
    [SerializeField] Transform dest;
    private Vector3 finishPos;
    [SerializeField] private Dialogue dialogue;
    [SerializeField] private Animator flayerAnimator;
    private Animator focAnimator;
    private DialogueController dialogueController;
    private float timer;
    private bool isbroked;
    [SerializeField] private AudioSource audioSoureBroked;
    private void Start()
    {
        destroyFlayer = false;
        dialogueController = GameObject.FindGameObjectWithTag("DialogueController").GetComponent<DialogueController>();
        focAnimator = this.gameObject.GetComponent<Animator>();
        timer = 0;
        isbroked = false;
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (dialogue.dialogueFinished)
        {
            focAnimator.SetBool("Walking", true);
            finishPos = new Vector3(dest.position.x, dest.position.y, this.transform.position.z);
            transform.position = Vector3.MoveTowards(this.transform.position, dest.position, velocity * Time.deltaTime);
            if (transform.position == finishPos)
            {
                destroyFlayer = true;
                
                dialogueController.dialoguesActive[0] = false;
                dialogueController.dialoguesInfo[0].SetActive(false);

                dialogueController.dialoguesActive[1] = true;
                dialogueController.dialoguesInfo[1].SetActive(true);
                dialogue.dialogueFinished = false;
            }
        }
        if (destroyFlayer)
        {
            focAnimator.SetBool("Destroing",true);
            flayerAnimator.SetBool("Broken", true);
            //Audio
            audioSoureBroked.Play();
            destroyFlayer = false;
            timer = 0;
            isbroked = true;
        }
        if (timer >= 2 && isbroked)
        {
            focAnimator.SetBool("Destroing", false);
            focAnimator.SetBool("Walking", false);
        }
    }
}