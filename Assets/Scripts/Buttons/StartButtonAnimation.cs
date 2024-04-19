using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StartButtonAnimation : MonoBehaviour
{
    public static int gamePlayed;
    
    public Sprite playIcon;
    public Sprite replayIcon;
    
    public Animator playButtonAnimator;

    public SceneSwitcher sceneSwitcher;

    private void OnEnable()
    {
        sceneSwitcher.OnNextScene += StartAnimation;
    }
    
    private void OnDisable()
    {
        sceneSwitcher.OnNextScene -= StartAnimation;
    }
    
    void StartAnimation()
    {
        gamePlayed = PlayerPrefs.GetInt("GamePlayed");
        if (gamePlayed == 1)
        {
            playButtonAnimator.SetTrigger("PlayButtonAnimation");
            
            playIcon = replayIcon;
        }
    }
}
