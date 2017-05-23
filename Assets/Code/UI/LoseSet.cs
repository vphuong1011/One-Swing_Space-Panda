using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseSet : Set {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnPlayAgainClicked()
    {
        //Levels.CloseLevel();
        //CloseSet();
        //SetManager.OpenSet<MainMenuSet>();
        SceneManager.LoadScene("Boot");
    }
}
