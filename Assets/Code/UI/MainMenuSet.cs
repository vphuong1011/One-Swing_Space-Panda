using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSet : Set {

    //booleans
    public  bool gameRunNow = false;
	// Use this for initialization
	void Start () {
        gameRunNow = false;
        //Added this to show game screen in the main menu.
        Game.Inst.WantsToBeInLoadingState = true;
        SetManager.OpenSet<GameSet>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnPlayClicked()
    {
        
        CloseSet();     
        gameRunNow = true;      
    }

    // DEBUG: These are just for testing menu flow
    public void OnSettingsClicked()
    {
        Game.Inst.WantsToBeInWaitState = true;
       // Levels.CloseLevel();

        CloseSet();
        SetManager.OpenSet<SettingsSet>();
    }

    // DEBUG: These are just for testing menu flow
    public void OnHelpClicked()
    {
        Game.Inst.WantsToBeInWaitState = true;
      //  Levels.CloseLevel();

         CloseSet();
         SetManager.OpenSet<HelpSet>();
    }
}
