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
                rows = 4; // Just in case something goes wrong
                break;
        }

        SetColumnCount(column);
        SetRowsCount(rows);

        objectsToInstantiate = new GameObject[objectsCount];
        for (int i = 0; i < objectsCount; i++)
        {
            objectsToInstantiate[i] = allObjects[i]; // Filling an array with the first N objects
        }

        CheckAndInstantiateRandomOrder();
    }

    private void CheckAndInstantiateRandomOrder()
    {
        InstantiateObjects();
        // Create object instances in first random order
        GameObject[] firstBatch = instances;

        InstantiateObjects();

        // Create object instances in a second random order
        GameObject[] secondBatch = instances;

        // Concatenate both batches into a single array
        concatenatedArray = new GameObject[firstBatch.Length + secondBatch.Length];
        System.Array.Copy(firstBatch, concatenatedArray, firstBatch.Length);
        System.Array.Copy(secondBatch, 0, concatenatedArray, firstBatch.Length, secondBatch.Length);

        ShuffleArray(concatenatedArray);

        if (column == 5 && rows == 4)
        {
            int index = 0;
            foreach (GameObject obj in concatenatedArray)
            {
                if (index == 7)
                {
                    Instantiate(emptyObject, parentTransform);
                }
                else if (index == 11)
                {
                    Instantiate(emptyObject, parentTransform);
                }

                Instantiate(obj, parentTransform);
                index++;
            }
        }
        else
        {
            foreach (GameObject obj in concatenatedArray)
            {
                Instantiate(obj, parentTransform);
            }
        }
    }


    void InstantiateObjects()
    {
        instances = new GameObject[objectsToInstantiate.Length];

        // Copy elements to new array for shuffling
        for (int i = 0; i < objectsToInstantiate.Length; i++)
        {
            instances[i] = objectsToInstantiate[i];
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