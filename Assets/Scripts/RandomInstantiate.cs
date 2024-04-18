using UnityEngine;

public class RandomInstantiate : MonoBehaviour
{
    public GameObject[] objectsToInstantiate; // Массив из 8 объектов для инстанциации
    public Transform parentTransform; // Родительский объект для инстанциированных объектов

    void Start()
    {
        // Создать экземпляры объектов в первом случайном порядке
        InstantiateRandomOrder();

        // Создать экземпляры объектов во втором случайном порядке
        InstantiateRandomOrder();
    }

    // Функция для инстанциации объектов в случайном порядке
    void InstantiateRandomOrder()
    {
        GameObject[] instances = new GameObject[objectsToInstantiate.Length];

        // Копировать элементы в новый массив для перемешивания
        for (int i = 0; i < objectsToInstantiate.Length; i++)
        {
            instances[i] = objectsToInstantiate[i];
        }

        // Перемешивание массива
        ShuffleArray(instances);

        // Инстанциация каждого объекта
        foreach (GameObject obj in instances)
        {
            Instantiate(obj, parentTransform);
        }
    }

    // Функция для перемешивания массива
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

