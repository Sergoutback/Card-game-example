using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CardFlipper : MonoBehaviour
{
    public float delay = 2.0f;

    void Start()
    {
        StartCoroutine(ShowChildrenSequentially());
    }

    IEnumerator ShowChildrenSequentially()
    {
        if (transform.childCount < 2)
        {
            Debug.LogError("Insufficient children attached to the GameObject");
            yield break;
        }

        // Show first child object
        Transform frontImage = transform.GetChild(0);
        frontImage.gameObject.SetActive(true);

        // Hide all other child objects
        for (int i = 1; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }

        // Waiting before showing the next item
        yield return new WaitForSeconds(delay);

        // Hide first child object
        frontImage.gameObject.SetActive(false);

        // Show second child object
        Transform backImage = transform.GetChild(1);
        backImage.gameObject.SetActive(true);
    }
}