using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayAnimation : MonoBehaviour
{
    public Animator playButtonAnimator;

    public ReplayButtonIcon replayButtonIcon;

    public GameObject playButtonIconGO;
    public GameObject replayButtonIconGO;

    void Awake()
    {
        if (DataManager.gamePlayed == 1)
        {
            replayButtonIconGO.SetActive(true);
            playButtonIconGO.SetActive(false);
            replayButtonIcon.defaultIcon = replayButtonIcon.replayDefaultIcon;
            replayButtonIcon.pressedIcon = replayButtonIcon.replayPressedIcon;
            playButtonAnimator.SetBool("IsReload", true );
            playButtonAnimator.SetTrigger("PlayButtonAnimation");
        }
    }
}
