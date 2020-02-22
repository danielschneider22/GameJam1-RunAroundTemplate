using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameEndTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float mainTimer;

    private float timer;
    private bool canCount = true;
    private bool doOnce = false;
    void Start()
    {
        timer = mainTimer;
    }
    void Update()
    {
        if (timer >= 0.0f && canCount)
        {
            timer -= Time.deltaTime;
            timerText.text = timer.ToString("F");
        }

        else if (timer <= 0.0f && !doOnce)
        {
            canCount = false;
            doOnce = true;
            timerText.text = "0.00";
            timer = 0.0f;
        }
    }
}
