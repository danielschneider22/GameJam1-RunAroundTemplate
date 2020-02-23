using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameEndTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float mainTimer;
    public GameOverManager gameOverManager;
    public bool runTimer = false;

    private float timer;
    private bool hasLost = false;
    
    void Start()
    {
        timer = mainTimer;
    }
    void Update()
    {
        if (timer >= 0.0f && runTimer)
        {
            timer -= Time.deltaTime;
            timerText.text = timer.ToString("F");
        }

        else if (timer <= 0.0f && !hasLost)
        {
            runTimer = false;
            timerText.text = "0.00";
            timer = 0.0f;
            gameOverManager.gameOver("time");
            hasLost = true;
        }
    }

    public void updateTimerText()
    {
        timerText.text = mainTimer.ToString("F");
    }
}
