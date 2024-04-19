using UnityEngine;
using UnityEngine.UI;

public class ToggleIcon : MonoBehaviour
{
    public Sprite icon1;  
    public Sprite icon2;  
    private Image buttonImage;
    public ToggleGroupController controller;

    void Start()
    {
        buttonImage = GetComponent<Image>();
        SetInactive();
    }

    public void ToggleImage()
    {
        if (buttonImage.sprite == icon1)
        {
            buttonImage.sprite = icon2;
            controller.ActivateToggle(this);  // Notify the controller about a state change
        }
    }

    public void SetInactive()
    {
        buttonImage.sprite = icon1;
    }
}