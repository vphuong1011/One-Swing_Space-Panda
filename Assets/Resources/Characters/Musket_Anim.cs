using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musket_Anim : MonoBehaviour {
	public EnemyShoot other;
	Animator anim;
	
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		GetComponent<EnemyShoot>().Shoot();
	}
	
	// Update is called once per frame
	void Update () {
		
		other.Shoot();
		anim.SetTrigger("Fire");
	}
}

