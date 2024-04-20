using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ToggleIcon : MonoBehaviour
{
    public Sprite disableLevelIcon;  
    public Sprite enableLevelIcon;  
    public Image buttonImage;
    public ToggleGroupController controller;

    // void Start()
    // {
    //     buttonImage = GetComponent<Image>();
    //     SetInactive();
    // }

    public void ToggleImage()
    {
        if (buttonImage == null)
        {
            buttonImage = GetComponent<Image>();
        }

        if (buttonImage != null && buttonImage.sprite == disableLevelIcon)
        {
            buttonImage.sprite = enableLevelIcon;
        }
        else if (buttonImage != null) 
        {
            buttonImage.sprite = disableLevelIcon;
        }
        controller.ActivateToggle(this); // Notify the controller about a state change
    }

    public void SetInactive()
    {
        buttonImage.sprite = disableLevelIcon;
    }
}