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

    // The weather spawn point
    [SerializeField] private List<Transform> WeatherSpawnPoint;

    // Spawned characters
    private List<GameObject> SpawnedCharacters = new List<GameObject>();

    // Create reference to the player
    [NonSerialized] public GameObject PlayerGameObject;

    // The enemy in the level
    [NonSerialized] public GameObject CurrentEnemy;

    // The prop in the level
    [NonSerialized] public GameObject CurrentProp;

    // The propManager in the level
    [NonSerialized]  public GameObject CurrentPropManager;

    // The prop in the level
    [NonSerialized]  public GameObject CurrentWeather;

    // The number of different objects we can spawn
    const int BUCKET = 1;
    const int POT = 2;
    const int HOUSE = 3;
    const int LAMP = 4;
    const int BARREL = 5;
    const int MAX_OBJECTS = 6;

    const int SNOW = 1;
    const int RAIN = 2;
    const int MAX_Weathers = 3;

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
    public void SpawnBarrelAtRandom(int spawnIndex)
    {
        // Spawn in the barrel using the ResourceManager
        CurrentProp = ResourceManager.Create("UI/cut_models/Simple Prefab/SimpleBarrel");

        // Add to spawned characters list so we can clean up later
        SpawnedCharacters.Add(CurrentProp);

        // Set the barrel to the spawn transform index position
        CurrentProp.transform.position = ObjectSpawnPoint[spawnIndex].position;
    }

    public void SpawnBucketAtRandom(int spawnIndex)
    {
        // Spawn in the bucket using the ResourceManager
        CurrentProp = ResourceManager.Create("UI/cut_models/Simple Prefab/SimpleBucket");

        // Add to spawned characters list so we can clean up later
        SpawnedCharacters.Add(CurrentProp);

        // Set the bucket to the spawn transform index position
        CurrentProp.transform.position = ObjectSpawnPoint[spawnIndex].position;
    }

    public void SpawnPotAtRandom(int spawnIndex)
    {
        // Spawn in the pot using the ResourceManager
        CurrentProp = ResourceManager.Create("UI/cut_models/Simple Prefab/SimplePot");

        // Add to spawned characters list so we can clean up later
        SpawnedCharacters.Add(CurrentProp);

        // Set the pot to the spawn transform index position
        CurrentProp.transform.position = ObjectSpawnPoint[spawnIndex].position;
    }

    public void SpawnSpiritHouseAtRandom(int spawnIndex)
    {
        // Spawn in the spirit house using the ResourceManager
        CurrentProp = ResourceManager.Create("UI/cut_models/Simple Prefab/SimpleSpiritHouse");

        // Add to spawned characters list so we can clean up later
        SpawnedCharacters.Add(CurrentProp);

        // Set the spirit house to the spawn transform index position
        CurrentProp.transform.position = ObjectSpawnPoint[spawnIndex].position;
    }

    public void SpawnStreetLampAtRandom(int spawnIndex)
    {
        // Spawn in the lamp using the ResourceManager
        CurrentProp = ResourceManager.Create("UI/cut_models/Simple Prefab/SimpleStreetLamp");

        // Add to spawned characters list so we can clean up later
        SpawnedCharacters.Add(CurrentProp);

        // Set the lamp to the spawn transform index position
        CurrentProp.transform.position = ObjectSpawnPoint[spawnIndex].position;
    }

    public void AddPropsIntoLevel()
    {
        bool bucketSpawned = false;
        bool potSpawned = false;
        bool houseSpawned = false;
        bool lampSpawned = false;
        bool barrelSpawned = false;

        for (int spawnIndex = 0; spawnIndex < ObjectSpawnPoint.Count; ++spawnIndex)
        {
            switch (UnityEngine.Random.Range(1, MAX_OBJECTS))
            {
                case BUCKET:
                    if (bucketSpawned == false)
                    {
                        SpawnBucketAtRandom(spawnIndex);
                        bucketSpawned = true;
                    }
                    else
                        spawnIndex--;

                    break;
                case POT:
                    if (potSpawned == false)
                    {
                        SpawnPotAtRandom(spawnIndex);
                        potSpawned = true;
                    }
                    else
                        spawnIndex--;

                    break;
                case HOUSE:
                    if (houseSpawned == false)
                    {
                        SpawnSpiritHouseAtRandom(spawnIndex);
                        houseSpawned = true;
                    }
                    else
                        spawnIndex--;

                    break;
                case LAMP:
                    if (lampSpawned == false)
                    {
                        SpawnStreetLampAtRandom(spawnIndex);
                        lampSpawned = true;
                    }
                    else
                        spawnIndex--;

                    break;
                case BARREL:
                    if (barrelSpawned == false)
                    {
                        SpawnBarrelAtRandom(spawnIndex);
                        barrelSpawned = true;
                    }
                    else
                        spawnIndex--;

                    break;
            }
        }
    }

    public void AddWeatherIntoLevel()
    {
        bool snow = false;
        bool rain = false;

        for (int spawnIndex = 0; spawnIndex < WeatherSpawnPoint.Count; ++spawnIndex)
        {
            switch (UnityEngine.Random.Range(1, MAX_Weathers))
            {
                case SNOW:
                    if (snow == false)
                    {
                        SpawnSnowAtRandom(spawnIndex);
                        snow = true;
                    }
                    else
                        spawnIndex--;

                    break;
                case RAIN:
                    if (rain == false)
                    {
                        SpawnRainAtRandom(spawnIndex);
                        rain = true;
                    }
                    else
                        spawnIndex--;

                    break;
            }
        }
    }

    public void SpawnRainAtRandom(int spawnIndex)
    {
        // Spawn in rain using the ResourceManager
        CurrentWeather = ResourceManager.Create("Prefabs/Rain");

        // Add to spawned characters list so we can clean up later
        SpawnedCharacters.Add(CurrentWeather);

        // Set the rain to the spawn transform index position
        CurrentWeather.transform.position = WeatherSpawnPoint[spawnIndex].position;
    }

    public void SpawnSnowAtRandom(int spawnIndex)
    {
        // Spawn in snow using the ResourceManager
        CurrentWeather = ResourceManager.Create("Prefabs/Snow");

        // Add to spawned characters list so we can clean up later
        SpawnedCharacters.Add(CurrentWeather);

        // Set the snow to the spawn transform index position
        CurrentWeather.transform.position = WeatherSpawnPoint[spawnIndex].position;
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
