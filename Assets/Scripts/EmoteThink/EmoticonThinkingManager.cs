using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmoticonThinkingManager : MonoBehaviour
{
    public float emoteShowTimer = 3f;
    public float emoteHideTimer = 5f;

    public Sprite laugh;
    public Sprite music;
    public Sprite star;

    public string currSprite;
    public Image animalThinkImage;

    public DialogManager dialogManager;

    private bool showThoughtBubble;

    // Update is called once per frame
    void Update()
    {
        if(dialogManager.pauseGame)
        {
            return;
        }
        if (emoteHideTimer > 0)
        {
            emoteHideTimer -= Time.deltaTime;
        }
        else if (emoteHideTimer <= 0 && !showThoughtBubble)
        {
            int ranNum = Random.Range(1, 3);
            if (ranNum == 1)
            {
                currSprite = laugh.name;
                animalThinkImage.sprite = laugh;
            }
            if (ranNum == 2)
            {
                currSprite = music.name;
                animalThinkImage.sprite = music;
            }
            if (ranNum == 1)
            {
                currSprite = star.name;
                animalThinkImage.sprite = star;
            }
            animalThinkImage.enabled = true;
            showThoughtBubble = true;
            emoteShowTimer = 3f;
        }

        else if(emoteShowTimer > 0)
        {
            emoteShowTimer -= Time.deltaTime;
        }
        else if (emoteShowTimer <= 0 && emoteHideTimer <= 0)
        {
            emoteHideTimer = 5f;
            animalThinkImage.enabled = false;
            showThoughtBubble = false;
            currSprite = "";
        }
    }

    public void stopShowingThoughtBubble()
    {
        emoteHideTimer = 5f;
        emoteShowTimer = 0f;
        animalThinkImage.enabled = false;
        showThoughtBubble = false;
    }
}
