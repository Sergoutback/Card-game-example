using UnityEngine;
using System;

public class Card : MonoBehaviour
{
    public GameObject frontImage;
    public GameObject backImage;

    public static event Action<Card> OnCardSelected;

    public void OnMouseDown()
    {
        OnCardSelected?.Invoke(this);
    }

    public void RevealCard(bool show)
    {
        frontImage.SetActive(show);
        backImage.SetActive(!show);
    }

    public void DisableCard()
    {
        gameObject.SetActive(false);
    }
}