using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour {
 
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
 
    public Rigidbody projectile;
 
    void Start(){
        //float rand = Random.Range (minTime, maxTime);
        Invoke("Shoot", spawnTime);
		anim = GetComponent<Animator>();
		GetComponent<Musket_Anim>();
    }
	
	void Awake (){
		nextFire = Time.time + fireRate;
	}
   


    public void Shoot(){
 
        if (onRange){
			//time = 1;
			
            Rigidbody bullet = (Rigidbody)Instantiate(projectile, transform.position + transform.forward, transform.rotation);
            bullet.AddForce(transform.forward*bulletImpulse, ForceMode.Impulse);
			anim.SetTrigger("Fire");
			nextFire = Time.time + fireRate;
            //Destroy (gameObject, 2);
        }
 
 
    }
 
    void Update() {
 
        onRange = Vector3.Distance(transform.position, player.position)<range;
 
        if (onRange)
            transform.LookAt(player);
			
    }
	void FixedUpdate(){
		time += Time.deltaTime;
		if (time >= spawnTime){
			anim.SetTrigger("banditShoot");
			//anim.SetTrigger("Fire");
			Shoot();
			SetRandomTime();
			
		}
	}
	
	void SetRandomTime (){
		spawnTime = Random.Range(minTime, maxTime);
	}
 
 
}