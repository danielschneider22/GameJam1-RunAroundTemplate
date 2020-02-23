using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public DialogTrigger dialogTrigger;
    public DeathDialog deathDialogObj;
    public Image gameOverImage;
    public Image blackBlackDrop;
    public SetPlayerFaceShocked setPlayerFaceShocked;
    private AudioManager audioManager;
    public AudioSource bgMusic;
    public GameEndTimer gameEndTimer;
    public Sprite animalSprite;
    public Sprite gameOverWinSprite;
    public TextMeshProUGUI gameOverReasonText;

    public void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    public void gameOver(string causeOfLoss)
    {
        if(causeOfLoss == "health")
        {
            Dialog deathDialog = deathDialogObj.HealthDeath[SceneManager.GetActiveScene().name];
            dialogTrigger.dialog = deathDialog;
            dialogTrigger.TriggerDialog();
            gameOverReasonText.text = "Ran out of health";
        }
        else if (causeOfLoss == "time")
        {
            Dialog deathDialog = deathDialogObj.TimeDeath[SceneManager.GetActiveScene().name];
            dialogTrigger.dialog = deathDialog;
            dialogTrigger.TriggerDialog();
            gameOverReasonText.text = "Ran out of time";
        }
        gameOverImage.enabled = true;
        blackBlackDrop.enabled = true;
        gameOverReasonText.enabled = true;

        bgMusic.Stop();
        audioManager.Play("GameLoss");

        setPlayerFaceShocked.setPlayerFaceShocked(true);

        gameEndTimer.runTimer = false;
    }

    public void gameOverWin()
    {
        if(animalSprite.name == "whale")
        {
            string[] winningConvo = { "Wow, you were an incredible date! I had so much fun!" };
            Dialog winDialog = new Dialog("Willy the Whale", winningConvo, animalSprite, false, true, true);
            dialogTrigger.dialog = winDialog;
        } else if (animalSprite.name == "zebra")
        {
            string[] winningConvo = { "I am beaten! Your bravery, perserverance, and overall cuteness were too much for Zurg the Destroyer. Well Done." };
            Dialog winDialog = new Dialog("Zurg the Destroyer", winningConvo, animalSprite, false, true, true);
        } else
        {
            string[] winningConvo = { "Well how about that partner! Ya done gone and lasso'd my hear!" };
            Dialog winDialog = new Dialog("Nigel the Narwal", winningConvo, animalSprite, false, true, true);

        }

        dialogTrigger.TriggerDialog();
        gameOverImage.sprite = gameOverWinSprite;
        gameOverImage.color = new Color(0, 1f, 1f);
        gameOverImage.enabled = true;
        blackBlackDrop.enabled = true;

        audioManager.Play("GameWin");

        gameEndTimer.runTimer = false;
    }
}
