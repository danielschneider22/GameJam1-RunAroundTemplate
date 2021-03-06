﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathDialog: MonoBehaviour
{
    public Dictionary<string, Dialog> HealthDeath { get; set; }
    public Dictionary<string, Dialog> TimeDeath { get; set; }
    public Sprite willyTheWhaleSprite;
    public Sprite nigel;
    public Sprite zurg;

    public void Start()
    {
        string[] willyDeathHealth = { "Oh jeez, did you die cause you were paying attention to me. I'm so sorry!" };
        HealthDeath = new Dictionary<string, Dialog>
        {
            {"Scene1", new Dialog("Willy the Whale", willyDeathHealth, willyTheWhaleSprite, true, true, false)},
        };

        string[] willyDeathTime = { "Oh no, oh no, oh no. I'm sorry I just wasn't feeling the connection. It was like you didn't even notice I was here." };
        TimeDeath = new Dictionary<string, Dialog>
        {
            {"Scene1", new Dialog("Willy the Whale", willyDeathTime, willyTheWhaleSprite, true, true, false)},
        };

        string[] nigelDeathHealth = { "Well saddle my pony! Looks like yer weren't cut out for this evening partner!" };
        HealthDeath.Add("Scene2", new Dialog("Nigel the Narwal", nigelDeathHealth, nigel, true, true, false));

        string[] nigelDeathTime = { "This here's been the most boring date I've ever had. I'm outta here partner!" };
        TimeDeath.Add("Scene2", new Dialog("Nigel the Narwal", nigelDeathTime, nigel, true, true, false));

        string[] zurgDeathHealth = { "As expected, you could not stand before my onslaught!" };
        HealthDeath.Add("Scene3", new Dialog("Zurg the Destroyer", zurgDeathHealth, zurg, true, true, false));

        string[] zurgDeathTime = { "You are pathetic and not even deserving of my time... although you do have a nice smile." };
        TimeDeath.Add("Scene3", new Dialog("Zurg the Destroyer", zurgDeathTime, zurg, true, true, false));
    }
}
