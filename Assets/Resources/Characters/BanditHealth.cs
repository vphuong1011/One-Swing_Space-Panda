using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditHealth : MonoBehaviour {

    public Component[] boneRig;

    public GameObject[] targetPositions;
    public GameObject currentTarget;

    public void Start()
    {
        // Search through all the ragdoll in the enemy
        boneRig = gameObject.GetComponentsInChildren<Rigidbody>();
    }
	
    // Drops ragdoll
    void KillRagdoll()
    {
        foreach (Rigidbody ragdoll in boneRig)
        {
            ragdoll.isKinematic = false;
        }
        GetComponent<Animator>().enabled = false;
    }
}