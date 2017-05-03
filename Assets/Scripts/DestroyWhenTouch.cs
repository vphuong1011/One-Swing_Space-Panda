using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWhenTouch : MonoBehaviour {

    public Transform brokenBarrel;
    public Transform brokenBucket;
    public Transform brokenStreetLamp;
    public Transform brokenPot;
    public Transform brokenSpiritHouse;

    public bool brokenBarrelSpawned;
    public bool brokenBucketSpawned;
    public bool brokenStreetLampSpawned;
    public bool brokenPotSpawned;
    public bool brokenSpiritHousetSpawned;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Barrel")
        {
                BarrelDestroyed();
        }

        if(other.gameObject.name == "Bucket")
        {
            BucketDestroyed();
        }

        if (other.gameObject.name == "Street lamp")
        {
            StreetLampDestroyed();
        }

        if (other.gameObject.name == "Pot")
        {
            PotDestroyed();
        }

        if (other.gameObject.name == "Spirit house")
        {
            SpiritHouseDestroyed();
        }
    }

    void BarrelDestroyed()
    {
        GameObject barrel = GameObject.Find("Barrel");
        Instantiate(brokenBarrel, barrel.transform.position, brokenBarrel.transform.rotation);
        brokenBarrelSpawned = true;
        Destroy(barrel.gameObject);
    }

    void BucketDestroyed()
    {
        GameObject bucket = GameObject.Find("Bucket");
        Instantiate(brokenBucket, bucket.transform.position, brokenBucket.transform.rotation);
        brokenBucketSpawned = true;
        Destroy(bucket.gameObject);
    }

    void StreetLampDestroyed()
    {
        GameObject streetLamp = GameObject.Find("Street lamp");
        Instantiate(brokenStreetLamp, streetLamp.transform.position, brokenStreetLamp.transform.rotation);
        brokenStreetLampSpawned = true;
        Destroy(streetLamp.gameObject);
    }

    void PotDestroyed()
    {
        GameObject pot = GameObject.Find("Pot");
        Instantiate(brokenPot, pot.transform.position, brokenPot.transform.rotation);
        brokenPotSpawned = true;
        Destroy(pot.gameObject);
    }

    void SpiritHouseDestroyed()
    {
        GameObject spiritHouse = GameObject.Find("Spirit house");
        Instantiate(brokenSpiritHouse, spiritHouse.transform.position, brokenSpiritHouse.transform.rotation);
        brokenSpiritHousetSpawned = true;
        Destroy(spiritHouse.gameObject);
    }
}
