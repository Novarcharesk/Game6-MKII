using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionManager : MonoBehaviour
{
    public UIManager uiManager; // Reference to the UI Manager

    private int gemCount = 0;
    private int fruitCount = 0;

    // Method to collect a gem
    public void CollectGem(GameObject gem)
    {
        // Add logic to handle gem collection, e.g., increase gemCount
        gemCount++;

        // Despawn the collected gem
        Destroy(gem);

        // Update the UI counter
        uiManager.UpdateGemCounter(gemCount);

        // Debug message to acknowledge gem collection
        Debug.Log("Gem collected! Total Gems: " + gemCount);
    }

    // Method to collect a fruit
    public void CollectFruit(GameObject fruit)
    {
        // Add logic to handle fruit collection, e.g., increase fruitCount
        fruitCount++;

        // Despawn the collected fruit
        Destroy(fruit);

        // Update the UI counter
        uiManager.UpdateFruitCounter(fruitCount);

        // Debug message to acknowledge fruit collection
        Debug.Log("Fruit collected! Total Fruits: " + fruitCount);
    }
}