using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour {


    public Component[] boneRig;
	// Use this for initialization
	void Start () {
        boneRig = gameObject.GetComponentsInChildren<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonUp(0) && !this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Withdraw"))
        {
            GetComponent<Animator>().SetTrigger("MouseClicked");
            
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "EnenmyBulletGo(Clone)")
        {
           KillRagdoll();
		   Destroy(gameObject, 5);
        }
    }

    void KillRagdoll()
    {
        foreach(Rigidbody ragdoll in boneRig)
        {
            ragdoll.isKinematic = false;
        }

        GetComponent<Animator>().enabled = false;
    }

}
