using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EmoticonDialogPromptManager : MonoBehaviour
{
    public Sprite whale;
    public bool runDialogTimers;
    public Image emoteImage;
    public TextMeshProUGUI reminderText;
    public DialogManager dialogManager;
    public Sprite angryEmoticon;
    public Sprite alertEmoticon;
    public DatePointManager datePointManager;

    private List<EmoticonTimer> emoticonTimers;
    private EmoticonTimer currTimer;
    private DialogTrigger dialogTrigger;
    private int currConvoIdx;
    private float angerEmoticonTimer;

    void Awake()
    {
        emoticonTimers = new List<EmoticonTimer>();
        dialogTrigger = GetComponent<DialogTrigger>();
    }

    void Start()
    {
        string[] convo1 = { "Hi! I'm Willy the Whale. I like cuddles and blowing bubbles.", "I was really nervous about trying out this speed dating thing honestly...", "With the strangers, awkward conversations, and missiles being thrown at your date.", "It seemed like a lot for an introvert like me." };
        emoticonTimers.Add(new EmoticonTimer(
            5f,
            25f,
            new Dialog("Willy the Whale", convo1, whale, true, 10)
        ));

        string[] convo2 = { "One of the weirdest things for me about online dating is making eye contact.", "Being a whale, people find it very intimidating to look up all the time", "And I feel bad trying to make 'em look up.", "So I try and scrunch down my body as far as it can go.", "But it usually doesn't help :(" };
        emoticonTimers.Add(new EmoticonTimer(
            10f,
            20f,
            new Dialog("Willy the Whale", convo2, whale, true, 10)
        ));

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
            }

            if (currTimer.emoticonDuration <= 0)
            {
                reminderText.enabled = false;
                currTimer = emoticonTimers[currConvoIdx].ShallowCopy();
                emoteImage.sprite = angryEmoticon;
                angerEmoticonTimer = 5f;
                datePointManager.decreasePoints(20, "Inattentive Date");
            }

            if (Input.GetKeyDown(KeyCode.H) && currTimer.emoticonWait <= 0 && currTimer.emoticonDuration > 0)
            {
                dialogTrigger.dialog = currTimer.dialog;
                dialogTrigger.TriggerDialog();

                emoteImage.enabled = false;
                reminderText.enabled = false;

                if(currConvoIdx + 1 < emoticonTimers.Count)
                {
                    currTimer = emoticonTimers[currConvoIdx + 1].ShallowCopy();
                    currConvoIdx += 1;
                } else
                {
                    currTimer = null;
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
    }
}
