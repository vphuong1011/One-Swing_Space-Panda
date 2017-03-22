using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	private float speed = 10;

    Collider col;
    public void Awake()
    {
    }
	// Use this for initialization
	void Start () {
        col = GetComponent<BoxCollider>();
	}


	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.right * Time.deltaTime * speed);
	}
	void OnCollisionEnter (Collision col)
	{
        if(col.gameObject.name == "Player")
        {    
                Vector3 reflectDir = Vector3.Reflect(col.gameObject.transform.position, -Vector3.forward);
                float rot = -180 - Mathf.Atan2(reflectDir.x, reflectDir.z) * Mathf.Rad2Deg;
                transform.eulerAngles = new Vector3(0, 0, rot);               
        }

        if(col.gameObject.tag == "Prop")
        {
            GoThrough();
            Debug.Log("Go");
        }
    }

    private void OnCollisionExit(Collision col)
    {
        if(col.gameObject.tag == "Prop")
        {
            StopGoingThrough();
            Debug.Log("Stop");
        }
    }

    void GoThrough()
    {
        col.isTrigger = true;
    }

    void StopGoingThrough()
    {
        col.isTrigger = false;
    }
}
