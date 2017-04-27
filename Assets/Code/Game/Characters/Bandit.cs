﻿using UnityEngine;
using System.Collections;

public enum EnemyState
{
    Bandit_SPAWNING,
    Bandit_IDLE,
    Bandit_MOVING,
    Bandit_ATTACKING,
    Bandit_HIT,
    Bandit_DYING,
    Bandit_DEAD
}

public class Bandit : MonoBehaviour
{
    public Transform player;
    public float range = 50.0f;
    public float bulletImpulse = 20.0f;
    public float maxTime = 15;
    public float minTime = 5;
    private float time;
    public float spawnTime;
    private bool onRange = false;
    public float fireRate;
    public float nextFire;
    Animator anim;
    public Rigidbody projectile;

    [SerializeField] private Transform GunTip; // This is where the bullet spawns

    private float attackTimer = 0;
    private float attackDelay;


    // The player's current state
    EnemyState CurrentState = EnemyState.Bandit_IDLE;

    // Update is called once per frame
    void Update()
    {
        onRange = Vector3.Distance(transform.position, player.position) < range;

			if (onRange)
            transform.LookAt(player);
			Debug.Log("Looking");

        //Player STATE MACHINE
       switch (CurrentState)
        {
			case EnemyState.Bandit_IDLE:
                attackTimer += Time.deltaTime;
                if(attackTimer > attackDelay)
                {
                    CurrentState = EnemyState.Bandit_ATTACKING;
                    attackTimer = 0;
                }

                Debug.Log("EnemyState.Bandit_IDLE");
                break;

            case EnemyState.Bandit_ATTACKING:
                anim.SetTrigger("banditShoot");
                
                Debug.Log("EnemyState.Bandit_ATTACKING");

                // Reset the attack delay
                CurrentState = EnemyState.Bandit_IDLE;
                attackDelay = Random.Range(minTime, maxTime);

                break;

        }
    }


    void Start()
    {

        anim = GetComponent<Animator>();

        attackDelay = Random.Range(minTime, maxTime);

    }

    void Awake()
    {

    }



    public void ShootAnimEvent()
    {

        GameObject bulletGO = ResourceManager.Create("Projectiles/Bullet");
        if(bulletGO && GunTip)
        {
            bulletGO.transform.position = GunTip.position;

            Bullet bullet = bulletGO.gameObject.GetComponent<Bullet>();

            if (bullet)
            {
                Vector3 direction = Levels.CurrentLevel.PlayerGameObject.transform.position - bulletGO.transform.position;
                bullet.forwardDirection = new Vector3(direction.x, direction.y, 0).normalized;
            }

        }
		Debug.Log("shooting");

    }

    void FixedUpdate()
    {
       
    }

    void SetRandomTime()
    {
        
    }
	
	IEnumerator Wait(float seconds){
		yield return new WaitForSeconds(seconds);
	}
	
//	public void Fire()
//	{
//			GameObject bullet1 = (GameObject)Instantiate(BulletSpawn);
 //           Rigidbody bullet = (Rigidbody)Instantiate(projectile, transform.position + transform.forward, transform.rotation);
 //           bullet.AddForce(transform.forward * bulletImpulse, ForceMode.Impulse);
//			Debug.Log("shoot");
	//}
	

}
