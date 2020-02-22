using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunIntroDialog : MonoBehaviour
{
    private DialogTrigger dialogTrigger;
    void Start()
    {
        gameObject.GetComponent<DialogTrigger>().TriggerDialog();
    }

}
