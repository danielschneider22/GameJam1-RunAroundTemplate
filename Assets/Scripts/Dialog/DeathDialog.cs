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
        string[] willyDeathHealth = { "Welp! It's been a whale of a time....", "I'm trying to use humor to cope with the fact that my date's dead." };
        HealthDeath = new Dictionary<string, Dialog>
        {
            {"Scene1", new Dialog("Willy the Whale", willyDeathHealth, willyTheWhaleSprite, true)},
        };

        string[] willyDeathTime = { "Hmmmmm... yes yes very interesting... very..... interesting", "ZZZZZZZZZZZZZZZ....", "Oh sorry, I think I gotta move on though" };
        TimeDeath = new Dictionary<string, Dialog>
        {
            {"Scene1", new Dialog("Willy the Whale", willyDeathTime, willyTheWhaleSprite, true)},
        };
    }
}
