//using System;
using System.Collections;
//using System.Collections.Generic;
using UnityEngine;



public class BulletNew : MonoBehaviour {
	public float speed = 10;
    public Vector3 shotDir;

    public bool hitPlayer = false;
    public bool deflected = false;

    public Transform blood;

    public Player1 playerScript;
    public BanditHealth enemyScript;
    public PropsManager propsMNG;
    int indexP;
    int indexE;
    int indexPROPS;

    public float bulletMin = 1.2f;
    public float bulletMax = 1.3f;
    public float newSpeed;
    public Levels levelInstance;
   // public levelNumber levelsScript;

    // Use this for initialization
    void Start ()
    {
        // Find the player script on the Player, find the player targetPostions, choose Random target from the targetPositions
        playerScript = GameObject.Find("Player(Clone)").GetComponent<Player1>();
        playerScript.targetPositions = GameObject.FindGameObjectsWithTag("PlayerRagdoll");
        indexP = Random.Range(0, playerScript.targetPositions.Length);
        playerScript.currentTarget = playerScript.targetPositions[indexP];

        // Find the enemy script on the Enemy, find the enemy targetPostions, choose Random target from the targetPositions
        enemyScript = GameObject.Find("Enemy(Clone)").GetComponent<BanditHealth>();
        enemyScript.targetPositions = GameObject.FindGameObjectsWithTag("BanditRagdoll");
        indexE = Random.Range(0, enemyScript.targetPositions.Length);
        enemyScript.currentTarget = enemyScript.targetPositions[indexE];

        // Find the prop script on the Props Random Manager, find the props targetPostions, choose Random target from the targetPositions
        propsMNG = GameObject.Find("PropsRandomManager(Clone)").GetComponent<PropsManager>();
        propsMNG.targetPositions = GameObject.FindGameObjectsWithTag("Props");
        indexPROPS = Random.Range(0, propsMNG.targetPositions.Length);
        propsMNG.currentTarget = propsMNG.targetPositions[indexPROPS];

        //   float height = Random.Range(1.0f, 3.0f);
        shotDir = (playerScript.currentTarget.transform.position - gameObject.transform.position).normalized;


    }
        

	// Update is called once per frame
	void Update  ()
    {
            levelInstance = GetComponent<Levels>();

            
          
    }
	void OnTriggerEnter (Collider other)
	{
        // If the bullet hit the player triggers named "Enemy Hit Trigger" -> bullet deflect back to enemy
        if(other.gameObject.name == "Enemy Hit Trigger")
        {
            deflected = true;
            shotDir = (enemyScript.currentTarget.transform.position - gameObject.transform.position).normalized;
            Debug.Log("DeflectToEnemy");
            // cut the bullet into 2 pieces!?
        }

        // If the bullet hit the player triggers named "Props Hit Trigger" -> bullet deflect back to props
        if (other.gameObject.name == "Props Hit Trigger")
        {
            deflected = true;
            shotDir = (propsMNG.currentTarget.transform.position - gameObject.transform.position).normalized;
            Debug.Log("DeflectToProps");
        }

        // If the bullet hit the player ragdoll, ragdoll drops
        if (other.gameObject.tag == "PlayerRagdoll")
        {
            foreach(GameObject obj in playerScript.bodyPartsTriggers)
            {
                obj.SetActive(false);
            }
            GameObject.Find("Player(Clone)").SendMessage("KillRagdoll");
            GameObject blood = ResourceManager.Create("Prefabs/Blood");
            blood.transform.position = gameObject.transform.position;
            Destroy(gameObject,5);
            Destroy(blood, 1);
            

            Debug.Log("Hit");
        }

        // This will change the state of the bandit back to idle so it will fire again.
        if (other.gameObject.tag =="Barrel")
        {
            Levels.CurrentLevel.CurrentEnemy.GetComponent<Bandit>().OnObjectHit(); 
        }
    }

  public void NewBulletSpeed()
    {
        if (Levels.CurrentLevelNumber >= 1)
        {
                    newSpeed = Random.Range(50, 100);
                    speed = newSpeed;
                    transform.Translate(shotDir * Time.deltaTime * speed);
                    print(newSpeed);
                    Debug.Log("newspeed");
                }
            }
    
    void FixedUpdate (){
        NewBulletSpeed();
    }


}