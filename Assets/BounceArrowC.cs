using UnityEngine;
using System.Collections;

public class BounceArrowC : MonoBehaviour {

	private float speed = 5;

    public void Awake()
    {
    }
	// Use this for initialization
	void Start () {
	}


	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.right * Time.deltaTime * speed);

	}
	void OnCollisionEnter (Collision col)
	{
        if(gameObject.name == "Bullet")
        {
            foreach (ContactPoint contact in col.contacts)
            {
                Vector3 reflectDir = Vector3.Reflect(col.gameObject.transform.position, Vector3.right);
                float rot = 90 - Mathf.Atan2(reflectDir.y, reflectDir.x) * Mathf.Rad2Deg;
                transform.eulerAngles = new Vector3(0, 0, rot);
            }     
        }
    }
}
