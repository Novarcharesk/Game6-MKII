using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawners : MonoBehaviour
{
    public GameObject[] crystalPrefabs; // Array of different crystal prefabs
    public GameObject[] fruitPrefabs; // Array of different fruit prefabs
    public Transform friendNPC; // Reference to the friend NPC where the player delivers collectibles
    public float spawnInterval = 5.0f; // Time interval between spawns
    public Transform[] crystalSpawnerPositions; // Array of crystal spawner positions
    public Transform[] fruitSpawnerPositions; // Array of fruit spawner positions
    public float despawnTime = 5.0f; // Time until crystals and fruits despawn

    private int currentFriendshipPoints = 0;

    private void Start()
    {
        // Start spawning crystals and fruits
        InvokeRepeating("SpawnCrystal", 0, spawnInterval);
        InvokeRepeating("SpawnFruit", 0, spawnInterval);
    }

    private void SpawnCrystal()
    {
        // Choose a random crystal spawner position from the array
        int spawnerIndex = Random.Range(0, crystalSpawnerPositions.Length);
        Transform selectedSpawner = crystalSpawnerPositions[spawnerIndex];

        // Choose a random crystal prefab from the array
        int prefabIndex = Random.Range(0, crystalPrefabs.Length);
        GameObject selectedPrefab = crystalPrefabs[prefabIndex];

        // Instantiate the selected crystal at the chosen spawn point
        GameObject newCollectible = Instantiate(selectedPrefab, selectedSpawner.position, Quaternion.identity);

        // Set a timer to destroy the collectible after a specified duration
        Destroy(newCollectible, despawnTime);
    }

    private void SpawnFruit()
    {
        // Choose a random fruit spawner position from the array
        int spawnerIndex = Random.Range(0, fruitSpawnerPositions.Length);
        Transform selectedSpawner = fruitSpawnerPositions[spawnerIndex];

        // Choose a random fruit prefab from the array
        int prefabIndex = Random.Range(0, fruitPrefabs.Length);
        GameObject selectedPrefab = fruitPrefabs[prefabIndex];

        // Instantiate the selected fruit at the chosen spawn point
        GameObject newCollectible = Instantiate(selectedPrefab, selectedSpawner.position, Quaternion.identity);

        // Set a timer to destroy the collectible after a specified duration
        Destroy(newCollectible, despawnTime);
    }
}