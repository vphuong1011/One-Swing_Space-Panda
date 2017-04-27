using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyGun : MonoBehaviour {
    public GameObject BulletSpawn;
	Animator anim;
	public float maxTime = 15;
	public float minTime = 5;
	private float time; 
	public float spawnTime;
	public float shootingRate = 0.35f;
	private float shootCooldown; 
	// Use this for initialization
	void Start () {
        
		//Invoke("FireEnemyBullet", spawnTime);
		SetRandomTime();
		time = minTime;
		anim =  GetComponent<Animator>();
		shootCooldown = 0f;
		
		
	}
	void FixedUpdate(){
		time += Time.deltaTime;
		if (time >= spawnTime){
			FireEnemyBullet();
			SetRandomTime();
		}
	}
	// Update is called once per frame
	void Update () {
		if (shootCooldown > 0){
			shootCooldown -= Time.deltaTime;
			Invoke("FireEnemyBullet", spawnTime);
		}
	}
    public void FireEnemyBullet ()
    {
        StartCoroutine(Wait(5.0f));
        time = 1;
		GameObject player = GameObject.Find ("Player(Clone)");
		
        if(player != null)
        {
			
			GameObject bullet = (GameObject)Instantiate(BulletSpawn);
            bullet.transform.position = transform.position;
            Vector2 direction = player.transform.position - bullet.transform.position;
          //  bullet.GetComponent<EnemyBullet>().SetDirection(direction);
            anim.SetTrigger("banditShoot");
        }
		
    }
	void SetRandomTime (){
		spawnTime = Random.Range(minTime, maxTime);
	}
	
	private IEnumerator Wait (float seconds)
	{
		yield return new WaitForSeconds(seconds);
	}

}
