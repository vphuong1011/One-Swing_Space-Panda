using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

// This is the base class for all levels
public class Level : MonoBehaviour {
    
    // The starting location for the player
    [SerializeField] private Transform PlayerStartTransform;

    // The enemy spawn points
    [SerializeField] private List<Transform> EnemySpawnTransforms;

    // The object spawn point
    [SerializeField] private List<Transform> ObjectSpawnPoint;

    // Spawned characters
    private List<GameObject> SpawnedCharacters = new List<GameObject>();

    // Create reference to the player
    [NonSerialized] public GameObject PlayerGameObject;

    // The enemy in the level
    [NonSerialized] public GameObject CurrentEnemy;

    // The object1 in the level
    [NonSerialized] public GameObject CurrentProp;

    // The object1 in the level
    [NonSerialized]  public GameObject CurrentPropManager;

    // Spawn the player and set his location based on the player start
    public void SpawnPlayer()
    {
        // Create the player using the ResourceManager
        //HEAD
        PlayerGameObject = ResourceManager.Create("Characters/Player");

        //GameObject playerGameObject = ResourceManager.Create("Characters/Player");
        // 9be13d305e3b199da2340eb948ba519f7dfc787b

        // Add to spawned characters list so we can clean up later
        SpawnedCharacters.Add(PlayerGameObject);

        // Set the player to the start position 
        if (PlayerStartTransform)
            PlayerGameObject.transform.position = PlayerStartTransform.position;
    }

    public void SpawnPropsManager()
    {
        // Create manager using the ResourceManager
        PlayerGameObject = ResourceManager.Create("Prefabs/PropsRandomManager");

        // Add to spawned characters list so we can clean up later
        SpawnedCharacters.Add(CurrentPropManager);
    }

    // Spawn the enemy and set their location to a specific spawn point
    public void SpawnEnemy(int transformIndex = 0) // set the default to be the first spawn point if one is not specified
    {
        // Make sure we have a valid transformIndex
        if (transformIndex < EnemySpawnTransforms.Count)
        {
            // Spawn in the an enemy using the ResourceManager
            CurrentEnemy = ResourceManager.Create("Characters/Enemy");

            // Add to spawned characters list so we can clean up later
            SpawnedCharacters.Add(CurrentEnemy);

            // Set the enemy to the spawn transform index position
            CurrentEnemy.transform.position = EnemySpawnTransforms[transformIndex].position;
        }
        else
            Debug.LogWarning("Enemy spawn index outside of valid range.");

    }

    // Spawn an enemy and set their location to an random spawn point
    public void SpawnEnemyAtRandom()
    {
        // Spawn in the an enemy using the ResourceManager
        CurrentEnemy = ResourceManager.Create("Characters/Enemy");

        // Add to spawned characters list so we can clean up later
        SpawnedCharacters.Add(CurrentEnemy);

        // Get a random valid index
        int randomSpawnIndex = UnityEngine.Random.Range(0, EnemySpawnTransforms.Count);

        // Set the enemy to the spawn transform index position
        CurrentEnemy.transform.position = EnemySpawnTransforms[randomSpawnIndex].position;
    }

    // Spawn a prop and set the location to an random spawn point
    public void SpawnBarrelAtRandom()
    {
        // Spawn in the barrel using the ResourceManager
        CurrentProp = ResourceManager.Create("UI/cut_models/Simple Prefab/SimpleBarrel");

        // Add to spawned characters list so we can clean up later
        SpawnedCharacters.Add(CurrentProp);

        // Get a random valid index
        int randomSpawnIndex = UnityEngine.Random.Range(0, ObjectSpawnPoint.Count);

        // Set the barrel to the spawn transform index position
        CurrentProp.transform.position = ObjectSpawnPoint[randomSpawnIndex].position;
    }

    public void SpawnBucketAtRandom()
    {
        // Spawn in the bucket using the ResourceManager
        CurrentProp = ResourceManager.Create("UI/cut_models/Simple Prefab/SimpleBucket");

        // Add to spawned characters list so we can clean up later
        SpawnedCharacters.Add(CurrentProp);

        // Get a random valid index
        int randomSpawnIndex = UnityEngine.Random.Range(0, ObjectSpawnPoint.Count);

        // Set the bucket to the spawn transform index position
        CurrentProp.transform.position = ObjectSpawnPoint[randomSpawnIndex].position;
    }

    public void SpawnPotAtRandom()
    {
        // Spawn in the pot using the ResourceManager
        CurrentProp = ResourceManager.Create("UI/cut_models/Simple Prefab/SimplePot");

        // Add to spawned characters list so we can clean up later
        SpawnedCharacters.Add(CurrentProp);

        // Get a random valid index
        int randomSpawnIndex = UnityEngine.Random.Range(0, ObjectSpawnPoint.Count);

        // Set the pot to the spawn transform index position
        CurrentProp.transform.position = ObjectSpawnPoint[randomSpawnIndex].position;
    }

    public void SpawnSpiritHouseAtRandom()
    {
        // Spawn in the spirit house using the ResourceManager
        CurrentProp = ResourceManager.Create("UI/cut_models/Simple Prefab/SimpleSpiritHouse");

        // Add to spawned characters list so we can clean up later
        SpawnedCharacters.Add(CurrentProp);

        // Get a random valid index
        int randomSpawnIndex = UnityEngine.Random.Range(0, ObjectSpawnPoint.Count);

        // Set the spirit house to the spawn transform index position
        CurrentProp.transform.position = ObjectSpawnPoint[randomSpawnIndex].position;
    }

    public void SpawnStreetLampAtRandom()
    {
        // Spawn in the lamp using the ResourceManager
        CurrentProp = ResourceManager.Create("UI/cut_models/Simple Prefab/SimpleStreetLamp");

        // Add to spawned characters list so we can clean up later
        SpawnedCharacters.Add(CurrentProp);

        // Get a random valid index
        int randomSpawnIndex = UnityEngine.Random.Range(0, ObjectSpawnPoint.Count);

        // Set the lamp to the spawn transform index position
        CurrentProp.transform.position = ObjectSpawnPoint[randomSpawnIndex].position;
    }

    // Clean up all of the spawned in characters
    public void CleanUpCharacters()
    {
        // Iterates through the list of spawned characters and destroy them
        foreach (GameObject character in SpawnedCharacters)
            Destroy(character);

        CurrentEnemy = null;
    }

    // Close the current level
    public void Close()
    {
        // Clean up characters
        CleanUpCharacters();

        // Destroy the game object the level component is attached to
        Destroy(this.gameObject);
    }
}
