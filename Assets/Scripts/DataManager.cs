using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager
{
    public static int level = 3;
    
    public static void SaveLevel(int level)
    {
        PlayerPrefs.SetInt("PlayerSLevel", level);
        PlayerPrefs.Save();
    }

    public static int LoadLevel()
    {
        return PlayerPrefs.GetInt("PlayerLevel");
    }
    
}
