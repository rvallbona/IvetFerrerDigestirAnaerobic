using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AnimationMenuButtons : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Sprite normalSprite, hoverSprite;
    private Image buttonImage;
    private TextMeshProUGUI buttonText;
    [SerializeField] private AudioSource selectorSound;
    void Start()
    {
        buttonImage = GetComponent<Image>();
        buttonText = GetComponentInChildren<TextMeshProUGUI>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (hoverSprite != null)
            buttonImage.sprite = hoverSprite;
        if (buttonText != null)
        {
            selectorSound.Play();
            buttonText.color = Color.white;
            buttonText.ForceMeshUpdate();
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (normalSprite != null)
            buttonImage.sprite = normalSprite;
        if (buttonText != null)
        {
            buttonText.color = Color.black;
            buttonText.ForceMeshUpdate();
        }
    }
    public void ClickedSound(AudioSource clicked)
    {
        clicked.Play();
    }
}
