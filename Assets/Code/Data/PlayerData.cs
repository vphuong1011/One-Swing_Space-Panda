using System;
using UnityEngine;

[Serializable]
public class PlayerData
{
    public static int Coins = 0;
    public static int defaultCoins = 0;

    public static int ArmorUpgradeLevel = 1;
    public static int ArmorUpgradeCost = 10;

    public static int BulletSpeedDecreaseLevel = 0;
    public static int BulletSpeedDecreaseCost = 10;

    public static int CoinBoostLevel = 0;
    public static int CoinBoostCost = 20;


    public static void resetUpgrades()
    {
        ArmorUpgradeLevel = 0;
        BulletSpeedDecreaseLevel = 0;
        CoinBoostLevel = 0;
    }

   
}