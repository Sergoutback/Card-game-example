using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonIcon : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Sprite defaultIcon;
    public Sprite pressedIcon; 

    public Image buttonImage; // Caching for optimization

    public virtual void Awake()
    {
        buttonImage = GetComponent<Image>();
        buttonImage.sprite = defaultIcon;
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        buttonImage.sprite = pressedIcon;
    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        buttonImage.sprite = defaultIcon;
    }
}
