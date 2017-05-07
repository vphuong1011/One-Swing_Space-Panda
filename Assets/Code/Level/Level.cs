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

    // The object spawn point1
    [SerializeField] private List<Transform> ObjectSpawnPoint1;

    // The object spawn point2
    [SerializeField] private List<Transform> ObjectSpawnPoint2;

    // Spawned characters
    private List<GameObject> SpawnedCharacters = new List<GameObject>();

    // Create reference to the player
    [NonSerialized] public GameObject PlayerGameObject;

    // The enemy in the level
    [NonSerialized] public GameObject CurrentEnemy;

    // The object1 in the level
    [NonSerialized] public GameObject CurrentProp;

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
    public void SpawnPropsAtRandom()
    {
        // Spawn in the an enemy using the ResourceManager
        CurrentProp = ResourceManager.Create("UI/cut_models/SimpleBarrel");

        // Add to spawned characters list so we can clean up later
        SpawnedCharacters.Add(CurrentProp);

        // Get a random valid index
        int randomSpawnIndex = UnityEngine.Random.Range(0, ObjectSpawnPoint1.Count);

        // Set the enemy to the spawn transform index position
        CurrentProp.transform.position = ObjectSpawnPoint1[randomSpawnIndex].position;
    }

    // Clean up all of the spawned in characters
    public void CleanUpCharacters()
    {
        // Iterates through the list of spawned characters and destroy them
        foreach (GameObject character in SpawnedCharacters)
            Destroy(character);
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
