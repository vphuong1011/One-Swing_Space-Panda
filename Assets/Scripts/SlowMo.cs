using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMo : MonoBehaviour {

    public float currentSlowMo = 0;
    public float slowTimeAllowed = 2f;

    public Player1 playerScript;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0) && playerScript.swing == false)
        {
            if(Time.timeScale == 1f)
            {
                Time.timeScale = 0.5f;
                Debug.Log("Slow");
            }
        }

       // else
       // {
       //     Time.timeScale = 1f;
       //     Time.fixedDeltaTime = 0.02f * Time.timeScale;
       // }

        if(Time.timeScale == 0.5f)
        {
            currentSlowMo += Time.deltaTime;
        }

        if(currentSlowMo > slowTimeAllowed)
        {
            currentSlowMo = 0f;
            Time.timeScale = 1.0f;
        }
	}
}
