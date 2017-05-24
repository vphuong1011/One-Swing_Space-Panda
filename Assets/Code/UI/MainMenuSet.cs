using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSet : Set {

    public GameObject menu = null;
    //booleans
    public bool reloadedGame = false;
    public  bool gameRunNow = false;
	// Use this for initialization
	void Start ()
    {
            gameRunNow = false; 
            Game.Inst.WantsToBeInLoadingState = true;
            //SetManager.OpenSet<GameSet>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void OnPlayClicked()
    {
        
        CloseSet();     
        gameRunNow = true;
        SetManager.OpenSet<GameSet>();
        // gameSetShown = true;
    }

    // DEBUG: These are just for testing menu flow
    public void OnSettingsClicked()
    {
        CloseSet();
        SetManager.OpenSet<SettingsSet>();
    }

    // DEBUG: These are just for testing menu flow
    public void OnHelpClicked()
    {
        CloseSet();
        SetManager.OpenSet<HelpSet>();
    }
}
