using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private CollectionManager collectionManager;

    private void Start()
    {
        collectionManager = FindObjectOfType<CollectionManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Check the tag of the pickup to determine if it's a gem or fruit
            if (gameObject.CompareTag("Gem"))
            {
                // Call the collection method for gems and pass the pickup GameObject
                collectionManager.CollectGem(gameObject);
            }
            else if (gameObject.CompareTag("Fruit"))
            {
                // Call the collection method for fruits and pass the pickup GameObject
                collectionManager.CollectFruit(gameObject);
            }

            // Despawn the collected pickup
            Destroy(gameObject);
        }
    }
}