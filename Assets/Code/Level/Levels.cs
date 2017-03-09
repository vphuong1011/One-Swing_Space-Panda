using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels {
    
    [NonSerialized] public static Level CurrentLevel;
    [NonSerialized] public static int CurrentLevelNumber = 1;

    public static void LoadLevel(Action onComplete = null)
    {
        if (CurrentLevelNumber >= 1)
        {
            // Try to create the game object from the prefab in the resources folder (NOTE: the full path will be "Resources/Levels/Level1", etc.)
            GameObject levelGO = ResourceManager.Create("Levels/Level" + CurrentLevelNumber);

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

    private static void OnLevelLoadComplete()
    {
        if(CurrentLevel)
        {
            CurrentLevel.SpawnPlayer();
            CurrentLevel.SpawnEnemy();
        }
    }

    public static void CloseLevel()
    {
        if (CurrentLevel)
            GameObject.Destroy(CurrentLevel.gameObject);
    }
}
