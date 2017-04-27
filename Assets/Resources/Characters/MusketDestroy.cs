using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusketDestroy : MonoBehaviour {

	public void OnCollisionEnter (Collision other){
			
			if(other.gameObject.name == "Bullet"){
			Destroy(gameObject, 0.01f);
			Debug.Log("gun gone");
			}
	}
}
