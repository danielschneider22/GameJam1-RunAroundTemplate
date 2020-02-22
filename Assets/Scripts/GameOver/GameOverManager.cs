using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public DialogTrigger dialogTrigger;
    public DeathDialog deathDialogObj;
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
    }
}
