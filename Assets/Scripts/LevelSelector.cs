using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelector : MonoBehaviour
{
    public int difficultyLevel;  // Difficulty level associated with the button

    public void SetDifficulty()
    {
        PlayerPrefs.SetInt("SelectedDifficulty", difficultyLevel);
        PlayerPrefs.Save();
    }
}
