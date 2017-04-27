using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpSet : Set {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnBackButtonClicked()
    {
        Game.Inst.WantsToBeInWaitState = true;
        //Levels.CloseLevel();

        CloseSet();
        SetManager.OpenSet<MainMenuSet>();
    }

}
