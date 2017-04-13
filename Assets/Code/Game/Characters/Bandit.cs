using UnityEngine;

public enum EnemyState
{
    Bandit_SPAWNING,
    Bandit_IDLE,
    Bandit_MOVING,
    Bandit_ATTACKING,
    Bandit_HIT,
    Bandit_DYING,
    PLAYER_DEAD
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
    public GameObject BulletSpawn;
    public Rigidbody projectile;



    // The player's current state
    EnemyState CurrentState = EnemyState.Bandit_IDLE;

    // Update is called once per frame
    void Update()
    {
        onRange = Vector3.Distance(transform.position, player.position) < range;

        if (onRange)
            transform.LookAt(player);

        // Player STATE MACHINE
        switch (CurrentState)
        {
            case EnemyState.Bandit_IDLE:
                break;

        }
        {
            switch(CurrentState)
            {
                case EnemyState.Bandit_ATTACKING:
                    Shoot();
                    break;
                    }
        }
    }


    void Start()
    {
        //float rand = Random.Range (minTime, maxTime);
        Invoke("Shoot", spawnTime);
        anim = GetComponent<Animator>();

    }

    void Awake()
    {
        nextFire = Time.time + fireRate;
    }



    public void Shoot()
    {

        if (onRange)
        {
            //time = 1;
            GameObject bullet1 = (GameObject)Instantiate(BulletSpawn);
            Rigidbody bullet = (Rigidbody)Instantiate(projectile, transform.position + transform.forward, transform.rotation);
            bullet.AddForce(transform.forward * bulletImpulse, ForceMode.Impulse);
            //nextFire = Time.time + fireRate;


            //Destroy (gameObject, 2);
        }
        anim.SetTrigger("banditShoot");
        Debug.Log("shooting");


    }

    void FixedUpdate()
    {
        time += Time.deltaTime;
        if (time >= spawnTime)
        {


            Shoot();
            SetRandomTime();

        }
    }

    void SetRandomTime()
    {
        spawnTime = Random.Range(minTime, maxTime);
    }

}
