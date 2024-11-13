using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private GameObject canvasDialogue;
    [SerializeField] private Button Telefono;
    [SerializeField] private TMP_Text text;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField, TextArea(2, 6)] private string[] dialogueLines;
    [SerializeField] private Sprite[] dialogueSprites;

    [SerializeField] private float typeTime;

    private int lineIndex;

    public bool dialogueFinished, dialogueStart;

    [SerializeField] private AudioSource dialogueClip;

    [Header("events")]
    public UnityEvent ActivateWhenFinish;

    void Start()
    {
        dialogueFinished = false;
        if (!dialogueStart)
        {
            StartDialogue();
        }
    }
    void Update()
    {
        if (!dialogueStart && !dialogueFinished)
        {
            StartDialogue();
        }
        if (Input.GetMouseButtonDown(0))
        {
            NextDialogueLine();
        }
    }
    public void StartDialogue()
    {
        dialogueStart = true;
        canvasDialogue.SetActive(true);
        lineIndex = 0;
        Telefono.enabled = false;
        StartCoroutine(ShowDialogue());
    }
    private void NextDialogueLine()
    {
        lineIndex++;
        if (lineIndex < dialogueLines.Length)
        {
            StopAllCoroutines();
            StartCoroutine(ShowDialogue());
        }
        else
        {
            dialogueStart = false;
            canvasDialogue.SetActive(false);
            dialogueFinished = true;
            Telefono.enabled = true;
            this.gameObject.SetActive(false);
            ActivateWhenFinish.Invoke();
        }
    }
    private IEnumerator ShowDialogue()
    {
        text.text = string.Empty;

        for (int i = 0; i < dialogueLines[lineIndex].Length; i++)
        {
            dialogueClip.PlayOneShot(dialogueClip.clip);
            text.text += dialogueLines[lineIndex][i];
            sprite.sprite = dialogueSprites[lineIndex]; // Actualiza el SpriteRenderer

            yield return new WaitForSecondsRealtime(typeTime);
        }
    }
}