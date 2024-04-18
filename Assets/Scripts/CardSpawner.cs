using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CardSpawner : MonoBehaviour
{
    public int cardValue;
    public GameObject[] CardPrefab; 
    public Transform parentTransform;

    void Start()
    {
        if (CardPrefab.Length == cardValue && parentTransform != null)
        {
            for (int i = 0; i < CardPrefab.Length; i++)
            {
                if (CardPrefab[i] != null)
                {
                    GameObject instance = Instantiate(CardPrefab[i], parentTransform);

                    //instance.transform.localPosition = CalculatePosition(i);
                    //instance.transform.localRotation = Quaternion.identity;
                    //instance.transform.localScale = Vector3.one;
                }
                else
                {
                    Debug.LogError("Prefab is missing in the array");
                }
            }
        }
        else
        {
            Debug.LogError($"Prefab array must contain {cardValue} elements and parentTransform must not be null");
        }
    }
}
