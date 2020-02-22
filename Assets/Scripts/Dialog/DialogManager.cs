﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    private Queue<string> sentences;
    private int pointsForReading;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogText;
    public Animator dialogAnimator;
    public Image animalToShow;
    public bool restartScene;
    public bool pauseGame;
    public GameEndTimer gameEndTimer;
    public EmoticonDialogPromptManager emoticonDialogPromptManager;
    public DatePointManager datePointManager;
    void Awake()
    {
        sentences = new Queue<string>(); 
    }

    public void StartDialog(Dialog dialog)
    {
        dialogAnimator.SetBool("showDialog", true);
        nameText.text = dialog.name;

        sentences.Clear();

        foreach (string sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);
        }
        dialogText.text = sentences.Dequeue();
        animalToShow.sprite = dialog.avatar;
        restartScene = dialog.triggerRestart;
        pauseGame = dialog.pauseGame;
        if(dialog.stopGameTimer)
        {
            gameEndTimer.runTimer = false;
        }
        emoticonDialogPromptManager.runDialogTimers = false;
        pointsForReading = dialog.pointsForReading;
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialog();
            if (restartScene)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            return;
        }
        dialogText.text = sentences.Dequeue();
    }

    void EndDialog()
    {
        gameEndTimer.runTimer = true;
        pauseGame = false;
        dialogAnimator.SetBool("showDialog", false);
        emoticonDialogPromptManager.runDialogTimers = true;
        if(pointsForReading > 0)
        {
            datePointManager.increasePoints(pointsForReading, "Good Listener");
        }
    }
}
