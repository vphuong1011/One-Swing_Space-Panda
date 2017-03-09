﻿using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
    public LayerMask collisionMask;

  //  public Transform bullet;
    private float speed = 5;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.right * Time.deltaTime * speed);

  
	}

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "Ground")
        {
            Destroy(gameObject);
        }

        if(col.gameObject.name == "Sword")
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Time.deltaTime * speed + .1f, collisionMask))
            {
                Vector3 reflectDir = Vector3.Reflect(ray.direction, hit.normal);
                float rot = 90 - Mathf.Atan2(reflectDir.z, reflectDir.x) * Mathf.Rad2Deg;
                transform.eulerAngles = new Vector3(rot, 0,0 );
            }
        }
    }
}
