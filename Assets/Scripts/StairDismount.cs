﻿using UnityEngine;
using System.Collections;

public class StairDismount : MonoBehaviour {
	//Declare a member variables for distributing the impacts over several frames
	float impactEndTime=0;
	Rigidbody impactTarget=null;
	Vector3 impact;

    public BulletNew bulletScript;

	// Use this for initialization
	void Start () {
	
		//Get all the rigid bodies that belong to the ragdoll
		Rigidbody[] rigidBodies=GetComponentsInChildren<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		//if left mouse button clicked
	//	if (Input.GetMouseButtonDown(0))
		//{
			//Get a ray going from the camera through the mouse cursor
		//	Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			
			//check if the ray hits a physic collider
		//	RaycastHit hit; //a local variable that will receive the hit info from the Raycast call below
		//	if (Physics.Raycast(ray,out hit))
		//	{
				//check if the raycast target has a rigid body (belongs to the ragdoll)
				if (bulletScript.hitPlayer == true)
				{
					//find the RagdollHelper component and activate ragdolling
					RagdollHelper helper=GetComponent<RagdollHelper>();
					helper.ragdolled=true;
					
					//set the impact target to whatever the ray hit
				//	impactTarget = hit.rigidbody;
					
					//impact direction also according to the ray
				//	impact = ray.direction * 2.0f;
					
					//the impact will be reapplied for the next 250ms
					//to make the connected objects follow even though the simulated body joints
					//might stretch
					impactEndTime=Time.time+0.25f;
				}
		//	}
		//}
		
		//Pressing space makes the character get up, assuming that the character root has
		//a RagdollHelper script
		if (Input.GetKeyDown(KeyCode.Space))
		{
			RagdollHelper helper=GetComponent<RagdollHelper>();
			helper.ragdolled=false;
		}	
		
		//Check if we need to apply an impact
		if (Time.time<impactEndTime)
		{
			impactTarget.AddForce(impact,ForceMode.VelocityChange);
		}
	}
}
