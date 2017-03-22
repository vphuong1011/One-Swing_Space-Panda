using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour {
    public GameObject BulletSpawn;

	// Use this for initialization
	void Start () {
        Invoke("FireEnemyBullet", 5f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void FireEnemyBullet ()
    {
        GameObject player = GameObject.Find ("Player(Clone)");
        if(player != null)
        {
            GameObject bullet = (GameObject)Instantiate(BulletSpawn);
            bullet.transform.position = transform.position;
            Vector2 direction = player.transform.position - bullet.transform.position;
            bullet.GetComponent<EnemyBullet>().SetDirection(direction);
        }
    }
}
