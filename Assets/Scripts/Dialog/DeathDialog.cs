using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathDialog: MonoBehaviour
{
    public Dictionary<string, Dialog> HealthDeath { get; set; }
    public Dictionary<string, Dialog> TimeDeath { get; set; }
    public Sprite willyTheWhaleSprite;

    public void Start()
    {
        string[] willyDeathHealth = { "Oh jeez, did you die cause you were paying attention to me. I'm so sorry!" };
        HealthDeath = new Dictionary<string, Dialog>
        {
            {"Scene1", new Dialog("Willy the Whale", willyDeathHealth, willyTheWhaleSprite, true, true)},
        };

        string[] willyDeathTime = { "Oh no, oh no, oh no. I'm sorry I just wasn't feeling the connection. It was like you didn't even notice I was here." };
        TimeDeath = new Dictionary<string, Dialog>
        {
            {"Scene1", new Dialog("Willy the Whale", willyDeathTime, willyTheWhaleSprite, true, true)},
        };
    }
}
