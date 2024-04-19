using UnityEngine;
using UnityEngine.Serialization;

public class RandomInstantiate : MonoBehaviour
{
    public int rows;
    
    public Transform parentTransform; 
    
    public GameObject[] allObjects; 
    public GameObject[] objectsToInstantiate;

    void Start()
    {
        int selectedDifficulty = PlayerPrefs.GetInt("SelectedDifficulty", 3); 

        int objectsCount;
        int rowsCount;
        switch (selectedDifficulty)
        {
            case 0:
                objectsCount = 4;
                rows = 2;
                break;
            case 1:
                objectsCount = 6;
                rows = 3;
                break;
            case 2:
                objectsCount = 8;
                rows = 4;
                break;
            case 3:
                objectsCount = 8;
                rows = 4;
                break;
            case 4:
                objectsCount = 8;
                rows = 4;
                break;
            default:
                objectsCount = 8;
                rows = 4;// Just in case something goes wrong
                break;
        }

        SetRowsCount(rows);
        
        objectsToInstantiate = new GameObject[objectsCount];
        for (int i = 0; i < objectsCount; i++)
        {
            objectsToInstantiate[i] = allObjects[i];  // Filling an array with the first N objects
        }

        // Create object instances in first random order
        InstantiateRandomOrder();

        // Create object instances in a second random order
        InstantiateRandomOrder();
    }

    public void UpdateVariable(int objectsToInstantiate)
    {
        this.objectsToInstantiate = new GameObject[objectsToInstantiate];
    }

    void InstantiateRandomOrder()
    {
        GameObject[] instances = new GameObject[objectsToInstantiate.Length];

        // Copy elements to new array for shuffling
        for (int i = 0; i < objectsToInstantiate.Length; i++)
        {
            instances[i] = objectsToInstantiate[i];
        }

        ShuffleArray(instances);

        foreach (GameObject obj in instances)
        {
            Instantiate(obj, parentTransform);
        }
    }

    void ShuffleArray(GameObject[] array)
    {
        for (int i = array.Length - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            GameObject temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
        Debug.Log("ShuffleArray Done!");
    }
    
    public void SetRowsCount(int rows)
    {
        PlayerPrefs.SetInt("RowsCount", rows);
        PlayerPrefs.Save();
    }
}

