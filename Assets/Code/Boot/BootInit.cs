using UnityEngine;
using System.Collections;

public class BootInit : MonoBehaviour {

	// Use this for initialization
	void Start () {

        // Create the initial app
        var app = ResourceManager.Create("App/App");
        if (app)
        {
            app.name = "App";

            // Create the main game
            var game = ResourceManager.Create("Game/Game");
            if (game)
                game.name = "Game";

            // Don't need boot init anymore
            Destroy(gameObject);
        }
    }	
}
