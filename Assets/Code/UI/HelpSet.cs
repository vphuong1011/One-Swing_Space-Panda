using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpSet : Set {
    public AudioSource clickSound;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnBackButtonClicked()
    {
        clickSound.Play();
        CloseSet();
        SetManager.OpenSet<MainMenuSet>();        
    }
}
