using UnityEngine;
using System.Collections;

public class CoinSpawner : MonoBehaviour
{
    /// <summary>
    /// Alberto Wong.
    /// Coin Spawner script.
    /// //////////////////////////////////
    /// In order to use this attach a rigidbody to your coin gameobject.
    /// Then create a prefab.
    /// </summary>
    
    public bool spawnNow = false;
    public GameObject spawnedCoin; //drag the coin prefab on inspector.
    public int timer = 5;
    public Rigidbody coinRB; //drag the coin prefab on inspector again, assuming it already has a rigidbody in it.
    public float coinSpeed = 3; //adjust the speed in which the coin will fly off the spawner.

    public DestroyWhenTouch destroywhentouchScript;
    public bool coinSpawned;
    
    void Start()
    {
        destroywhentouchScript = GameObject.Find("Bullet").GetComponent<DestroyWhenTouch>();
    }

    void Update()
    {
        if(destroywhentouchScript.brokenBarrelSpawned == true && coinSpawned == false)
        {
            SpawnCoin();
            coinSpawned = true;
        }

        if (destroywhentouchScript.brokenBucketSpawned == true && coinSpawned == false)
        {
            SpawnCoin();
            coinSpawned = true;
        }

        if (destroywhentouchScript.brokenStreetLampSpawned == true && coinSpawned == false)
        {
            SpawnCoin();
            coinSpawned = true;
        }

        if (destroywhentouchScript.brokenPotSpawned == true && coinSpawned == false)
        {
            SpawnCoin();
            coinSpawned = true;
        }

        if (destroywhentouchScript.brokenSpiritHousetSpawned == true && coinSpawned == false)
        {
            SpawnCoin();
            coinSpawned = true;
        }

        if(coinSpawned == true)
        {
            Destroy(transform.parent.gameObject, 3f);
        }
        keyboardTest();//use this to test the coin spawner by pressing the spacebar. Remove it if it onTriggerEnter is used instead. 
    }

    /// <summary>
    /// Core functions are written below.
    /// OnTriggerEnter is disabled. In order to use it, just remove the " /* and the */ " in the beginning and the end of the function.
    /// No need to type "OnTriggerEnter();" on "void Update()".
    /// Don't forget to enable "trigger" on the collider of the object that triggers this function.
    /// </summary>


    /*void OnTriggerEnter(Collider other)
  {
      //check if the tag that collided is called "bullet"
      if (other.tag == "bullet")
      {
        SpawnCoin(); //or replace this with what you see below.
      }
  }*/

    void keyboardTest() // Function to use keypress to call "SpawnCoin()"
    {
        if (Input.GetKeyDown("space"))  //To test coin spawner on keypress. One time only.
        {
            SpawnCoin();                //calls the function that spawns coins.
        }

        if (Input.GetKeyDown("x"))
        {
            IncreaseSpawnRate();        //calls the function to increase instatiation rate using InvokeRepeating.
            StartCoroutine("x3");       //Coroutine to stop instantiation.
        }

        if (Input.GetKeyDown("c"))
        {
            IncreaseSpawnRate();        //calls the function to increase instatiation rate using InvokeRepeating.
            StartCoroutine("x4");       //Coroutine to stop instantiation.
        }


    }

    /// <summary>
    /// Function to spawn coins.
    /// </summary> 

    void SpawnCoin() 
    {
        Rigidbody spawnedCoin = Instantiate(coinRB, transform.position, transform.rotation * Quaternion.Euler(0, 90, 0)) as Rigidbody;      //instatiates the coin rigidbody on spot and rotate it 90 degress on Y.
        spawnedCoin.velocity = transform.TransformDirection(new Vector3(0, 0, coinSpeed));                                                  //dictates the direction and speed in which the coin will spawn.
        //StartCoroutine("coinFade");                                                                                                         //Makes coin dissappear
        GameObject.Destroy(spawnedCoin.gameObject,2);
    }

    /// <summary>
    /// Increase Instantiation rate.
    /// </summary>
    
    void IncreaseSpawnRate()
    {
        InvokeRepeating("SpawnCoin", 0f, .5f);
        
    }

    
    /// <summary>
    /// Couroutines to stop InvokeRepeating.
    /// Related to the increased drop rate of coins.
    /// </summary>
    /// <returns></returns>
    
    IEnumerator x3()
    {
        float wait_time = Random.Range(0f, 1.5f);
        yield return new WaitForSeconds(wait_time);
        CancelInvoke();
    }

    IEnumerator x4()
    {
        float wait_time = Random.Range(0f, 2f);
        yield return new WaitForSeconds(wait_time);
        CancelInvoke();
    }

    IEnumerator coinFade()
    {
        yield return new WaitForSeconds(1);
        Destroy(spawnedCoin);
    }
}