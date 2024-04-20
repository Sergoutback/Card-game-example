using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private CardManager cardManager;
    public AudioController audioController;
    
    private void OnEnable()
    {
        cardManager.OnAllMatchesFound += HandleAllMatchesFound;
    }

    private void OnDisable()
    {
        cardManager.OnAllMatchesFound -= HandleAllMatchesFound;
    }

    private void HandleAllMatchesFound()
    {
        audioController = FindObjectOfType<AudioController>();;
        if (audioController != null)
        {
            StartCoroutine(audioController.PlayEndGameSound());
        }
    }
    
}
