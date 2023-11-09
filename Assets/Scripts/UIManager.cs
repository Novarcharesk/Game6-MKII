using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text gemCounterText; // Reference to the UI text for displaying the gem count
    public TMP_Text fruitCounterText; // Reference to the UI text for displaying the fruit count

    private int gemCount = 0;
    private int fruitCount = 0;

    private void Start()
    {
        // Initialize UI elements
        gemCounterText.text = "Gems: " + gemCount;
        fruitCounterText.text = "Fruits: " + fruitCount;
    }

    public void UpdateGemCounter(int newCount)
    {
        gemCount = newCount;
        gemCounterText.text = "Gems: " + gemCount;
    }

    public void UpdateFruitCounter(int newCount)
    {
        fruitCount = newCount;
        fruitCounterText.text = "Fruits: " + fruitCount;
    }
}