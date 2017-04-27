using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public GameObject[] targetPositions;
    public GameObject currentTarget;
    int index;

    public Component[] boneRig;

    public bool bulletSpawned;

    public float currentTime;
    public float timeWaitAllowed;

    public Transform bulletSpawnPosition;
    // Use this for initialization
    void Start () {

        bulletSpawnPosition = GameObject.Find("bulletSpawn").transform;
        boneRig = gameObject.GetComponentsInChildren<Rigidbody>();
        float timeWaitAllowed = Random.Range(2f, 5f);
         
	}
	
	// Update is called once per frame
	void Update () {
        if(this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            currentTime += Time.deltaTime;
        }

        if (this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Idle") && currentTime >= timeWaitAllowed)
        {
            GetComponent<Animator>().SetBool("toAim", true);
             
        }

        if(this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("FiringGun"))
        {
            // Shoot a bullet
            GameObject bullet = ResourceManager.Create("Projectiles/Bullet");
            bullet.transform.position = bulletSpawnPosition.transform.position;
            bulletSpawned = true;
        }

        if (bulletSpawned == true)
        {
            GetComponent<Animator>().SetBool("backIdle", true);
            bulletSpawned = false;
        }
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
