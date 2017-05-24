using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSet : Set
{
    public GameObject[] ammountCoins;
    public GameObject[] Counters = null;
    

    [SerializeField] private GameObject ShopPopUp = null;
    [SerializeField] private GameObject MenuPopUp = null;
    [SerializeField] private GameObject ArmorUpgradeIcon = null;

    //Booleans
    [SerializeField] private bool MenuIsShowing = false;
    [SerializeField] private bool ShopIsShowing = false;
    [SerializeField] private bool ArmorIconShowing = false;
    public static bool loadLevelNow = false;
    public  bool playerIsDead = false;
    public bool addCoinsNow = false;

    //Counters
    public Text coinsValue;
    public Text scoreValue;
    public Text dayValue;
    public static int newScore = 0;
    public static int newDay = 1;

    // Private member variables
    bool updateScoreNow = true;




    void Awake()
    {
        PlayerData.Coins = PlayerData.defaultCoins;
        PlayerData.ArmorUpgradeLevel = PlayerData.defaultAmor;
        Debug.Log("You have: " + PlayerData.Coins + "Coins. You also have: " + PlayerData.ArmorUpgradeLevel + " Armor");
        loadLevelNow = false;
        foreach (GameObject _obj in Counters)
        {

            _obj.SetActive(false);
        }
    }

    // Use this for initialization
    void Start()
    {
        
        

        newScore = 0;
       // armorBuy();

    }

    // Update is called once per frame

    void Update()
    {
        GameObject menuGO = GameObject.Find("MainMenuSet(Clone)");
        if (menuGO)
        {
            MainMenuSet menuNew = menuGO.GetComponent<MainMenuSet>();
            if (menuNew && menuNew.gameRunNow)
            {
                foreach (GameObject _obj in Counters)
                {

                    _obj.SetActive(true);
                }
            }
        }
        ammountCoins = GameObject.FindGameObjectsWithTag("coin");

        GameObject bulletGO = GameObject.Find("Bullet(Clone)"); //Detects the hitPLayer boolean within the bullet. If true then show LoseSet.
        if (bulletGO)
        {
            BulletNew bulletNew = bulletGO.GetComponent<BulletNew>();
            if (bulletNew && bulletNew.hitPlayer)
            {
                StartCoroutine(LoseSequence());
                Debug.Log("KillPlayer Activated");
            }
        }

        /*if (Levels.CurrentLevel && Levels.CurrentLevel.PlayerGameObject)
        {
            Player1 player = Levels.CurrentLevel.PlayerGameObject.GetComponent<Player1>();

            if (player && player.newPlayerHP <= 0)
            {
                StartCoroutine(CloseLevelAndFade());
                Debug.Log("KillPlayer Activated");
            }
        }
        */
           
            GameObject coinSpawnerGO = GameObject.Find("CoinSpawner");
        if (coinSpawnerGO)
        {
            CoinSpawner coinSpawner = coinSpawnerGO.GetComponent<CoinSpawner>();
        
            if (coinSpawner)
            {
               Invoke("CollectCoins",1);
                //addCoinsNow = true;
            }
        }

        
        if (Levels.CurrentLevel && Levels.CurrentLevel.CurrentEnemy)
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

        //NullChecking
        /* GameObject banditGO = GameObject.Find("Enemy(Clone)");
        if (banditGO)
        {
            Bandit bandit = banditGO.GetComponent<Bandit>();

            if (bandit && bandit.health <= 0 && updateScoreNow == true)
            {
                newScore = newScore + 1;
                scoreValue.text = "Score " + newScore;
                loadLevelNow = true;
                updateScoreNow = false;
                Shop();
            }
        }*/
    }

    IEnumerator AddCoinsAndStop()
    {
       
        yield return new WaitForSeconds(.1f);
        addCoinsNow = false;
    }
    /// <summary>
    ///Test Buttons goes here
    /// </summary>
    /// 

    //Collect Coins Button
    void CollectCoins()
    {
        //Fixed: Now coins updates according to ammount of coins with tag "coin"
        if (ammountCoins.Length > 0)
        {
            PlayerData.Coins = PlayerData.Coins + ammountCoins.Length;
            Debug.Log("You got " + PlayerData.Coins + " coins!");
            coinsValue.text = "Coins " + PlayerData.Coins;
            StartCoroutine(AddCoinsAndStop());
            CancelInvoke();
        }
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


    IEnumerator LoseSequence()
    {
        
        yield return new WaitForSeconds(3f);
       // Game.Inst.WantsToBeInWaitState = true;
        CloseSet();
        SetManager.OpenSet<LoseSet>();
        playerIsDead = true;
        yield return new WaitForSeconds(3f);
        Levels.CloseLevel();
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

    //Coin upgrade button in shop
    public void coinUpgrade()
    {
        if (PlayerData.Coins >= PlayerData.CoinUpgradeCost)
        {
            Debug.Log("Boosting coin drops!");
            PlayerData.CoinUpgradeLevel++;
            PlayerData.Coins -= PlayerData.CoinUpgradeCost;
            coinsValue.text = "Coins " + PlayerData.Coins;
        }
        else
        {
            Debug.Log("You don't have enough coins!");
        }
       
    }

    public void armorBuy()
    {
        if (PlayerData.Coins >= PlayerData.ArmorUpgradeCost)
        {
            Debug.Log("Armor has being added!");
            PlayerData.ArmorUpgradeLevel++;
            PlayerData.Coins -= PlayerData.ArmorUpgradeCost;
            coinsValue.text = "Coins " + PlayerData.Coins;

            if (PlayerData.ArmorUpgradeLevel >= 1)
            {
                Game.Inst.WantsToBeInWaitState = true;
                ArmorIconShowing = !ArmorIconShowing;
                ArmorUpgradeIcon.SetActive(ArmorIconShowing);
            }
            else if (PlayerData.ArmorUpgradeLevel == 0)
            {
                ArmorUpgradeIcon.SetActive(false);

            }
        }
        else
        {
            Debug.Log("You don't have enough coins to upgrade armor!");
        }
    }

    //Continue button for Shop
    public void OnContinueClicked()
    {
        newDay = newDay + 1;
        dayValue.text = "Day " + newDay;
        Levels.CloseLevel();
        Game.Inst.WantsToBeInLoadingState = true;
        ShopIsShowing = !ShopIsShowing;
        ShopPopUp.SetActive(ShopIsShowing);
        updateScoreNow = true;
    }

    public void OnSettingsClicked()
    {
        Game.Inst.WantsToBeInWaitState = true;
        // Levels.CloseLevel();

        CloseSet();
        SetManager.OpenSet<MainMenuSet>();
    }

    public void OnExitGame()
    {
        Game.Inst.WantsToBeInWaitState = true;
        // Levels.CloseLevel();

        CloseSet();
        SetManager.OpenSet<MainMenuSet>();
    }


    void PauseGame()
    {
        if (Time.timeScale == 1.0F)
            Time.timeScale = 0.7F;
        else
            Time.timeScale = 1.0F;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
    }
    
    public void BulletDecreaseItem()
    {
        if (PlayerData.Coins >= 0)
        {
            PlayerData.Coins -= 1;
            PlayerData.BulletSpeedDecreaseLevel++;
        } 
    }
   
}

