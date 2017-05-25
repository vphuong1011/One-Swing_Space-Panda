using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpSet : Set {
    public AudioSource clickSound;
    public bool introLoaded = false;

    // Use this for initialization
    void Start () {
        introLoaded = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnBackButtonClicked()
    {
        introLoaded = true;
        clickSound.Play();
        CloseSet();
        SetManager.OpenSet<MainMenuSet>();        
    }
}
