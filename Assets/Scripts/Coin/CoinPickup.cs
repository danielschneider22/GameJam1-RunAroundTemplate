using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public DialogManager dialogManager;
    public MoneyTracker moneyTracker;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (dialogManager.pauseGame)
        {
            return;
        }

        if (collision.gameObject.tag == "PlayerBody")
        {
            FindObjectOfType<AudioManager>().Play("PickedUpCoin");
            moneyTracker.addMoney(20);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Coin")
        {
            Destroy(gameObject);
        }
    }
}
