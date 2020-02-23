using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseManager : MonoBehaviour
{
    public DatePointManager datePointManager;
    public MoneyTracker moneyTracker;
    public GameEndTimer gameEndTimer;
    public HealthTracker healthTracker;

    public static int sweetsCost = 30;
    public static int flowersCost = 70;
    public static int timeCost = 100;
    public static int healthCost = 120;

    public Image healthButton;
    public Image timeButton;
    public Image flowerButton;
    public Image sweetsButton;

    private float healthTimer;
    private float timeTimer;
    private float flowerTimer;
    private float sweetsTimer;

    private AudioManager audioManager;

    public void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    public void buySweets()
    {
        if(canPurchase(sweetsCost))
        {
            audioManager.Play("MakePurchase");
            datePointManager.increasePoints(20, "Delicious Treat!");
            moneyTracker.loseMoney(sweetsCost);
            sweetsButton.color = new Color(0, 1f, 0);
            sweetsTimer = 1f;
        }
    }

    public void buyFlowers()
    {
        if (canPurchase(flowersCost))
        {
            audioManager.Play("MakePurchase");
            datePointManager.increasePoints(60, "So Pretty!");
            moneyTracker.loseMoney(flowersCost);
            flowerButton.color = new Color(0, 1f, 0);
            flowerTimer = 1f;
        }
    }

    public void buyTime()
    {
        if (canPurchase(timeCost))
        {
            audioManager.Play("MakePurchase");
            gameEndTimer.addTime(15f);
            moneyTracker.loseMoney(flowersCost);
            timeButton.color = new Color(0, 1f, 0);
            timeTimer = 1f;
        }
    }

    public void buyHealth()
    {
        if (canPurchase(healthCost) && healthTracker.currHealth < healthTracker.maxHealth)
        {
            healthTracker.gainHealth();
            moneyTracker.loseMoney(healthCost);
            audioManager.Play("MakePurchase");
            healthButton.color = new Color(0, 1f, 0);
            healthTimer = 1f;
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
        if(healthTimer > 0)
        {
            healthButton.color = new Color(1f - healthTimer, 1f, 1f - healthTimer);
            healthTimer -= Time.deltaTime;
        }
        if (sweetsTimer > 0)
        {
            sweetsButton.color = new Color(1f - sweetsTimer, 1f, 1f - sweetsTimer);
            sweetsTimer -= Time.deltaTime;
        }
        if (timeTimer > 0)
        {
            timeButton.color = new Color(1f - timeTimer, 1f, 1f - timeTimer);
            timeTimer -= Time.deltaTime;
        }
        if (flowerTimer > 0)
        {
            flowerButton.color = new Color(1f - flowerTimer, 1f, 1f - flowerTimer);
            flowerTimer -= Time.deltaTime;
        }
    }

    private bool canPurchase(int purchasePrice)
    {
        return moneyTracker.currMoney >= purchasePrice;
    }
}
