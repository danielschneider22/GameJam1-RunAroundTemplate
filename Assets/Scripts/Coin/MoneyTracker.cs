using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyTracker : MonoBehaviour
{
    public int currMoney;
    public TextMeshProUGUI moneyText;

    public void addMoney(int money)
    {
        currMoney += 10;
        moneyText.text = currMoney.ToString();
    }

    public void loseMoney(int money)
    {
        currMoney -= money;
        moneyText.text = currMoney.ToString();
    }

}
