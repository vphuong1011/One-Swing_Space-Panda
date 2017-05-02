using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditHealth : MonoBehaviour {

    public Component[] boneRig;

    public GameObject[] targetPositions;
    public GameObject currentTarget;

    public void Start()
    {
        boneRig = gameObject.GetComponentsInChildren<Rigidbody>();
    }
	
    void KillRagdoll()
    {
        foreach (Rigidbody ragdoll in boneRig)
        {
            ragdoll.isKinematic = false;
        }
        GetComponent<Animator>().enabled = false;
    }
}