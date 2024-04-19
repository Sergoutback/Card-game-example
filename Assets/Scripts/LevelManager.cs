using UnityEngine;
using UnityEngine.Serialization;

public class LevelManager : MonoBehaviour
{
    public GameObject[] gameObjects;  // Array of objects to be switched
    public RandomInstantiate randomInstantiate;  
    private int currentLevel = 3;

    private void Start()
    {
        UpdateLevel(3);  
    }

    
    public void UpdateLevel(int newLevel)
    {
        currentLevel = newLevel;
        for (int i = 0; i < gameObjects.Length; i++)
        {
            gameObjects[i].SetActive(i < currentLevel);  // Activate objects depending on level
        }

        if (randomInstantiate != null)
        {
            randomInstantiate.UpdateVariable(currentLevel);
        }
    }
}