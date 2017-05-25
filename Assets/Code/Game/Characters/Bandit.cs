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

    public MainMenuSet menusetScript;
    public static bool mainMenuChecked = false;

    public float range = 50.0f;
    public float maxTime = 15;
    public float minTime = 10;
    private float time;

    Animator anim;
    public Rigidbody projectile;
    public int health = 3;
    public Collider boxCollider;

    [SerializeField] private Transform GunTip; // This is where the bullet spawns

    private float attackTimer = 0;
    private float attackDelay;

    public BulletNew bulletInstance;


    public Player1 playerScript;


    public AudioSource cockingSound;
    public AudioSource gunShot;
    public AudioSource getHit;

    // The player's current state
    EnemyState CurrentState = EnemyState.Bandit_IDLE;

    // Update is called once per frame
    void Update()
    {

        bulletInstance = GetComponent<BulletNew>();

        if (mainMenuChecked == false)
        {
            GameObject menuGO = GameObject.Find("MainMenuSet(Clone)");
            if (menuGO)
            {
                MainMenuSet menuNew = menuGO.GetComponent<MainMenuSet>();
                if (menuNew && menuNew.gameRunNow == true)
                {
                    //if (menusetScript.gameRunNow == true)
                    mainMenuChecked = true;  
                }
            }
        }
        else
        {
            banditShootFunction();
        }
    }

    void Start()
    {
       
        anim = GetComponent<Animator>();
        attackDelay = Random.Range(minTime, maxTime); //random attack delay
       // menusetScript = GameObject.Find("MainMenuSet(Clone)").GetComponent<MainMenuSet>();
    }


    void banditShootFunction()
    {
        //Player STATE MACHINE
        switch (CurrentState)
        {
            case EnemyState.Bandit_IDLE:
                attackTimer += Time.deltaTime;
                cockingSound.Play();
                if (attackTimer > attackDelay)
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
        cockingSound.Play();
        bulletInstance.hitProps = false;
    }

    public void ShootAnimEvent()   // spawn the bullet
    {
        GameObject bulletGO = ResourceManager.Create("Projectiles/Bullet");
        if(bulletGO && GunTip)
        {
            bulletGO.transform.position = GunTip.position;
            gunShot.Play();
        }
		Debug.Log("shooting");

        // Allow the player to swing
        Game.Inst.CanSwing = true;
    }


	
	IEnumerator Wait(float seconds){
		yield return new WaitForSeconds(seconds);
	}

    private void OnTriggerEnter(Collider other) //Killing the bandit 
    {  
        gameObject.SendMessage("KillRagdoll");
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        Debug.Log("KILLED");
        getHit.Play();
        GameObject blood = ResourceManager.Create("Prefabs/Blood");
        blood.transform.position = gameObject.transform.position;
        blood.transform.rotation = gameObject.transform.rotation;
        //  Destroy(gameObject, 5);
        Destroy(blood, 1);

        Bandit bandit = gameObject.GetComponent<Bandit>();

        if (bandit)
        {
            bandit.health = 0;
        }
    }
}
