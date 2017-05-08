using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMo : MonoBehaviour {

    public float currentSlowMo = 0;
    public float slowTimeAllowed = 2f;

    public BulletNew bulletScript;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        // If bullet successfully deflected -> Slow down time
		if(bulletScript.deflected == true)
        {
            if(Time.timeScale == 1f)
            {
                Time.timeScale = 0.1f;
                Debug.Log("Slow");
            }
        }

        // If time is slowing, currentSlowMo increase over time
        if(Time.timeScale == 0.1f)
        {
            currentSlowMo += Time.deltaTime;
        }

        //If currentslowMo >= slowtimeAllowed, time back to normal
        if(currentSlowMo >= slowTimeAllowed)
        {
            currentSlowMo = 0f;
            Time.timeScale = 1.0f;
            bulletScript.deflected = false;
        }
	}
}
