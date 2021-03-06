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
    private float dialogTimer;
    private AudioManager audioManager;
    private string audioName;

    public Text continueText;
    public TextMeshProUGUI spaceBarText;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogText;
    public Animator dialogAnimator;
    public Image animalToShow;
    public Image blackBackdrop;
    public bool restartScene;
    private bool loadNextScene;
    public bool pauseGame;
    public GameEndTimer gameEndTimer;
    public EmoticonDialogPromptManager emoticonDialogPromptManager;
    public DatePointManager datePointManager;

    private float waitToIncreasePoints;
    void Awake()
    {
        sentences = new Queue<string>();
        audioManager = FindObjectOfType<AudioManager>();
        waitToIncreasePoints = 0;
    }

    public void StartDialog(Dialog dialog)
    {
        audioName = dialog.audioName;
        // audioManager.Play(audioName);
        audioManager.Play("MenuOpened");
        dialogAnimator.SetBool("showDialog", true);
        nameText.text = dialog.name;

        sentences.Clear();

        foreach (string sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);
        }
        dialogText.text = sentences.Dequeue();

        if (sentences.Count == 0 && dialog.triggerRestart)
        {
            continueText.text = "RESTART";
            spaceBarText.text = "Press Space Bar to Restart";
        } else if (sentences.Count ==0 && dialog.triggerNextLevel)
        {
            spaceBarText.text = "Press Space Bar to Go to Next Date";
        }

        animalToShow.sprite = dialog.avatar;
        restartScene = dialog.triggerRestart;
        loadNextScene = dialog.triggerNextLevel;
        pauseGame = dialog.pauseGame;
        if(dialog.stopGameTimer)
        {
            gameEndTimer.runTimer = false;
        }
        emoticonDialogPromptManager.runDialogTimers = false;
        pointsForReading = dialog.pointsForReading;
        blackBackdrop.enabled = true;
        dialogTimer = 0f;
    }

    public void DisplayNextSentence()
    {
        // audioManager.Play(audioName);
        audioManager.Play("ContinueClicked");
        if (sentences.Count == 0)
        {
            EndDialog();
            if (restartScene)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            if (loadNextScene)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            return;
        }
        if (sentences.Count == 1 && restartScene)
        {
            continueText.text = "RESTART";
        }
        dialogText.text = sentences.Dequeue();
    }

    void EndDialog()
    {
        // audioManager.Stop(audioName);
        audioManager.Play("ContinueClicked");
        gameEndTimer.runTimer = true;
        pauseGame = false;
        dialogAnimator.SetBool("showDialog", false);
        emoticonDialogPromptManager.runDialogTimers = true;
        if(pointsForReading > 0)
        {
            if(dialogTimer > 1f)
            {
                waitToIncreasePoints = .1f;

            } else
            {
                datePointManager.decreasePoints(20, "Bad Listener!");
            }
            
        }
        blackBackdrop.enabled = false;
    }

    public void Update()
    {
        dialogTimer += Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.Space) && dialogAnimator.GetBool("showDialog"))
        {
            DisplayNextSentence();
        }
        if(waitToIncreasePoints > 0)
        {
            waitToIncreasePoints -= Time.deltaTime;
            if(waitToIncreasePoints <= 0)
            {
                datePointManager.increasePoints(pointsForReading, "Good Listener");
            }
        }
    }
}
