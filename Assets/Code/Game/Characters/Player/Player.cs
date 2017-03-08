using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public Animator anim;
    public GameObject sword;
	// Use this for initialization
	void Start () {
        anim.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	if(Input.GetMouseButtonDown(0))
        {

        }
	}

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "Bullet")
        {
            Debug.Log("Hit");
        }

        
    }
}
