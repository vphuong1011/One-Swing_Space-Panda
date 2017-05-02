using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour {

    public Component[] boneRig;

    public GameObject enemyTrigger;
    public GameObject propsTrigger;

    public float currrentAttackSpeed = 0.5f;

    public GameObject[] targetPositions;
    public GameObject currentTarget;

    public GameObject[] bodyPartsTriggers;

    public bool swing;

    // Use this for initialization
    void Start () {
        boneRig = gameObject.GetComponentsInChildren<Rigidbody>();

        swing = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonUp(0) && !this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Withdraw"))
        {
            if(swing == false)
            {
                GetComponent<Animator>().speed = currrentAttackSpeed;
                GetComponent<Animator>().SetBool("MouseClicked", true);
                swing = true;
            }
        }
    }

    public void TurnOnEnemyCollision()
    {
        enemyTrigger.SetActive(true);
    }

    public void TurnOnEnemyCollision1()
    {
        enemyTrigger.SetActive(true);
    }

    public void TurnOffEnemyCollision()
    {
        enemyTrigger.SetActive(false);
    }

    public void TurnOffEnemyCollision1()
    {
        enemyTrigger.SetActive(false);
    }

    public void TurnOnPropsCollision()
    {
        propsTrigger.SetActive(true);
    }

    public void TurnOnPropsCollision1()
    {
        propsTrigger.SetActive(true);
        Debug.Log("it's on");
    }

    public void TurnOffPropsCollision()
    {
        propsTrigger.SetActive(false);
    }

    public void TurnOffPropsCollision1()
    {
        propsTrigger.SetActive(false);
    }

    public void AttackFinished()
    {
        GetComponent<Animator>().speed = 1;
    }

    void KillRagdoll()
    {
        foreach(Rigidbody ragdoll in boneRig)
        {
            ragdoll.isKinematic = false;
        }

        GetComponent<Animator>().enabled = false;
    }
}
