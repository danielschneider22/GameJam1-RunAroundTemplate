﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EmoticonDialogPromptManager : MonoBehaviour
{
    public Sprite animal;
    public bool runDialogTimers;
    public Image emoteImage;
    public TextMeshProUGUI reminderText;
    public DialogManager dialogManager;
    public Sprite angryEmoticon;
    public Sprite alertEmoticon;
    public Sprite loveEmoticon;
    public DatePointManager datePointManager;
    public string dateName;
    private AudioManager audioManager;

    private List<EmoticonTimer> emoticonTimers;
    private EmoticonTimer currTimer;
    private DialogTrigger dialogTrigger;
    private int currConvoIdx;
    private float angerEmoticonTimer;
    private bool addedNotification;
    private float loveEmoticonTimer;

    private EmoticonTimer defaultEmoticonTimer;

    void Awake()
    {
        emoticonTimers = new List<EmoticonTimer>();
        dialogTrigger = GetComponent<DialogTrigger>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    void Start()
    {
        if(dateName == "willy")
        {
            string[] convo1 = { "Hi! I'm Willy the Whale. I like cuddles and blowing bubbles.", "I was really nervous about trying out this speed dating thing honestly...", "With the strangers, awkward conversations, and missiles being thrown at your date.", "It seemed like a lot for an introvert like me." };
            emoticonTimers.Add(new EmoticonTimer(
                5f,
                25f,
                new Dialog("Willy the Whale", convo1, animal, true, 80, "WhaleVoice")
            ));

            string[] convo2 = { "One of the weirdest things for me about online dating is making eye contact.", "Being a whale, people find it very intimidating to look up all the time", "And I feel bad trying to make 'em look up.", "So I try and scrunch down my body as far as it can go.", "But it usually doesn't help :(" };
            emoticonTimers.Add(new EmoticonTimer(
                5f,
                10f,
                new Dialog("Willy the Whale", convo2, animal, true, 80, "WhaleVoice")
            ));

            string[] convo3 = { "Hey, how do you feel about me not stopping time anymore for our conversations?", "I was doing it before because I was nervous you might not pay attention to me.", "But I wouldn't want to interrupt your flow as you avoid all the missiles." };
            emoticonTimers.Add(new EmoticonTimer(
                5f,
                5f,
                new Dialog("Willy the Whale", convo3, animal, false, 80, "WhaleVoice")
            ));

            string[] convo4 = { "Oh shoot did I interrupt your flow even more switching to letting time run?", "I'm so super sorry!", "Maybe Patrick shouldn't have added time control powers as an aspect of this dating show game" };
            emoticonTimers.Add(new EmoticonTimer(
                2f,
                5f,
                new Dialog("Willy the Whale", convo4, animal, true, 80, "WhaleVoice")
            ));

            string[] defaultConvo = { "Ho hum this is such a delightful time!", "Well at least for me, which is probably because I don't have to dodge missiles.", "I would try and help but I'm a whale." };
            defaultEmoticonTimer = new EmoticonTimer(
                2f,
                5f,
                new Dialog("Willy the Whale", defaultConvo, animal, true, 80, "WhaleVoice")
            );
        }

        if (dateName == "nigel")
        {
            string[] convo1 = { "Howdy there partner. Folks around here call me Nigel. Nigel the Narwal.", "I got a hankerin' for speed dating this past year.", "After my girlfriend took the truck and my cowboy hat, I felt like I hit rock bottom.", "Speed dating here is the way for Nigel to saunter his way back into happiness." };
            emoticonTimers.Add(new EmoticonTimer(
                5f,
                15f,
                new Dialog("Nigel the Narwal", convo1, animal, true, 30, "WhaleVoice")
            ));

            string[] convo2 = { "Ya know, watching you dodge all these missiles really reminds me of the good days with my ex.", "She'd also be throwing missiles at me. And tear gas, and rabid dogs, and firecrackers.", "A very passionate woman" };
            emoticonTimers.Add(new EmoticonTimer(
                5f,
                10f,
                new Dialog("Nigel the Narwal", convo2, animal, true, 40, "WhaleVoice")
            ));

            string[] convo3 = { "Ya know, watching you do that makes me feel like two step'n.", "Think I'll just watch ya dance while we talk.", "Put's me in a singin' mood!" };
            emoticonTimers.Add(new EmoticonTimer(
                7f,
                5f,
                new Dialog("Nigel the Narwal", convo3, animal, true, 40, "WhaleVoice")
            ));

            string[] convo4 = { "You are a mighty fine character indeed to be making it through this maelstrom of projectiles sir", "I must commend you on this and your remarkable singin' voice", "Please keep it going, it is putting me well at ease." };
            emoticonTimers.Add(new EmoticonTimer(
                5f,
                10f,
                new Dialog("Nigel the Narwal", convo4, animal, true, 40, "WhaleVoice")
            ));

            string[] convo5 = { "Think I'll try singin' as well!", "But usually singin' stops me from stopping time.", "So don't be surpised when next time I speak the action keeps a' playin'!" };
            emoticonTimers.Add(new EmoticonTimer(
                5f,
                10f,
                new Dialog("Nigel the Narwal", convo5, animal, true, 40, "WhaleVoice")
            ));

            string[] convo6 = { "You've been kind with all you're singing.", "As gratitude I'll sing you my favorite Narwal Western song.", "HOMMMMEEEE! NARWALLL HOMMEEEEE!", "TAKE ME BACK, I DONT BELONGGGG!", "IM LIKE A UNICORN.... ONLY FATTER", "TAKE ME HOMEEEEE! NARWALLL HOMMEEEE" };
            emoticonTimers.Add(new EmoticonTimer(
                5f,
                10f,
                new Dialog("Nigel the Narwal", convo6, animal, true, 40, "WhaleVoice")
            ));

            string[] defaultConvo = { "I think this date is goin' swell!", "I didn't think I'd find anyone I connected to as much as I connected to my old Becca.", "And you're not even throwing rabid dogs at me!" };
            defaultEmoticonTimer = new EmoticonTimer(
                5f,
                5f,
                new Dialog("Nigel the Narwal", defaultConvo, animal, true, 60, "WhaleVoice")
            );
        }

        if (dateName == "zurg")
        {
            string[] convo1 = { "Hello, my name is Zurg. ZURG THE DESTROYER", "... or zurg the zebra if you would prefer", "Prepare to lose this date." };
            emoticonTimers.Add(new EmoticonTimer(
                5f,
                5f,
                new Dialog("Zurg the Zebra", convo1, animal, true, 30, "WhaleVoice")
            ));

            string[] convo2 = { "Ho ho ho! Watching you struggle is its own reward", "I love that I can just sit back and pester you with dialog", "AND WATCH YOU SQUIRM MORTAL!", "Also I really approve of your choice of shirt. That suits your figure very well" };
            emoticonTimers.Add(new EmoticonTimer(
                10f,
                15f,
                new Dialog("Zurg the Zebra", convo2, animal, true, 30, "WhaleVoice")
            ));

            string[] convo3 = { "The saying goes that you know a zebra by it's stripes", "WELL MY STRIPES ARE MADE OF IRON AND PAIN!", "Nothing will withstand my missiles nor my dating prowess!", "... NOTHING" };
            emoticonTimers.Add(new EmoticonTimer(
                7f,
                10f,
                new Dialog("Zurg the Zebra", convo3, animal, true, 30, "WhaleVoice")
            ));

            string[] convo4 = { "Hmmm... you still yet live.", "STRANGE! PERHAPS YOU ARE NOT AS WEAK AS I HAD FIRST THOUGHT" };
            emoticonTimers.Add(new EmoticonTimer(
                5f,
                5f,
                new Dialog("Zurg the Zebra", convo4, animal, false, 40, "WhaleVoice")
            ));

            string[] convo5 = { "Did I mix you up by not freezing time last conversation!", "WELL I HOPE I DID!", "I ALSO REALLY ENJOY ALL THE SWEETS AND FLOWERS YOU GIVE ME" };
            emoticonTimers.Add(new EmoticonTimer(
                1f,
                5f,
                new Dialog("Zurg the Zebra", convo5, animal, true, 50, "WhaleVoice")
            ));

            string[] convo6 = { "You still stand.... I am impressed. Not impressed enough to give up...", "But I do admit that there is some charm in your tenacity.", "I FIND YOU QUITE CHARMING" };
            emoticonTimers.Add(new EmoticonTimer(
                8f,
                15f,
                new Dialog("Zurg the Zebra", convo6, animal, true, 50, "WhaleVoice")
            ));

            string[] convo7 = { "I wouldn't say I'm nervous... but the date is going surprisingly well.", "How can mere flesh and blood keep up with my three interests, buy me presents, AND avoid missiles.", "Very impressive... BUT I WILL DESTR", "Ohh look stars!" };
            emoticonTimers.Add(new EmoticonTimer(
                8f,
                15f,
                new Dialog("Zurg the Zebra", convo7, animal, true, 50, "WhaleVoice")
            ));

            string[] defaultConvo = { "I CANNOT LOSE!", "I will chant the mantra of my inner zebra to let me win!", "ZEBRA ZEBRA GO GO GO", "ZEBRA ZEBRA NO NO NO", "... DONT MAKE FUN OF MY MANTRA" };
            defaultEmoticonTimer = new EmoticonTimer(
                5f,
                8f,
                new Dialog("Zurg the Zebra", defaultConvo, animal, true, 60, "WhaleVoice")
            );
        }


        currConvoIdx = 0;
        currTimer = emoticonTimers[currConvoIdx].ShallowCopy();
    }

    void Update()
    {
        if(runDialogTimers && !dialogManager.pauseGame && angerEmoticonTimer <= 0 && currTimer != null)
        {
            if(currTimer.emoticonWait > 0)
            {
                currTimer.emoticonWait -= Time.deltaTime;
            } else
            {
                emoteImage.enabled = true;
                reminderText.enabled = true;
                currTimer.emoticonDuration -= Time.deltaTime;
                if(!addedNotification)
                {
                    addedNotification = true;
                    audioManager.Play("Notification");
                }
            }

            if (currTimer.emoticonDuration <= 0)
            {
                reminderText.enabled = false;
                currTimer = emoticonTimers[currConvoIdx].ShallowCopy();
                emoteImage.sprite = angryEmoticon;
                angerEmoticonTimer = 5f;
                datePointManager.decreasePoints(20, "Inattentive Date");
                addedNotification = false;
            }

            if (Input.GetKeyDown(KeyCode.F) && currTimer.emoticonWait <= 0 && currTimer.emoticonDuration > 0)
            {
                dialogTrigger.dialog = currTimer.dialog;
                dialogTrigger.TriggerDialog();

                emoteImage.enabled = false;
                reminderText.enabled = false;
                addedNotification = false;

                if (currConvoIdx + 1 < emoticonTimers.Count)
                {
                    currTimer = emoticonTimers[currConvoIdx + 1].ShallowCopy();
                    currConvoIdx += 1;
                } else
                {
                    currTimer = defaultEmoticonTimer.ShallowCopy();
                }
            }
        } else if (angerEmoticonTimer > 0)
        {
            angerEmoticonTimer -= Time.deltaTime;
            if(angerEmoticonTimer <= 0)
            {
                emoteImage.enabled = false;
                emoteImage.sprite = alertEmoticon;
            }
        }
        if (loveEmoticonTimer > 0)
        {
            loveEmoticonTimer -= Time.deltaTime;
            if (loveEmoticonTimer <= 0)
            {
                emoteImage.enabled = false;
                emoteImage.sprite = alertEmoticon;
            }
        }
    }

    public void setLoveEmoticon()
    {
        loveEmoticonTimer = 0f;
        loveEmoticonTimer = 3f;
        if(emoteImage.sprite == alertEmoticon)
        {
            loveEmoticonTimer = 1f;

        }
        emoteImage.sprite = loveEmoticon;
        emoteImage.enabled = true;
    }

    public void setAngerEmoticon()
    {
        angerEmoticonTimer = 3f;
        loveEmoticonTimer = 0f;
        emoteImage.sprite = angryEmoticon;
        emoteImage.enabled = true;
    }
}
