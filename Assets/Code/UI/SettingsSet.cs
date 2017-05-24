﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsSet : Set {
    public AudioSource clickSound;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // DEBUG: These are just for testing menu flow
    public void OnBackButtonClicked()
    {

        clickSound.Play();
        // Levels.CloseLevel();
       CloseSet();
       SetManager.OpenSet<MainMenuSet>();
    }

   
}
