using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseManager : MonoBehaviour
{
    public DatePointManager datePointManager;
    public MoneyTracker moneyTracker;
    public GameEndTimer gameEndTimer;
    public HealthTracker healthTracker;

    public static int sweetsCost = 50;
    public static int flowersCost = 100;
    public static int timeCost = 100;
    public static int healthCost = 150;
    public void buySweets()
    {
        if(canPurchase(sweetsCost))
        {
            datePointManager.increasePoints(20, "Delicious Treat!");
            moneyTracker.loseMoney(sweetsCost);
        }
    }

    public void buyFlowers()
    {
        if (canPurchase(flowersCost))
        {
            datePointManager.increasePoints(50, "So Pretty!");
            moneyTracker.loseMoney(flowersCost);
        }
    }

    public void buyTime()
    {
        if (canPurchase(timeCost))
        {
            gameEndTimer.addTime(15f);
            moneyTracker.loseMoney(flowersCost);
        }
    }

    public void buyHealth()
    {
        if (canPurchase(healthCost) && healthTracker.currHealth < 5)
        {
            healthTracker.gainHealth();
            moneyTracker.loseMoney(flowersCost);
        }
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            buySweets();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            buyFlowers();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
        {
            buyTime();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
        {
            buyHealth();
        }
    }

    private bool canPurchase(int purchasePrice)
    {
        return moneyTracker.currMoney >= purchasePrice;
    }
}
