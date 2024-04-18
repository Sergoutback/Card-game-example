using UnityEngine;

public class CardManager : MonoBehaviour
{
    private Card firstCardSelected;

    void OnEnable()
    {
        Card.OnCardSelected += CardSelected;
    }

    void OnDisable()
    {
        Card.OnCardSelected -= CardSelected;
    }

    public void CardSelected(Card selectedCard)
    {
        Debug.Log("SelectedCard name = " + selectedCard);
        if (firstCardSelected == null)
        {
            // If this is the first card selected
            firstCardSelected = selectedCard;
            selectedCard.RevealCard(true); // Opening the card
        }
        else
        {
            // Open second selected card
            selectedCard.RevealCard(true);

            if (firstCardSelected.name == selectedCard.name)
            {
                Debug.Log("firstCardSelected.name = " + firstCardSelected.name);
                Debug.Log("selectedCard.name = " + selectedCard.name);
                
                // If the parents' names are the same, leave the cards open and turn them off
                firstCardSelected.frontImage.SetActive(false);
                selectedCard.frontImage.SetActive(false);
            }
            else
            {
                // If the names do not match, close both cards
                firstCardSelected.backImage.SetActive(true);
                firstCardSelected.frontImage.SetActive(false);
                selectedCard.backImage.SetActive(true);
                selectedCard.frontImage.SetActive(false);
            }

            firstCardSelected = null;
        }
    }
}