using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorUpgrade : MonoBehaviour {

    public static int armorLevel = 1;
    public Player1 playerScript;

	// Use this for initialization
	void Start () {
        if (armorLevel == 1)
        {
            playerScript.newPlayerHP = 1;
        }

        if (armorLevel == 2)
        {
            playerScript.newPlayerHP = 2;
        }

        if (armorLevel == 3)
        {
            playerScript.newPlayerHP = 3;
        }
    }
	
	// Update is called once per frame
	void Update () {
        BuyArmor();
	}

    public void BuyArmor()
    {
        if (armorLevel < 3)
        {
            armorLevel += 1;
        }
    }
}
