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
    public bool pauseGame;
    public bool stopGameTimer;
    public int pointsForReading;

    public Dialog(string name, string[] sentences, Sprite avatar, bool pauseGame, int pointsForReading)
    {
        this.name = name;
        this.sentences = sentences;
        this.avatar = avatar;
        this.triggerRestart = false;
        this.pauseGame = pauseGame;
        this.stopGameTimer = pauseGame;
        this.pointsForReading = pointsForReading;
    }
    public Dialog(string name, string[] sentences, Sprite avatar, bool triggerRestart, bool pauseGame)
    {
        this.name = name;
        this.sentences = sentences;
        this.avatar = avatar;
        this.triggerRestart = triggerRestart;
        this.pauseGame = pauseGame;
    }
    public Dialog(string name, string[] sentences, Sprite avatar, bool triggerRestart)
    {
        this.name = name;
        this.sentences = sentences;
        this.avatar = avatar;
        this.triggerRestart = triggerRestart;
        this.pauseGame = false;
    }

    public Dialog(string name, string[] sentences, Sprite avatar)
    {
        this.name = name;
        this.sentences = sentences;
        this.avatar = avatar;
        this.triggerRestart = false;
        this.pauseGame = false;
    }
}
