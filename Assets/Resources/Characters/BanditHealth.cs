using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditHealth : MonoBehaviour {

    public Component[] boneRig;
    void OnTriggerEnter (Collider other){
			if(other.gameObject.name == "Bullet"){
            //KillRagdoll();
            //GetComponent<Animator>().enabled = false;
			//Destroy(gameObject, 5);
			Debug.Log("disable");
			}
	}

    void KillRagdoll()
    {
        foreach (Rigidbody ragdoll in boneRig)
        {
            ragdoll.useGravity = false;
        }

        //GetComponent<Animator>().enabled = false;
    }
}