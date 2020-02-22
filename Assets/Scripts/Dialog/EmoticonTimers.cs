using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EmoticonTimer
{
    public float emoticonWait;
    public float emoticonDuration;
    public Dialog dialog;

    public EmoticonTimer(float emoticonWait, float emoticonDuration, Dialog dialog)
    {
        this.emoticonWait = emoticonWait;
        this.dialog = dialog;
        this.emoticonDuration = emoticonDuration;
    }
}
