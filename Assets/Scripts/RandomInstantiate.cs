using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class RandomInstantiate : MonoBehaviour
{
    public int column;
    public int rows;
    
    public Transform parentTransform; 
    
    public GameObject[] allObjects; 
    public GameObject[] objectsToInstantiate;
    public GameObject emptyObject;

    private GameObject[] instances;
    private GameObject[] concatenatedArray;

    void Start()
    {
        DataManager.gamePlayed = 0;
        
        int selectedDifficulty = PlayerPrefs.GetInt("SelectedDifficulty", 3); 

        int objectsCount = 8; // Default case values
        switch (selectedDifficulty)
        {
            case 0:
                objectsCount = 2;
                column = 2;
                rows = 2;
                break;
            case 1:
                objectsCount = 3;
                column = 2;
                rows = 3;
                break;
            case 2:
                objectsCount = 6;
                column = 4;
                rows = 3;
                break;
            case 3:
                objectsCount = 8;
                column = 4;
                rows = 4;
                break;
            case 4:
                objectsCount = 9;
                column = 5;
                rows = 4;
                break;
            default:
                objectsCount = 8;
                column = 4;
                rows = 4;// Just in case something goes wrong
                break;
        }
        
        SetColumnCount(column);
        SetRowsCount(rows);
        
        objectsToInstantiate = new GameObject[objectsCount];
        for (int i = 0; i < objectsCount; i++)
        {
            objectsToInstantiate[i] = allObjects[i];  // Filling an array with the first N objects
        }

        CheckAndInstantiateRandomOrder();
        
        // Check if we need to add empty objects based on specific conditions
        if (column == 5 && rows == 4)
        {
            AddEmptyObjects();
        }
    }

    private void CheckAndInstantiateRandomOrder()
    {
        InstantiateRandomOrder();
        // Create object instances in first random order
        GameObject[] firstBatch = instances;
        
        InstantiateRandomOrder();

        // Create object instances in a second random order
        GameObject[] secondBatch = instances;

        // Concatenate both batches into a single array
        concatenatedArray = new GameObject[firstBatch.Length + secondBatch.Length];
        System.Array.Copy(firstBatch, concatenatedArray, firstBatch.Length);
        System.Array.Copy(secondBatch, 0, concatenatedArray, firstBatch.Length, secondBatch.Length);
    }


    private void AddEmptyObjects()
    {
        int originalLength = concatenatedArray.Length;
        if (originalLength < 18)
        {
            Debug.LogError("Not enough elements to shift for empty objects.");
            return;
        }

        System.Array.Resize(ref concatenatedArray, originalLength + 2);

        for (int i = originalLength - 1; i >= 12; i--)
        {
            concatenatedArray[i + 1] = concatenatedArray[i];
        }
        //concatenatedArray[12] = Instantiate(emptyObject, parentTransform);

        for (int i = 11; i >= 7; i--)
        {
            concatenatedArray[i + 1] = concatenatedArray[i];
        }
        //concatenatedArray[7] = Instantiate(emptyObject, parentTransform);
    }


    void InstantiateRandomOrder()
    {
        instances = new GameObject[objectsToInstantiate.Length];

        // Copy elements to new array for shuffling
        for (int i = 0; i < objectsToInstantiate.Length; i++)
        {
            instances[i] = objectsToInstantiate[i];
        }

        ShuffleArray(instances);

        if (column == 5 && rows == 4)
        {
            int index = 0;
            foreach (GameObject obj in instances)
            {
                if (index == 7)
                {
                    Instantiate(emptyObject, parentTransform);
                }
                else if (index == 12)
                {
                    Instantiate(emptyObject, parentTransform);
                }
                Instantiate(obj, parentTransform);
                index++;
            }
        }
        else
        {
            foreach (GameObject obj in instances)
            {
                Instantiate(obj, parentTransform);
            }
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
    
    public void SetColumnCount(int column)
    {
        PlayerPrefs.SetInt("ColumnCount", column);
        PlayerPrefs.Save();
    }
    public void SetRowsCount(int rows)
    {
        PlayerPrefs.SetInt("RowsCount", rows);
        PlayerPrefs.Save();
    }
}

