using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private SceneSwitcher sceneSwitcher;
    [SerializeField] private CardManager cardManager;
    
    private void OnEnable()
    {
        cardManager.OnAllMatchesFound += HandleAllMatchesFound;
        Debug.Log("SceneController OnAllMatchesFound OnEnable");
    }

    private void OnDisable()
    {
        cardManager.OnAllMatchesFound -= HandleAllMatchesFound;
    }

    private void HandleAllMatchesFound()
    {
        sceneSwitcher.NextScene(); // Переключение на следующую сцену
    }
    
    
}
