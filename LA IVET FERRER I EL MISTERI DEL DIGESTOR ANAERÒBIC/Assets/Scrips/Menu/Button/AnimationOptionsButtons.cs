using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AnimationOptionsButtons : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Sprite normalSprite, hoverSprite;
    private Image buttonImage;
    private const float MaxAlpha = 1f;
    private const float MinAlpha = 0f;
    [SerializeField] private AudioSource selectorSound;
    void Start()
    {
        buttonImage = GetComponent<Image>();
        buttonImage.color = new Color(buttonImage.color.r, buttonImage.color.g, buttonImage.color.b, MinAlpha); // Establecer el alpha al mínimo inicialmente
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        selectorSound.Play();
        buttonImage.sprite = hoverSprite;
        buttonImage.color = new Color(buttonImage.color.r, buttonImage.color.g, buttonImage.color.b, MaxAlpha); // Establecer el alpha al máximo al entrar
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        buttonImage.sprite = normalSprite;
        buttonImage.color = new Color(buttonImage.color.r, buttonImage.color.g, buttonImage.color.b, MinAlpha); // Establecer el alpha al mínimo al salir
    }
    public void ClickedSound(AudioSource clicked)
    {
        clicked.Play();
    }
}