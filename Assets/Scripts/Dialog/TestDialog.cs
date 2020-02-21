using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDialog : MonoBehaviour
{
    public DialogTrigger dialogTrigger;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            dialogTrigger.TriggerDialog();
        }
    }
}
