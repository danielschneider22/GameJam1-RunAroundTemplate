using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpeak : MonoBehaviour
{
    public SpriteRenderer speechBubble;
    public Sprite laugh;
    public Sprite music;
    public Sprite star;

    private AudioManager audioManager;

    public void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.A))
       {
            speechBubble.sprite = laugh;
            audioManager.Play("Laughing");
       }
        if (Input.GetKeyDown(KeyCode.S))
        {
            speechBubble.sprite = music;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            speechBubble.sprite = star;
        }
    }
}
