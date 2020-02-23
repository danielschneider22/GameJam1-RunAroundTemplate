using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpeak : MonoBehaviour
{
    public SpriteRenderer speechBubble;
    public Sprite laugh;
    public Sprite music;
    public Sprite star;
    public float speechBubbleTimer;
    public DialogManager dialogManager;
    public EmoticonThinkingManager emoticonThinkingManager;
    public DatePointManager datePointManager;
    public int pointsGained = 10;

    private AudioManager audioManager;

    public void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    void Update()
    {
       if(dialogManager.pauseGame)
        {
            return;
        }
       if(Input.GetKeyDown(KeyCode.A))
       {
            speechBubble.sprite = laugh;
            audioManager.Play("Laughing");
            speechBubbleTimer = 1f;
            speechBubble.enabled = true;
            checkEnemyThoughts(laugh.name);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            speechBubble.sprite = music;
            audioManager.Play("Humming");
            speechBubbleTimer = 1f;
            speechBubble.enabled = true;
            checkEnemyThoughts(music.name);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            speechBubble.sprite = star;
            audioManager.Play("Impressed");
            speechBubbleTimer = 1f;
            speechBubble.enabled = true;
            checkEnemyThoughts(star.name);
        }
       else if(speechBubbleTimer > 0)
        {
            speechBubbleTimer -= Time.deltaTime;
            if(speechBubbleTimer <= 0)
            {
                speechBubble.enabled = false;
            }
        }
    }

    private void checkEnemyThoughts(string name)
    {
        if (emoticonThinkingManager.currSprite == name)
        {
            datePointManager.increasePoints(pointsGained, "Found their interest!");
            emoticonThinkingManager.stopShowingThoughtBubble();
        } else if (emoticonThinkingManager.currSprite != "" && emoticonThinkingManager.currSprite != name)
        {
            datePointManager.decreasePoints(5, "Not what they want now!");
            emoticonThinkingManager.stopShowingThoughtBubble();
        }
    }
}
