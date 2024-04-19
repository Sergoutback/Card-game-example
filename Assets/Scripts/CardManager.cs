using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CardManager : MonoBehaviour
{
    [SerializeField] private RandomInstantiate randomInstantiate;
    
    private Card firstCardSelected;
    private int movesCount = 0;
    private int matchesCount = 0;
    
    public event Action<int> OnMovesChanged;
    public event Action<int> OnMatchesChanged;
    public event Action OnAllMatchesFound;
    public event Action OnMatchesRevealSound;
    public event Action OnMatchesYesSound;
    public event Action OnMatchesNoSound;

    public int MovesCount 
    {
        get => movesCount;
        private set 
        {
            movesCount = value;
            OnMovesChanged?.Invoke(movesCount);
        }
    }

    public int MatchesCount 
    {
        get { return matchesCount; }
        private set {
            matchesCount = value;
            OnMatchesChanged?.Invoke(matchesCount);
            if (randomInstantiate != null && matchesCount == randomInstantiate.objectsToInstantiate.Length)
            {
                OnAllMatchesFound?.Invoke();
            }
        }
    }

    // Methods for changing counters
    public void IncrementMoves() 
    {
        MovesCount++;
    }

    public void IncrementMatches() 
    {
        MatchesCount++;
    } 

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
            OnMatchesRevealSound?.Invoke();
        }
        else
        {
            // Open the second selected card
            selectedCard.RevealCard(true);

            IncrementMoves(); // Increment move count on every pair attempt
            
            StartCoroutine(ShowSecondCardAndResolve(selectedCard));
        }
    }

    private IEnumerator ShowSecondCardAndResolve(Card selectedCard)
    {
        yield return new WaitForSeconds(1);

        if (firstCardSelected.name == selectedCard.name)
        {
            OnMatchesYesSound?.Invoke();
            Debug.Log("Names match. firstCardSelected.name = " + firstCardSelected.name + ", selectedCard.name = " + selectedCard.name);
            // If the parents' names are the same, turn off the cards
            firstCardSelected.frontImage.SetActive(false);
            selectedCard.frontImage.SetActive(false);
            IncrementMatches();  // Increment matches count on successful match
        }
        else
        {
            OnMatchesNoSound?.Invoke();
            Debug.Log("Names do not match. firstCardSelected.name = " + firstCardSelected.name + ", selectedCard.name = " + selectedCard.name);
            // If the names do not match, close both cards
            firstCardSelected.backImage.SetActive(true);
            firstCardSelected.frontImage.SetActive(false);
            selectedCard.backImage.SetActive(true);
            selectedCard.frontImage.SetActive(false);
        }

        firstCardSelected = null;
        
        Debug.Log($"Total moves: {movesCount}, Total matches: {matchesCount}");
    }
}