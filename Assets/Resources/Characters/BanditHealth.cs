using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditHealth : MonoBehaviour {

	void OnCollisionEnter (Collision other){
			if(other.gameObject.name == "Bullet"){
			GetComponent<Animator>().enabled = false;
			Destroy(gameObject, 5);
			Debug.Log("disable");
			}
	}
}