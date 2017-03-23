using UnityEngine;
using System.Collections;

public class BounceArrowC : MonoBehaviour {

	private float speed = 5;

    public Transform originalObject;
    public Transform reflectedObject;
    public void Awake()
    {
    }
	// Use this for initialization
	void Start () {
	}


	// Update is called once per frame
	void Update () {
		transform.Translate (-Vector3.forward * Time.deltaTime * speed);
        reflectedObject.position = Vector3.Reflect(originalObject.position, Vector3.right);

    }
}
