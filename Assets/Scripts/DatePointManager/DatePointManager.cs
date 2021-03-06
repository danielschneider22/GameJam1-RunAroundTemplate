﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DatePointManager : MonoBehaviour
{
    public int maxNumPoints;

    private int currNumPoints = 0;

    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI pointsNotificationText;
    public Image dateSuccessBar;

    public Sprite goodSuccessBar;
    public Sprite badSuccessBar;
    public Animator pointChangeAnimator;
    public SetPlayerFaceShocked setPlayerFaceShocked;
    private AudioManager audioManager;
    public EmoticonDialogPromptManager emoticonDialogPromptManager;
    public GameOverManager gameOverManager;

    public void Start()
    {
        pointsText.text = currNumPoints + "/" + maxNumPoints;
        dateSuccessBar.fillAmount = currNumPoints / maxNumPoints;
        audioManager = FindObjectOfType<AudioManager>();
    }
    public void increasePoints(int numPoints, string reason)
    {
        currNumPoints += numPoints;
        if(currNumPoints >= maxNumPoints)
        {
            currNumPoints = maxNumPoints;
            gameOverManager.gameOverWin();
        }
        pointsText.text = currNumPoints + "/" + maxNumPoints;
        dateSuccessBar.fillAmount = (float)currNumPoints / (float)maxNumPoints;
        if(dateSuccessBar.fillAmount >= .75f)
        {
            dateSuccessBar.sprite = goodSuccessBar;
        }
        pointsNotificationText.text = "+" + numPoints.ToString() + " " + reason;
        pointChangeAnimator.SetTrigger("Point Change Positive");

        audioManager.Play("GainedPoints");
        emoticonDialogPromptManager.setLoveEmoticon();
    }

    public void decreasePoints(int numPoints, string reason)
    {
        currNumPoints -= numPoints;
        if(currNumPoints < 0)
        {
            currNumPoints = 0;
        }
        pointsText.text = currNumPoints + "/" + maxNumPoints;
        dateSuccessBar.fillAmount = (float)currNumPoints / (float)maxNumPoints;
        if (dateSuccessBar.fillAmount < .75f)
        {
            dateSuccessBar.sprite = badSuccessBar;
        }
        pointsNotificationText.text = "-" + numPoints.ToString() + " " + reason;
        pointChangeAnimator.SetTrigger("Point Change Negative");
        setPlayerFaceShocked.setPlayerFaceShocked(false);
        audioManager.Play("MissedNotification");
        emoticonDialogPromptManager.setAngerEmoticon();
    }
}
