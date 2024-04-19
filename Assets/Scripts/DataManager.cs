using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager
{
    public static int level;
    public static int rows;
    
    public static void SaveLevel(int level)
    {
        PlayerPrefs.SetInt("PlayerSLevel", level);
        PlayerPrefs.Save();
    }

    public static int LoadLevel()
    {
        return PlayerPrefs.GetInt("PlayerLevel");
    }
    
    public static void SaveRowsCount(int rows)
    {
        PlayerPrefs.SetInt("RowsCount", rows);
        PlayerPrefs.Save();
    }
    
    public static int LoadRowsCount()
    {
        return PlayerPrefs.GetInt("RowsCount");
    }
    
}
