using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetPlayerFaceShocked : MonoBehaviour
{
    public SpriteRenderer face;
    public Image avatarFace;
    public Sprite shockFacedSprite;
    public Sprite normalFacedSprite;

    private float surprisedLookLength;

    public void setPlayerFaceShocked(bool permanentlyShocked)
    {
        face.sprite = shockFacedSprite;
        avatarFace.sprite = shockFacedSprite;
        surprisedLookLength = permanentlyShocked ? 100000f : 2f;
    }
    public void Update()
    {
        if(surprisedLookLength < 0)
        {
            surprisedLookLength = 0;
            avatarFace.sprite = normalFacedSprite;
        } else
        {
            surprisedLookLength -= Time.deltaTime;
        }
    }
}
