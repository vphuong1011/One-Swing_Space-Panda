using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSet : Set {

    public GameObject intro = null;
    public GameObject menu = null;
    //booleans
   // public bool introLoaded = false;
    public bool reloadedGame = false;
    public  bool gameRunNow = false;

    public AudioSource clickSound;

	// Use this for initialization
	void Start ()
    {
        GameObject helpGO = GameObject.Find("HelpSet(Clone)");
        if (helpGO)
        {
            HelpSet helpNew = helpGO.GetComponent<HelpSet>();
            if (helpNew && helpNew.introLoaded == true)
            {
                intro.SetActive(false);
            }
        }
        gameRunNow = false;
            //Added this to show game screen in the main menu.
            Game.Inst.WantsToBeInLoadingState = true;
            //SetManager.OpenSet<GameSet>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlayClicked()
    {
      //  clickSound.Play();
        CloseSet();     
        gameRunNow = true;
        SetManager.OpenSet<GameSet>();
        // gameSetShown = true;
    }

    // DEBUG: These are just for testing menu flow
    public void OnSettingsClicked()
    {
        clickSound.Play();
        //gameSetShown = true;
        CloseSet();
        SetManager.OpenSet<SettingsSet>();
    }

    // DEBUG: These are just for testing menu flow
    public void OnHelpClicked()
    {
        clickSound.Play();
        Debug.Log("AUDIO");
        //gameSetShown = true;
        CloseSet();
         SetManager.OpenSet<HelpSet>();
    }
}
