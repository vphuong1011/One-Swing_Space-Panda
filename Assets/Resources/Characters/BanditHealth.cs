using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditHealth : MonoBehaviour {

    public Component[] boneRig;
    void OnTriggerEnter (Collider other){
			if(other.gameObject.name == "Bullet"){
            KillRagdoll();
            GetComponent<Animator>().enabled = false;
			Destroy(gameObject, 5);
			Debug.Log("disable");
			}
	}
	public void Start (){
		boneRig = gameObject.GetComponentsInChildren<Rigidbody>();
	}
	
	
    void KillRagdoll()
    {
        foreach (Rigidbody ragdoll in boneRig)
        {
            ragdoll.isKinematic = false;
        }

        //GetComponent<Animator>().enabled = false;
    }
}