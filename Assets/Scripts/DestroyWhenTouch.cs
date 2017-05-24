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

    public AudioSource barrelBucketSound;
    public AudioSource potSound;
    public AudioSource houseLampSound;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other) // If bullet touch these props, it will destroy the "Simple" version and spawn the "broken" version
    {
        if(other.gameObject.name == "SimpleBarrel(Clone)")
        {
            barrelBucketSound.Play();
            BarrelDestroyed();
        }

        if(other.gameObject.name == "SimpleBucket(Clone)")
        {
            barrelBucketSound.Play();
            BucketDestroyed();
        }

        if (other.gameObject.name == "SimpleStreetLamp(Clone)")
        {
            houseLampSound.Play();
            StreetLampDestroyed();
        }

        if (other.gameObject.name == "SimplePot(Clone)")
        {
            potSound.Play();
            PotDestroyed();
        }

        if (other.gameObject.name == "SimpleSpiritHouse(Clone)")
        {
            houseLampSound.Play();
            SpiritHouseDestroyed();
        }
    }

    void BarrelDestroyed()
    {
        GameObject barrel = GameObject.Find("SimpleBarrel(Clone)");
        Instantiate(brokenBarrel, barrel.transform.position, brokenBarrel.transform.rotation);
        brokenBarrelSpawned = true;
        StartCoroutine(turnboolsOff());
        Destroy(barrel.gameObject);
    }

    void BucketDestroyed()
    {
        GameObject bucket = GameObject.Find("SimpleBucket(Clone)");
        Instantiate(brokenBucket, bucket.transform.position, brokenBucket.transform.rotation);
        brokenBucketSpawned = true;
        StartCoroutine(turnboolsOff());
        Destroy(bucket.gameObject);
    }

    void StreetLampDestroyed()
    {
        GameObject streetLamp = GameObject.Find("SimpleStreetLamp(Clone)");
        Instantiate(brokenStreetLamp, streetLamp.transform.position, brokenStreetLamp.transform.rotation);
        brokenStreetLampSpawned = true;
        StartCoroutine(turnboolsOff());
        Destroy(streetLamp.gameObject);
    }

    void PotDestroyed()
    {
        GameObject pot = GameObject.Find("SimplePot(Clone)");
        Instantiate(brokenPot, pot.transform.position, brokenPot.transform.rotation);
        brokenPotSpawned = true;
        StartCoroutine(turnboolsOff());
        Destroy(pot.gameObject);
    }

    void SpiritHouseDestroyed()
    {
        GameObject spiritHouse = GameObject.Find("SimpleSpiritHouse(Clone)");
        Instantiate(brokenSpiritHouse, spiritHouse.transform.position, brokenSpiritHouse.transform.rotation);
        brokenSpiritHousetSpawned = true;
        StartCoroutine(turnboolsOff());
        Destroy(spiritHouse.gameObject);
    }

    //Added a coroutine to turn off broken objects spawn bools.
    IEnumerator turnboolsOff()
    {
        yield return new WaitForSeconds(1f);
        brokenBarrelSpawned = false;
        brokenBucketSpawned = false;
        brokenStreetLampSpawned = false;
        brokenPotSpawned = false;
        brokenSpiritHousetSpawned = false;
    }
}
