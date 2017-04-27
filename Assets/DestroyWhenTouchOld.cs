using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWhenTouchOld : MonoBehaviour {
    public GameObject[] barrelFrags;
	// Use this for initialization
	void Start () {
        barrelFrags = GameObject.FindGameObjectsWithTag("Barrel");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Bullet")
        {
                EnableDestroy();
        }
    }

    void EnableDestroy()
    {
        foreach (GameObject barrelfrag in barrelFrags)
        {
           barrelfrag.GetComponent<Rigidbody>().isKinematic = false;
           barrelfrag.GetComponent<Rigidbody>().useGravity = true;

        }
    }
}
