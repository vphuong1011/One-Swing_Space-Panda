//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletNew : MonoBehaviour {
	public float speed = 10f;
    public Vector3 shotDir;
    public int boughtItem = 0;

    public bool hitPlayer = false;
    public bool deflected = false;

    public Transform blood;

    public Player1 playerScript;
    public BanditHealth enemyScript;
    public PropsManager propsMNG;
    int indexP;
    int indexE;
    int indexPROPS;

    [SerializeField] public List<float> levelBulletSpeedsMin = new List<float>();
    [SerializeField] public List<float> levelBulletSpeedsMax = new List<float>();
    [SerializeField] float AbsoluteMinSpeed = 10;

    int BulletDecreaseAmount = 3;

    bool bulletHit = false;

    public Levels levelInstance;
    bool spawnBullet = false;
   // public levelNumber levelsScript;

    // Use this for initialization
    void Start ()
    {
        // Find the player script on the Player, find the player targetPostions, choose Random target from the targetPositions
        playerScript = GameObject.Find("Player(Clone)").GetComponent<Player1>();
        playerScript.targetPositions = GameObject.FindGameObjectsWithTag("PlayerRagdoll");
        indexP = Random.Range(0, playerScript.targetPositions.Length);
        playerScript.currentTarget = playerScript.targetPositions[indexP];

      //  playerScript.bodyPartsTriggers = GameObject.FindGameObjectsWithTag("PlayerRagdoll");

        enemyScript = GameObject.Find("Enemy(Clone)").GetComponent<BanditHealth>();
        enemyScript.targetPositions = GameObject.FindGameObjectsWithTag("BanditRagdoll");
        indexE = Random.Range(0, enemyScript.targetPositions.Length);
        enemyScript.currentTarget = enemyScript.targetPositions[indexE];

        propsMNG = GameObject.Find("PropsRandomManager(Clone)").GetComponent<PropsManager>();
        propsMNG.targetPositions = GameObject.FindGameObjectsWithTag("Props");
        if(propsMNG.targetPositions.Length > 0)
        {
            indexPROPS = Random.Range(0, propsMNG.targetPositions.Length);
            propsMNG.currentTarget = propsMNG.targetPositions[indexPROPS];
        }

        if (propsMNG.currentTarget == null)
        {
            return;
        }


        //   float height = Random.Range(1.0f, 3.0f);
        shotDir = (playerScript.currentTarget.transform.position - gameObject.transform.position).normalized;

        // set the initial bullet speed
        speed = NewBulletSpeed();
    }
        

	// Update is called once per frame
	void Update  ()
    {
            levelInstance = GetComponent<Levels>();  //call the levels script
            transform.Translate(shotDir * Time.deltaTime * speed  );
            playerScript = GetComponent<Player1>();
            Destroy(gameObject, 20);
            


    }
	void OnTriggerEnter (Collider other)
	{
        if(other.gameObject.name == "Enemy Hit Trigger")
        {
            speed = 40;
            deflected = true;
            shotDir = (enemyScript.currentTarget.transform.position - gameObject.transform.position).normalized;
            Debug.Log("DeflectToEnemy");
            // cut the bullet into 2 pieces!?
        }

        if (other.gameObject.name == "Props Hit Trigger")
        {
            speed = 40;
            deflected = true;

            // If there are no more props, fire back at the enemy
            if(propsMNG.currentTarget != null)
                shotDir = (propsMNG.currentTarget.transform.position - gameObject.transform.position).normalized;
            else
                shotDir = (enemyScript.currentTarget.transform.position - gameObject.transform.position).normalized;


            Debug.Log("DeflectToProps");
        }

        // If the bullet hit the ragdoll
        if (other.gameObject.tag == "PlayerRagdoll")
        {
            // Make sure we have the component
            playerScript = GameObject.Find("Player(Clone)").GetComponent<Player1>();

            // If player only have 1 HP, ragdol drops -> Dead
            if (playerScript.newPlayerHP + PlayerData.ArmorUpgradeLevel <= 1 && bulletHit == false)
            {
                hitPlayer = true;
                foreach (GameObject obj in playerScript.bodyPartsTriggers)
                    obj.SetActive(false);

                GameObject.Find("Player(Clone)").SendMessage("KillRagdoll");
                Destroy(gameObject, 5);

                Debug.Log("Hit");
            }
            else
            {
                // Player has been  hit but he has armor
                playerScript.newPlayerHP--;
                //PlayerData.ArmorUpgradeLevel--;
            }

            GameObject blood = ResourceManager.Create("Prefabs/Blood");
            blood.transform.position = gameObject.transform.position;

            Destroy(blood, 1);
            bulletHit = true;

            if(playerScript.newPlayerHP + PlayerData.ArmorUpgradeLevel >= 1)
                Levels.CurrentLevel.CurrentEnemy.GetComponent<Bandit>().OnObjectHit();

        }

        if (other.gameObject.tag =="Props")
        {
            Destroy(gameObject, 10);
            Levels.CurrentLevel.CurrentEnemy.GetComponent<Bandit>().OnObjectHit(); //this will change the state of the bandit back to idle so it will fire again.

        }
    }

    public float NewBulletSpeed() // this will create a random speed based on the level the player is playing. 
    {
        float newSpeed = speed;

        int boughtItem = PlayerData.BulletSpeedDecreaseLevel /*+ BulletDecreaseAmount*/;
        int currentLevel = Levels.CurrentLevelNumber - 1;
        if (currentLevel >= levelBulletSpeedsMin.Count)
            currentLevel = levelBulletSpeedsMin.Count;

        float currentBulletSpeedMin = levelBulletSpeedsMin[currentLevel];
        float currentBulletSpeedMax = levelBulletSpeedsMax[currentLevel];
        newSpeed = Random.Range(currentBulletSpeedMin, currentBulletSpeedMax);

        newSpeed = newSpeed * (1 - (0.05f * boughtItem)); // if the decrease bullet item is bought reduce speed by 5%
        Mathf.Clamp(newSpeed, AbsoluteMinSpeed, newSpeed);

        print(newSpeed);



        return newSpeed;
    }
}