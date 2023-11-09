using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    public Text gemsCounterText; // Reference to the UI text displaying gems counter
    public Text fruitsCounterText; // Reference to the UI text displaying fruits counter
    public Text friendshipPointsText; // Reference to the UI text displaying friendship points
    public int pointsPerDelivery = 5; // Points awarded per gem or fruit delivery

    private int gemsCounter = 0;
    private int fruitsCounter = 0;
    private int friendshipPoints = 0;

    public void InteractWithDoor()
    {
        // Deduct gems and fruits from the counters
        int totalPoints = (gemsCounter + fruitsCounter) * pointsPerDelivery;
        friendshipPoints += totalPoints;

        // Update the UI text for friendship points
        friendshipPointsText.text = "Friendship Points: " + friendshipPoints;

        // Reset the counters
        gemsCounter = 0;
        fruitsCounter = 0;
        gemsCounterText.text = "Gems: " + gemsCounter;
        fruitsCounterText.text = "Fruits: " + fruitsCounter;
    }

    // You can add methods to increment the gem and fruit counters as they are collected
    public void AddGem()
    {
        gemsCounter++;
        gemsCounterText.text = "Gems: " + gemsCounter;
    }

    public void AddFruit()
    {
        fruitsCounter++;
        fruitsCounterText.text = "Fruits: " + fruitsCounter;
    }
}