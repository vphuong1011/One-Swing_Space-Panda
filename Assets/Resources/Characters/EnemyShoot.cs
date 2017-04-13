using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : Enemy {
 
    public Transform player;
    public float range = 50.0f;
    public float bulletImpulse= 20.0f;
	public float maxTime = 15;
	public float minTime = 5; 
	private float time; 
	public float spawnTime;
    private bool onRange= false;
	public float fireRate;
	public float nextFire;
	Animator anim;
    public GameObject BulletSpawn;
    public Rigidbody projectile;
 
    void Start(){
        //float rand = Random.Range (minTime, maxTime);
        Invoke("Shoot", spawnTime);
		anim = GetComponent<Animator>();
	
    }
	
	void Awake (){
		nextFire = Time.time + fireRate;
	}
   


    public void Shoot(){
       
        if (onRange){
			//time = 1;
            GameObject bullet1 = (GameObject)Instantiate(BulletSpawn);
            Rigidbody bullet = (Rigidbody)Instantiate(projectile, transform.position + transform.forward, transform.rotation);
            bullet.AddForce(transform.forward*bulletImpulse, ForceMode.Impulse);
			//nextFire = Time.time + fireRate;
            
            
            //Destroy (gameObject, 2);
        }
        anim.SetTrigger("banditShoot");
        Debug.Log("shooting");


    }

    void Update() {
 
        onRange = Vector3.Distance(transform.position, player.position)<range;
 
        if (onRange)
            transform.LookAt(player);

    }
	void FixedUpdate(){
		time += Time.deltaTime;
		if (time >= spawnTime){

	
			Shoot();
			SetRandomTime();
			
		}
	}
	
	void SetRandomTime (){
		spawnTime = Random.Range(minTime, maxTime);
	}
 
 
}