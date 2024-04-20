using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ReplayButtonIcon : ButtonIcon
{
    public Sprite replayDefaultIcon;
    public Sprite replayPressedIcon;
    
    public override void Awake()
    {
        buttonImage = GetComponent<Image>();
        buttonImage.sprite = replayDefaultIcon;
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        buttonImage.sprite = replayPressedIcon;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        buttonImage.sprite = replayDefaultIcon;
    }
}
