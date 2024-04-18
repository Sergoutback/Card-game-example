using UnityEngine;

public class RandomInstantiate : MonoBehaviour
{
    public GameObject[] objectsToInstantiate;
    public Transform parentTransform; 

    private CardManager cardManager;

    void Start()
    {
        // Create object instances in first random order
        InstantiateRandomOrder();

        // Create object instances in a second random order
        InstantiateRandomOrder();
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
}

