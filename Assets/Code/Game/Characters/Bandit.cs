using UnityEngine;
using System.Collections;

public enum EnemyState
{
    Bandit_SPAWNING,
    Bandit_IDLE,
    Bandit_WAITING,
    Bandit_MOVING,
    Bandit_ATTACKING,
    Bandit_HIT,
    Bandit_DYING,
    Bandit_DEAD
}

public class Bandit : MonoBehaviour
{

    public float range = 50.0f;
    public float maxTime = 15;
    public float minTime = 5;
    private float time;

    Animator anim;
    public Rigidbody projectile;
    public int health = 3;
    public Collider boxCollider;

    [SerializeField] private Transform GunTip; // This is where the bullet spawns

    private float attackTimer = 0;
    private float attackDelay;

    public BulletNew bulletInstance;

    // The player's current state
    EnemyState CurrentState = EnemyState.Bandit_IDLE;

    void Start()
    {
        anim = GetComponent<Animator>();

        attackDelay = Random.Range(minTime, maxTime); //random attack delay
    }

    // Update is called once per frame
    void Update()
    {

        bulletInstance = GetComponent<BulletNew>();
        //Player STATE MACHINE
       switch (CurrentState)
        {
			case EnemyState.Bandit_IDLE:
                attackTimer += Time.deltaTime;
                if(attackTimer > attackDelay)
                {
                    CurrentState = EnemyState.Bandit_ATTACKING;  //change to bandit attacking
                    attackTimer = 0;
                }

                //Debug.Log("EnemyState.Bandit_IDLE");
                break;

            case EnemyState.Bandit_ATTACKING:
                anim.SetTrigger("banditShoot"); // change bandit animation
               
                //Debug.Log("EnemyState.Bandit_ATTACKING");

                // Reset the attack delay
                
                CurrentState = EnemyState.Bandit_WAITING; //change bandit state to idle
                attackDelay = Random.Range(minTime, maxTime);          // attack Delay

                break;
            case EnemyState.Bandit_WAITING:
                break;

        }
    }

    public void OnObjectHit()
    {
        // What to do when a barrel is hit: Levels.CurrentLevel.CurrentEnemy.GetComponent<Bandit>().OnObjectHit();
        CurrentState = EnemyState.Bandit_IDLE;
    }

    public void ShootAnimEvent()   // spawn the bullet
    {

        GameObject bulletGO = ResourceManager.Create("Projectiles/Bullet");
        if(bulletGO && GunTip)
        {
            bulletGO.transform.position = GunTip.position;

            // BulletNew bullet = bulletGO.gameObject.GetComponent<BulletNew>();

            //   if (bullet)
            //   {
            //      Vector3 direction = Levels.CurrentLevel.PlayerGameObject.transform.position - bulletGO.transform.position;
            //      bullet.forwardDirection = new Vector3(direction.x, direction.y, 0).normalized;
            //   }
            Debug.Log("shooting");
        }
    }
	
	IEnumerator Wait(float seconds){
		yield return new WaitForSeconds(seconds);
	}

    private void OnTriggerEnter(Collider other) //Killing the bandit 
    {
        gameObject.SendMessage("KillRagdoll");
        Debug.Log("KILLED");
        GameObject blood = ResourceManager.Create("Prefabs/Blood");
        blood.transform.position = gameObject.transform.position;
        Destroy(gameObject, 5);
        Destroy(blood, 1);

        Bandit bandit = gameObject.GetComponent<Bandit>();

        if (bandit)
        {
            bandit.health = 0;
        }
    }
}
