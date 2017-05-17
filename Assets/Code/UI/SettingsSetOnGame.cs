using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsSetOnGame : Set {


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
        Game.Inst.WantsToBeInWaitState = true;
        CloseSet();
        //SetManager.OpenSet<GameSet>();
    }

   
}
