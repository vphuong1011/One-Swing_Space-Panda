using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// This is the base class for all levels
public class Level : MonoBehaviour {
    
    // The starting location for the player
    [SerializeField] private Transform PlayerStartTransform;

    // The enemy spawn points
    [SerializeField] private List<Transform> EnemySpawnTransforms;

    // Spawn the player and set his location based on the player start
    public void SpawnPlayer()
    {

    }

    // Spawn the enemy and set their location to a specific spawn point
    public void SpawnEnemy(int transformIndex = 0) // set the default to be the first spawn point if one is not specified
    {

    }

    // Spawn an enemy and set their location to an random spawn point
    public void SpawnEnemyAtRandom()
    {

    }
}
