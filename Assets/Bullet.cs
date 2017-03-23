﻿using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	private float speed = 10;
    public void Awake()
    {
    }
	// Use this for initialization
	void Start () {
	}


	// Update is called once per frame
	void Update () {
		transform.Translate (-Vector3.forward * Time.deltaTime * speed);
	}
	void OnTriggerEnter (Collider other)
	{
        if(other.gameObject.name == "Player")
        {    
                Vector3 reflectDir = Vector3.Reflect(other.gameObject.transform.position, Vector3.forward);
                float rot = 212 + Mathf.Atan2(reflectDir.x, reflectDir.y) * Mathf.Rad2Deg;
                transform.eulerAngles = new Vector3(0, rot, 0);
            // this bullet will turn to blood     
        }

        if(other.gameObject.tag == "PlayerRagdoll")
        {
            GameObject.Find("Player").SendMessage("KillRagdoll");
        }
    }
}