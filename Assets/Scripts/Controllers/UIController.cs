using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public CardManager cardManager;
    public Text movesText;
    public Text matchesText;

    void OnEnable()
    {
        cardManager.OnMovesChanged += UpdateMovesText;
        cardManager.OnMatchesChanged += UpdateMatchesText;
    }

    void OnDisable()
    {
        cardManager.OnMovesChanged -= UpdateMovesText;
        cardManager.OnMatchesChanged -= UpdateMatchesText;
    }

    private void UpdateMovesText(int moves)
    {
        movesText.text = moves.ToString();
    }

    private void UpdateMatchesText(int matches)
    {
        matchesText.text = matches.ToString();;
    }
}