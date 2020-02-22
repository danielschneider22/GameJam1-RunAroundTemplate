using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistantRestartManager : MonoBehaviour
{
    public bool hasStartedBefore;

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
        hasStartedBefore = true;
    }
}
