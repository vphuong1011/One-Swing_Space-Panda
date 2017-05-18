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
    
    public GameObject spawnedCoin; //drag the coin prefab on inspector.
    public Rigidbody coinRB; //drag the coin prefab on inspector again, assuming it already has a rigidbody in it.
    public float coinSpeed = 3; //adjust the speed in which the coin will fly off the spawner.


    void Start()
    {
        int numCoins = Random.Range(1, 4) + PlayerData.CoinUpgradeLevel;
        for (int i = 0; i < numCoins; ++i)
            SpawnCoin();

        Destroy(transform.parent.gameObject, 3f);
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
    
}