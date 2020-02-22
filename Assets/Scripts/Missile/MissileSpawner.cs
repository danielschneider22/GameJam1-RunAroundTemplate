using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileSpawner : MonoBehaviour
{
    public float spawnFrequency = 8f;
    public int maxNumMissiles = 20;
    public Transform player;
    public DialogManager dialogManager;

    private float timer;
    private int currNumMissiles;

    public GameObject missile;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
        currNumMissiles = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogManager.pauseGame)
        {
            return;
        }
        if(timer <= 0 && currNumMissiles < maxNumMissiles)
        {
            Spawn();
            timer = spawnFrequency;
            currNumMissiles++;
        } else
        {
            timer -= Time.deltaTime;
        }
    }

    private void Spawn()
    {
        Vector3 spawnPosition = new Vector3();
        spawnPosition.x = player.position.x + Random.Range(-3, 3);
        spawnPosition.x = spawnPosition.x > 0 ? spawnPosition.x + 6 : spawnPosition.x - 6;
        spawnPosition.y = player.position.y + Random.Range(-3, 3);
        spawnPosition.y = spawnPosition.y > 0 ? spawnPosition.y + 6 : spawnPosition.y - 6;
        spawnPosition.z = player.position.z;

        GameObject newMissile = Instantiate(missile, spawnPosition, Quaternion.identity);
        newMissile.SetActive(true);
    }
}
