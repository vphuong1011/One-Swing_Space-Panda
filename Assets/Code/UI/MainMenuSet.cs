using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSet : Set {

    public GameObject menu = null;
    //booleans
    public static bool gameSetShown = false;
    public  bool gameRunNow = false;
	// Use this for initialization
	void Start ()
    {
        if (gameSetShown == false)
        {
            gameRunNow = false;
            //Added this to show game screen in the main menu.
            Game.Inst.WantsToBeInLoadingState = true;
            SetManager.OpenSet<GameSet>();
        }
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void OnPlayClicked()
    {
        
        CloseSet();     
        gameRunNow = true;      
    }

    // DEBUG: These are just for testing menu flow
    public void OnSettingsClicked()
    {
        gameSetShown = true;
        CloseSet();
        SetManager.OpenSet<SettingsSet>();
    }

    // DEBUG: These are just for testing menu flow
    public void OnHelpClicked()
    {
        gameSetShown = true;
        CloseSet();
         SetManager.OpenSet<HelpSet>();
    }
}
