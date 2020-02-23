using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RunIntroDialog : MonoBehaviour
{
    private DialogTrigger dialogTrigger;

    public GameEndTimer gameEndTimer;
    public float roundLength;

    void Start()
    {
        PersistantRestartManager persistantRestartManager = GameObject.FindGameObjectWithTag("PersistOnLoad").GetComponent<PersistantRestartManager>();
        if (persistantRestartManager.hasStartedBefore != SceneManager.GetActiveScene().name)
        {
            gameObject.GetComponent<DialogTrigger>().TriggerDialog();
        } else
        {
            gameEndTimer.runTimer = true;
        }
        gameEndTimer.mainTimer = roundLength;
        gameEndTimer.updateTimerText();


    }

}
