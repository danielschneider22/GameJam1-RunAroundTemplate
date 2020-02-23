using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseManager : MonoBehaviour
{
    public DatePointManager datePointManager;
    public MoneyTracker moneyTracker;

    public static int sweetsCost = 50;
    public static int flowersCost = 100;
    public static int timeCost = 100;
    public static int healthCost = 150;
    public void buySweets()
    {
        if(canPurchase(sweetsCost))
        {
            datePointManager.increasePoints(20, "Delicious Treat");
            moneyTracker.loseMoney(sweetsCost);
        }
    }

    public void buyFlowers()
    {
        if (canPurchase(flowersCost))
        {
            datePointManager.increasePoints(30, "So Pretty");
            moneyTracker.loseMoney(flowersCost);
        }
    }

    private bool canPurchase(int purchasePrice)
    {
        return moneyTracker.currMoney >= purchasePrice;
    }
}
