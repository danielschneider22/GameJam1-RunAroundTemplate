using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public float spawnFrequency = 3f;
    public int maxNumCoins = 100;
    public Transform player;
    public DialogManager dialogManager;

    private float timer;

    public GameObject coin;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        int currNumCoins = GameObject.FindGameObjectsWithTag("Coin").Length;
        if (dialogManager.pauseGame)
        {
            return;
        }
        if(timer <= 0 && currNumCoins < maxNumCoins)
        {
            Spawn();
            timer = spawnFrequency;
        } else
        {
            timer -= Time.deltaTime;
        }
    }

    private void Spawn()
    {
        Vector3 spawnPosition = new Vector3();
        spawnPosition.x = player.position.x + Random.Range(-3, 3);
        spawnPosition.x = spawnPosition.x > 0 ? spawnPosition.x + 2 : spawnPosition.x - 2;
        spawnPosition.y = player.position.y + Random.Range(-3, 3);
        spawnPosition.y = spawnPosition.y > 0 ? spawnPosition.y + 2 : spawnPosition.y - 2;
        spawnPosition.z = player.position.z;

        GameObject newCoin = Instantiate(coin, spawnPosition, Quaternion.identity);
        newCoin.SetActive(true);
    }
}
