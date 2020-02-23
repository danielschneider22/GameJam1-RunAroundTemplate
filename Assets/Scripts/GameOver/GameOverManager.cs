using System.Collections;
using System.Collections.Generic;
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
    public Sprite willyTheWhaleSprite;
    public Sprite gameOverWinSprite;

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
        }
        else if (causeOfLoss == "time")
        {
            Dialog deathDialog = deathDialogObj.TimeDeath[SceneManager.GetActiveScene().name];
            dialogTrigger.dialog = deathDialog;
            dialogTrigger.TriggerDialog();
        }
        gameOverImage.enabled = true;
        blackBlackDrop.enabled = true;

        bgMusic.Stop();
        audioManager.Play("GameLoss");

        setPlayerFaceShocked.setPlayerFaceShocked(true);

        gameEndTimer.runTimer = false;
    }

    public void gameOverWin()
    {
        string[] winningConvo = { "Wow, you were an incredible date! I had so much fun!" }; 
        Dialog winDialog = new Dialog("Willy the Whale", winningConvo, willyTheWhaleSprite, false, true);
        dialogTrigger.dialog = winDialog;
        dialogTrigger.TriggerDialog();
        gameOverImage.sprite = gameOverWinSprite;
        gameOverImage.color = new Color(0, 1f, 1f);
        gameOverImage.enabled = true;
        blackBlackDrop.enabled = true;

        audioManager.Play("GameWin");

        gameEndTimer.runTimer = false;
    }
}
