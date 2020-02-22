using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialog
{
    public string name;
    [TextArea(3, 10)]
    public string[] sentences;
    public Sprite avatar;
    public bool triggerRestart;

    public Dialog(string name, string[] sentences, Sprite avatar, bool triggerRestart)
    {
        this.name = name;
        this.sentences = sentences;
        this.avatar = avatar;
        this.triggerRestart = triggerRestart;
    }

    public Dialog(string name, string[] sentences, Sprite avatar)
    {
        this.name = name;
        this.sentences = sentences;
        this.avatar = avatar;
        this.triggerRestart = false;
    }
}
