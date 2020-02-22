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
        blackBlackDrop.color = new Color(blackBlackDrop.color.r, blackBlackDrop.color.g, blackBlackDrop.color.b, .8f);
    }
}
