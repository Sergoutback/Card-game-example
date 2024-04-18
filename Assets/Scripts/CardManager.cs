using System.Collections;
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
        Debug.Log("SelectedCard name = " + selectedCard.name);
        if (firstCardSelected == null)
        {
            // If this is the first card selected
            firstCardSelected = selectedCard;
            selectedCard.RevealCard(true); // Opening the card
        }
        else
        {
            // Open the second selected card
            selectedCard.RevealCard(true);
            
            StartCoroutine(ShowSecondCardAndResolve(selectedCard));
        }
    }

    private IEnumerator ShowSecondCardAndResolve(Card selectedCard)
    {
        yield return new WaitForSeconds(1);

        if (firstCardSelected.name == selectedCard.name)
        {
            Debug.Log("Names match. firstCardSelected.name = " + firstCardSelected.name + ", selectedCard.name = " + selectedCard.name);
            // If the parents' names are the same, turn off the cards
            firstCardSelected.frontImage.SetActive(false);
            selectedCard.frontImage.SetActive(false);
        }
        else
        {
            Debug.Log("Names do not match. firstCardSelected.name = " + firstCardSelected.name + ", selectedCard.name = " + selectedCard.name);
            // If the names do not match, close both cards
            firstCardSelected.backImage.SetActive(true);
            firstCardSelected.frontImage.SetActive(false);
            selectedCard.backImage.SetActive(true);
            selectedCard.frontImage.SetActive(false);
        }

        firstCardSelected = null;
    }
}