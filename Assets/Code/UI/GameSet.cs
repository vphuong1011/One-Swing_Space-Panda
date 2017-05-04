using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSet : Set
{
    [SerializeField] private GameObject ShopPopUp = null;
    [SerializeField] private GameObject MenuPopUp = null;

    //Booleans
    [SerializeField] private bool MenuIsShowing = false;
    [SerializeField] private bool ShopIsShowing = false;
    public static bool loadLevelNow = false;

    //Counters
    public Text coinsValue;
    public Text scoreValue;
    public static int newMoney = 0;
    public static int newScore = 0;

    // Private member variables
    bool updateScoreNow = true;


    void Awake()
    {
        loadLevelNow = false;
    }

    // Use this for initialization
    void Start()
    {
        newMoney = 0;
        newScore = 0;
    }

    // Update is called once per frame

    void Update()
    {

        if(Levels.CurrentLevel.CurrentEnemy)
        {
            Bandit bandit = Levels.CurrentLevel.CurrentEnemy.GetComponent<Bandit>();

            if (bandit && bandit.health <= 0 && updateScoreNow == true)
            {
                newScore = newScore + 1;
                scoreValue.text = "Score " + newScore;
                loadLevelNow = true;
                updateScoreNow = false;
                Shop();
            }   

        }
    }

    /// <summary>
    ///Test Buttons goes here
    /// </summary>
    /// 

    //Collect Coins Button
    public void CollectCoins()
    {
        newMoney = newMoney + 1;
        Debug.Log("You got " + newMoney + " coins!");
        coinsValue.text = "Coins " + newMoney;
    }

    //Kill Enemy Button
    public void KillEnemy()
    {
        Bandit bandit = Levels.CurrentLevel.CurrentEnemy.GetComponent<Bandit>();

        if(bandit)
        {
            bandit.health = 0;
            Debug.Log("Enemy health is " + bandit.health);
        }
    }

    //Kill Player Button
    public void KillPlayer()
    {
        Game.Inst.WantsToBeInWaitState = true;
        Levels.CloseLevel();
        CloseSet();
        SetManager.OpenSet<LoseSet>();

    }

    /// <summary>
    /// Menus functions below
    /// </summary>
    /// 

    // Pause Menu
    public void OnPauseGameClicked()
    {
        Game.Inst.WantsToBeInWaitState = true;
        //Levels.CloseLevel();
        PauseGame();

        /// Pause Menu pop up
        MenuIsShowing = !MenuIsShowing;
        MenuPopUp.SetActive(MenuIsShowing);

        //CloseSet();
        //SetManager.OpenSet<WinSet>();
    }

    /// <summary>
    /// Shop Pop Up
    /// </summary>

    void Shop()
    {
        Game.Inst.WantsToBeInWaitState = true;
        //Levels.CloseLevel();
        PauseGame();

        /// Pause Menu pop up
        ShopIsShowing = !ShopIsShowing;
        ShopPopUp.SetActive(ShopIsShowing);

        //CloseSet();
        //SetManager.OpenSet<WinSet>();
    }


    public void OnContinueClicked()
    {
        Game.Inst.WantsToBeInLoadingState = true;
        Levels.CloseLevel();
    }

    public void OnSettingsClicked()
    {
        Game.Inst.WantsToBeInWaitState = true;
        // Levels.CloseLevel();

        CloseSet();
        SetManager.OpenSet<SettingsSet>();
    }

    void PauseGame()
    {
        if (Time.timeScale == 1.0F)
            Time.timeScale = 0.7F;
        else
            Time.timeScale = 1.0F;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
    }
    
   
}

