using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonIcon : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Sprite defaultIcon;
    [SerializeField] private Sprite pressedIcon; 

    private Image buttonImage; // Caching for optimization

    private void Awake()
    {
        buttonImage = GetComponent<Image>();
        buttonImage.sprite = defaultIcon;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        buttonImage.sprite = pressedIcon;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        buttonImage.sprite = defaultIcon;
    }
}
