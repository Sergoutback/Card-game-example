using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleGameObject : MonoBehaviour
{
    [SerializeField]
    private GameObject objectToToggle;
    
    public void ToggleVisibility()
    {
        if (objectToToggle != null)
        {
            objectToToggle.SetActive(!objectToToggle.activeSelf);
        }
    }
}
