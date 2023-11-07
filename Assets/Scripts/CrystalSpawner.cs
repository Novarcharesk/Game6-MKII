using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalSpawner : MonoBehaviour
{
    public GameObject[] crystalPrefabs; // Array of different crystal prefabs
    public Transform friendNPC; // Reference to the friend NPC where the player delivers crystals
    public int targetFriendshipPoints = 20; // The target number of friendship points to win the game
    public float spawnInterval = 3.0f; // Time interval between crystal spawns
    public Transform[] spawnerPositions; // Array of spawner positions
    public float crystalDespawnTime = 5.0f; // Time until crystals despawn

    private int currentFriendshipPoints = 0;

    private void Start()
    {
        // Start spawning crystals
        InvokeRepeating("SpawnCrystal", 0, spawnInterval);
    }

    private void SpawnCrystal()
    {
        if (currentFriendshipPoints < targetFriendshipPoints)
        {
            // Choose a random crystal prefab from the array
            int randomIndex = Random.Range(0, crystalPrefabs.Length);
            GameObject selectedCrystal = crystalPrefabs[randomIndex];

            // Choose a random spawner position from the array
            int spawnerIndex = Random.Range(0, spawnerPositions.Length);
            Transform selectedSpawner = spawnerPositions[spawnerIndex];

            // Instantiate the selected crystal at the chosen spawner's position
            GameObject newCrystal = Instantiate(selectedCrystal, selectedSpawner.position, Quaternion.identity);

            // Set a timer to destroy the crystal after a specified duration
            Destroy(newCrystal, crystalDespawnTime);

            // Update friendship points
            currentFriendshipPoints++;
        }
    }
}