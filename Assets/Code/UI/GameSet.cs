using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSet : Set
{
    public AudioSource buyArmorSound;
    public AudioSource buyBulletSound;
    public AudioSource buyCoinSound;
    public AudioSource clickSound;



    public GameObject[] ammountCoins;
    public GameObject[] Counters = null;
    
    //UI GameObjects on Inspector
    [SerializeField] private GameObject ShopPopUp = null;
    [SerializeField] private GameObject MenuPopUp = null;

    [SerializeField] private GameObject ArmorUpgradeIcon = null;
    [SerializeField] private GameObject BulletUpgradeIcon = null;
    [SerializeField] private GameObject CoinUpgradeIcon = null;
    

    //Booleans
    [SerializeField] private bool MenuIsShowing = false;
    [SerializeField] private bool ShopIsShowing = false;
    [SerializeField] private bool ArmorIconShowing = false;
    [SerializeField] private bool BulletIconShowing = false;
    [SerializeField] private bool CoinIconShowing = false;

    public static bool loadLevelNow = false;
    public  bool playerIsDead = false;
    public bool addCoinsNow = false;

    //Counters
    public Text coinsValue;
    public Text armorBuffValue;
    public Text bulletDecreasedValue;
    public Text coinBoostValue;
    //public Text scoreValue;
    public Text dayValue;
    //public static int newScore = 0;
    public static int newDay = 1;

    // Private member variables
    bool updateScoreNow = true;




    void Awake()
    {
        PlayerData.Coins = PlayerData.defaultCoins;
        PlayerData.ArmorUpgradeLevel = PlayerData.defaultArmor;
        Debug.Log("You have: " + PlayerData.Coins + "Coins. You also have: " + PlayerData.ArmorUpgradeLevel + " Armor");
        loadLevelNow = false;
        /*foreach (GameObject _obj in Counters)
        {

            _obj.SetActive(false);
        }*/
    }

    // Use this for initialization
    void Start()
    {
        //newScore = 0;
    }

    // Update is called once per frame

    void Update()
    {
       /* GameObject menuGO = GameObject.Find("MainMenuSet(Clone)");
        if (menuGO)
        {
            MainMenuSet menuNew = menuGO.GetComponent<MainMenuSet>();
            if (menuNew && menuNew.gameRunNow == true)
            {
                foreach (GameObject _obj in Counters)
                {

                    _obj.SetActive(true);
                }
            }
        }*/

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
                //newScore = newScore + 1;
                //scoreValue.text = "Score " + newScore;
                loadLevelNow = true;
                updateScoreNow = false;
                Shop();
            }
        }

        if (PlayerData.BulletSpeedDecreaseLevel == 0)
        {
            bulletDecreasedValue.text = "Bullet Speed Reduction: " + PlayerData.BulletSpeedDecreaseLevel;
        }
        if (PlayerData.ArmorUpgradeLevel == 0)
        {
            armorBuffValue.text = "Armor Buff: " + PlayerData.ArmorUpgradeLevel;
        }
        if (PlayerData.CoinBoostLevel == 0)
        {
            coinBoostValue.text = "Coins Boost: " + PlayerData.CoinBoostLevel;
        }
    }

    /// <summary>
    /// Coin Collection
    /// </summary>
    /// <returns></returns>
    IEnumerator AddCoinsAndStop()
    {
        yield return new WaitForSeconds(.1f);
        addCoinsNow = false;
    } 

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

    /// <summary>
    /// Shop Items
    /// </summary>
    //Coin drop boost
    public void coinUpgrade()
    {
        if (PlayerData.Coins >= PlayerData.CoinBoostCost)
        {
            Debug.Log("Boosting coin drops!");
            buyCoinSound.Play();
            PlayerData.CoinBoostLevel++;
            PlayerData.Coins -= PlayerData.CoinBoostCost;
            coinsValue.text = "Coins " + PlayerData.Coins;
        
        if (PlayerData.CoinBoostLevel >= 1)
        {
            Game.Inst.WantsToBeInWaitState = true;
            coinBoostValue.text = "Coins Boost: " + PlayerData.CoinBoostLevel;
            //CoinIconShowing = !CoinIconShowing;
            //CoinUpgradeIcon.SetActive(CoinIconShowing);
        }
        else if (PlayerData.CoinBoostLevel == 0)
        {
            coinBoostValue.text = "Coins Boost: " + PlayerData.CoinBoostLevel;
            //CoinUpgradeIcon.SetActive(false);
        }
    }
        else
        {
            Debug.Log("You don't have enough coins!");
        }
       
    }

    //Decrease bullet speed item
    public void BulletDecreaseItem()
    {
    if (PlayerData.Coins >= PlayerData.BulletSpeedDecreaseCost)
    {
        Debug.Log("Bullet speed has being decreased!");
        buyBulletSound.Play();
        PlayerData.BulletSpeedDecreaseLevel++;
        PlayerData.Coins -= PlayerData.BulletSpeedDecreaseCost;
        coinsValue.text = "Coins " + PlayerData.Coins;

        if (PlayerData.BulletSpeedDecreaseLevel >= 1)
        {
            Game.Inst.WantsToBeInWaitState = true;
            bulletDecreasedValue.text = "Bullet Speed Reduction: " + PlayerData.BulletSpeedDecreaseLevel;
            //BulletIconShowing = !BulletIconShowing;
            //BulletUpgradeIcon.SetActive(BulletIconShowing);

        }
        else if (PlayerData.BulletSpeedDecreaseLevel == 0)
        {
            bulletDecreasedValue.text = "Bullet Speed Reduction: " + PlayerData.BulletSpeedDecreaseLevel;
            //BulletUpgradeIcon.SetActive(false);
        }
    }

    else
    {
        Debug.Log("You don't have enough coins to decrease bullet speed!");
    }
    }

    //Armor buff item
    public void armorBuy()
    {
        if (PlayerData.Coins >= PlayerData.ArmorUpgradeCost)
        {
            Debug.Log("Armor has being added!");
            buyArmorSound.Play();
            PlayerData.ArmorUpgradeLevel++;
            PlayerData.Coins -= PlayerData.ArmorUpgradeCost;
            coinsValue.text = "Coins " + PlayerData.Coins;

            if (PlayerData.ArmorUpgradeLevel >= 1)
            {
                Game.Inst.WantsToBeInWaitState = true;
                armorBuffValue.text = "Armor Buff: " + PlayerData.ArmorUpgradeLevel;
                //ArmorIconShowing = !ArmorIconShowing;
                //ArmorUpgradeIcon.SetActive(ArmorIconShowing);
            }
            else if (PlayerData.ArmorUpgradeLevel == 0)
            {
                armorBuffValue.text = "Armor Buff: " + PlayerData.ArmorUpgradeLevel;
            //ArmorUpgradeIcon.SetActive(false);
            }
        }
        else
        {
            Debug.Log("You don't have enough coins to upgrade armor!");
        }
    }


    /// <summary>
    /// UI Functions
    /// </summary>
    /// 

    //Shop
    void Shop()
    {
        Game.Inst.WantsToBeInWaitState = true;
        PauseGame();  /// Pause Menu pop up
        ShopIsShowing = !ShopIsShowing;
        ShopPopUp.SetActive(ShopIsShowing);
    }

    // Pause Menu
    public void OnPauseGameClicked()
    {
        clickSound.Play();
        Game.Inst.WantsToBeInWaitState = true;
        //Levels.CloseLevel();
        PauseGame();

        /// Pause Menu pop up
        MenuIsShowing = !MenuIsShowing;
        MenuPopUp.SetActive(MenuIsShowing);

        //CloseSet();
        //SetManager.OpenSet<WinSet>();
    }

    //Lose Sequence when player is killed
    IEnumerator LoseSequence()
    {

        yield return new WaitForSeconds(1f);
        // Game.Inst.WantsToBeInWaitState = true;
        CloseSet();
        SetManager.OpenSet<LoseSet>();
        playerIsDead = true;
        yield return new WaitForSeconds(3f);
        Levels.CloseLevel();
    }


    //Continue button for Shop
    public void OnContinueClicked()
    {
        clickSound.Play();
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
        clickSound.Play();
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
     
}

