using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorUpgrade : MonoBehaviour {


    [SerializeField] private GameObject ArmorIcon = null;
    [SerializeField] private bool Armorbought = false;

    // Use this for initialization
    void Start()
    {
        if (PlayerData.ArmorUpgradeLevel >= 0)
        {
            gameObject.SetActive(true);
        }

    }	
	
}
