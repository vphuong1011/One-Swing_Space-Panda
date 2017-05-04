using UnityEngine;
using System.Collections;

public class BulletNew : MonoBehaviour {
	public float speed = 10;
    public Vector3 shotDir;

    public Transform newBullet;
    public bool hitPlayer = false;

    public Transform blood;

    public Player1 playerScript;
    public BanditHealth enemyScript;
    public PropsManager propsMNG;
    int indexP;
    int indexE;
    int indexPROPS;

    // Use this for initialization
    void Start ()
    {
        playerScript = GameObject.Find("Player(Clone)").GetComponent<Player1>();
        playerScript.targetPositions = GameObject.FindGameObjectsWithTag("PlayerRagdoll");
        indexP = Random.Range(0, playerScript.targetPositions.Length);
        playerScript.currentTarget = playerScript.targetPositions[indexP];

      //  playerScript.bodyPartsTriggers = GameObject.FindGameObjectsWithTag("PlayerRagdoll");

        enemyScript = GameObject.Find("Enemy(Clone)").GetComponent<BanditHealth>();
        enemyScript.targetPositions = GameObject.FindGameObjectsWithTag("BanditRagdoll");
        indexE = Random.Range(0, enemyScript.targetPositions.Length);
        enemyScript.currentTarget = enemyScript.targetPositions[indexE];

      //  propsMNG = GameObject.Find("Props Manager").GetComponent<PropsManager>();
    //    propsMNG.targetPositions = GameObject.FindGameObjectsWithTag("Props");
     //   indexPROPS = Random.Range(0, propsMNG.targetPositions.Length);
    //    propsMNG.currentTarget = propsMNG.targetPositions[indexPROPS];

        //   float height = Random.Range(1.0f, 3.0f);
        shotDir = (playerScript.currentTarget.transform.position - gameObject.transform.position).normalized;
    }
        

	// Update is called once per frame
	void Update ()
    {
            transform.Translate(shotDir * Time.deltaTime * speed);
    }
	void OnTriggerEnter (Collider other)
	{
        if(other.gameObject.name == "Enemy Hit Trigger")
        {
            shotDir = (enemyScript.currentTarget.transform.position - gameObject.transform.position).normalized;
            Debug.Log("DeflectToEnemy");
            // cut the bullet into 2 pieces!?
        }

        if (other.gameObject.name == "Props Hit Trigger" && propsMNG)
        {
            shotDir = (propsMNG.currentTarget.transform.position - gameObject.transform.position).normalized;
            Debug.Log("DeflectToProps");
        }

        if(other.gameObject.name == "TimeToHitTrigger")
        {

        }

        // If the bullet hit the ragdoll, ragdoll starts
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
    }
}