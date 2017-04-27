using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bandit2 : MonoBehaviour {

     public GameObject Player;
 private float ViewRange = 40;
 private float RayRange = 20;
 private int vel = 8;
 public RaycastHit LastPos;
 public Vector3 RayDirection = Vector3.zero;
 public GameObject target;
 public Rigidbody Bullet;
 public Transform Muzzle;
 
 public void Update()
 {
     RayDirection = Player.transform.position - transform.position;
     if (Vector3.Angle(RayDirection, transform.forward) < ViewRange)
     {
         if (Physics.Raycast(transform.position, RayDirection, out LastPos, RayRange))
         {
             if (LastPos.collider.tag == "Player")
             {
                 Attack();
             }
         }
     }
 }
 public void Attack()
 {
     transform.LookAt(LastPos.transform.position);
     if (RayDirection.magnitude > 100)
     {
         transform.position = Vector3.MoveTowards(transform.position, LastPos.transform.position, Time.deltaTime * vel);
     }
     else
     {
             Rigidbody b = GameObject.Instantiate(Bullet, Muzzle.position, Muzzle.rotation) as Rigidbody;
             b.AddForce(2000 * b.transform.forward);
			 Debug.Log("Bandit2");
     }
 }
 
}