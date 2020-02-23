using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistantRestartManager : MonoBehaviour
{
    public string hasStartedBefore;

    private void Awake()
    {
        GameObject persist = GameObject.FindGameObjectWithTag("PersistOnLoad");
        if (persist.scene.name != "DontDestroyOnLoad")
        {
            DontDestroyOnLoad(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        hasStartedBefore = SceneManager.GetActiveScene().name;
    }
}
