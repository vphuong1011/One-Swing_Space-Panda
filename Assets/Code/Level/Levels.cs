﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour{
    
    [NonSerialized] public static Level CurrentLevel;
    [NonSerialized] public static int CurrentLevelNumber = 1;

    public static void LoadLevel(string levelName, Action onComplete = null)
    {
        if (CurrentLevelNumber >= 1)
        {
            // Try to create the game object from the prefab in the resources folder (NOTE: the full path will be "Resources/Levels/Level1", etc.)
            GameObject levelGO = ResourceManager.Create("Levels/" + levelName);

            // Check if we successfully loaded the game object
            if (levelGO)
            {
                // Check to make sure the game object has the Level component
                Level level = levelGO.gameObject.GetComponent<Level>();
                if (level)
                {
                    CurrentLevel = level;

                    // Level was successfully loaded so call OnComplete
                    OnLevelLoadComplete();
                    CurrentLevelNumber++; // increases the current level number for bullet speed
                    // Let whoever called this load know we are complete
                    if (onComplete != null)
                        onComplete.Invoke();
                }
            }
        }
        else
        {
            Debug.Log("Unable to load level: " + CurrentLevelNumber.ToString());
            return;
        }

    }

    // Spawn a player and enemy after the level finishes loading
    private static void OnLevelLoadComplete()
    {
        if(CurrentLevel)
        {
            CurrentLevel.SpawnPlayer();
            CurrentLevel.SpawnEnemyAtRandom();
            CurrentLevel.SpawnPropsManager();
            CurrentLevel.AddPropsIntoLevel();
      //      CurrentLevel.AddWeatherIntoLevel();
        }
    }

    // Close the current level
    public static void CloseLevel()
    {
        // Close the current level
        if (CurrentLevel)
            CurrentLevel.Close();
    }
}
