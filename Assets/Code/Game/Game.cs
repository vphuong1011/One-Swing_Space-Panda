using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour {

    [NonSerialized] public List<Level> Levels = new List<Level>();
    [NonSerialized] public Level CurrentLevel;
    [NonSerialized] public int StartingLevel = 1;

    public void LoadLevel(int levelNumber)
    {
        int levelIndex = levelNumber - 1;
        if (levelIndex >= 0 && Levels.Count > levelIndex)
            CurrentLevel = new Level(levelNumber);
        else
            print("Unable to load level: " + levelIndex.ToString());
    }

    public void EndLevel()
    {       
        if (App.Inst.IsRunning == false)
            return;

        App.Inst.IsRunning = false;
    }

    public void Start()
    {
        App.Inst.IsRunning = true;

        // Load levels from data loader
        Levels = DataLoader.LoadData();

        // Load main menu set
        SetManager.OpenSet<MainMenuSet>();
    }
}
