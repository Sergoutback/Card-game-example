using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Unity.VisualScripting;

public class ToggleGroupController : MonoBehaviour
{
    public List<ToggleIcon> toggles;

    [SerializeField] private GameObject defaultLevel; 

    void Start()
    {
        foreach (var toggle in toggles)
        {
            Image childImage = defaultLevel.GetComponentInChildren<Image>();
            if (toggle.gameObject.name == childImage.name)
            {
                int defaultLevelValue = ExtractNumberFromStringAndConvertToInt(defaultLevel.name);
                Debug.Log("sprite.name " + toggle.GetComponentInChildren<Image>().sprite.name);
                toggle.ToggleImage();
                PlayerPrefs.SetInt("SelectedDifficulty", defaultLevelValue);
                PlayerPrefs.Save();
                break;
            }
        }
        
    }

    public void ActivateToggle(ToggleIcon activeToggle)
    {
        if (toggles != null)
        {
            foreach (var toggle in toggles)
            {
                if (toggle != null && toggle != activeToggle)
                {
                    toggle.SetInactive(); // Deactivate all buttons except the active one
                }
            }
        }
    }
    
    public int ExtractNumberFromStringAndConvertToInt(string input)
    {
        Regex regex = new Regex(@"\d+");
        Match match = regex.Match(input);
        if (match.Success)
        {
            return int.Parse(match.Value); 
        }
        else
        {
            return 0;
        }
    }
}