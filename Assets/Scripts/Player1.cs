using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour {

    public MainMenuSet menusetScript;
    public static bool mainMenuChecked = false;

    public Component[] boneRig;

    public GameObject enemyTrigger;
    public GameObject propsTrigger;

    public float currrentAttackSpeed = 0.5f;

    public GameObject[] targetPositions;
    public GameObject currentTarget;

    public GameObject[] bodyPartsTriggers;

    public  bool swing = true;
    public int newPlayerHP = 1;


    public DestroyWhenTouch propsScript;

    
    // Use this for initialization
    void Start () {

       // menusetScript = GameObject.Find("MainMenuSet(Clone)").GetComponent<MainMenuSet>();//Albert added this to get bool of mainmenuset. 
        // Find Rigidbody on the player ragdolls
        boneRig = gameObject.GetComponentsInChildren<Rigidbody>();

        // Player haven't swing
        swing = true;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (mainMenuChecked == false)
        {
            GameObject menuGO = GameObject.Find("MainMenuSet(Clone)");
            if (menuGO)
            {
                MainMenuSet menuNew = menuGO.GetComponent<MainMenuSet>();
                if(menuNew && menuNew.gameRunNow)
                {
                    Debug.Log("game is running now!");
                    StartCoroutine(allowSwing());
                }
            }
           /* if (menusetScript.gameRunNow == true) //Albert added this to get bool of mainmenuset.
            {
                StartCoroutine(allowSwing());
            }*/
        }
        else
        {
            swingFunction();
        }
        
           

        // If any props get destroyed -> swing boolean back to false, player haven't swing
        if(propsScript.brokenBarrelSpawned == true || propsScript.brokenBucketSpawned == true || propsScript.brokenPotSpawned == true || propsScript.brokenSpiritHousetSpawned == true || propsScript.brokenStreetLampSpawned == true)
        {
            swing = false;
        }

       // IncreaseSwingSpeed();
    }

    void swingFunction()
    {
        // If Left Mouse pressed & "Withdraw", "Withdraw1" animations are not playing & player haven't swing yet -> Get the animation speed, activate the MouseClicked trigger in the animator
        if (Input.GetMouseButtonUp(0) && !this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Withdraw") && !this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Withdraw1"))
        {
            if (swing == false)
            {
                GetComponent<Animator>().speed = currrentAttackSpeed;
                GetComponent<Animator>().SetBool("MouseClicked", true);
                swing = true;

            }
        }

    }
    // Events in the animations to turn on/off the triggers [If the bullet hit a trigger, it will deflect]
    public void TurnOnEnemyCollision()
    {
        enemyTrigger.SetActive(true);
    }

    public void TurnOffEnemyCollision()
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

    //Turn on the ragdoll
    void KillRagdoll()
    {
        foreach(Rigidbody ragdoll in boneRig)
        {
            ragdoll.isKinematic = false;
        }

        GetComponent<Animator>().enabled = false;
    }

    // Increase attack speed
    void IncreaseSwingSpeed()
    {
        if(Input.GetKeyUp(KeyCode.S))
        {
            currrentAttackSpeed += 1;
        }
    }

    IEnumerator allowSwing() //Albert added this to delay the swing bool on main menu
    {
        yield return new WaitForSeconds(1);
        swing = false;
        mainMenuChecked = true; 
        
       
    }
}
