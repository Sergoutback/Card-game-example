using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public Animator playButtonAnimator;
    [SerializeField] private SceneSwitcher sceneSwitcher;
    [SerializeField] private CardManager cardManager;
    
    public event Action OnMatchesGameOverSound;
    
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
        OnMatchesGameOverSound?.Invoke();
        StartCoroutine(Delay(2));
        sceneSwitcher.NextScene();
    }

    private IEnumerator Delay(int seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
}
