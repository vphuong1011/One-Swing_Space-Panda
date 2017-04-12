using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {
    float speed;
    Vector2 _direction;
    bool isReady;
	int time; 
	public int enemyDamage = 1;


    void Awake() {
        speed = 1000f;
        isReady = false;
		time = 5;
    }

	// Use this for initialization
	void Start () {
		Destroy(gameObject, 2);
	}
	public void SetDirection(Vector2 direction)
    {
        _direction = direction.normalized;
        isReady = true;
    }
	// Update is called once per frame
	void Update () {
		if(isReady)
        {
            Vector2 position = transform.position;
            position += _direction * speed * Time.deltaTime;
            transform.position = position;
                Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
                Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
            if ((transform.position.x < min.x) || (transform.position.x > max.x) || (transform.position.y < min.y) || (transform.position.y > max.y))
            {
               
            
            }

        }
	}

     void OnCollisionEnter (Collision bullet)
   {
		if	(bullet.gameObject.name == "Player(Clone)")
        {
          // GetComponent<BanditHealth>().RemoveHealth(enemyDamage);
		 //  Destroy(bullet.gameObject);
			Debug.Log("Destroyed");
			
        }
    }
}
