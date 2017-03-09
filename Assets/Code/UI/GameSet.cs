using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSet : Set {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // DEBUG: These are just for testing menu flow
    public void OnWinGameClicked()
    {
        Game.Inst.WantsToBeInWaitState = true;
        Levels.CloseLevel();

        CloseSet();
        SetManager.OpenSet<WinSet>();
    }

    // DEBUG: These are just for testing menu flow
    public void OnLoseGameClicked()
    {
        Game.Inst.WantsToBeInWaitState = true;
        Levels.CloseLevel();

        CloseSet();
        SetManager.OpenSet<LoseSet>();
    }
}
