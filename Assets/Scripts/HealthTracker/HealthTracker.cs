using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthTracker : MonoBehaviour
{
    public int maxHealth = 5;
    public int currHealth = 5;

    public GridLayoutGroup gridLayoutGroup;
    public GameObject heart;

    public Sprite emptyHeart;
    public Sprite fullHeart;

    public GameOverManager gameOverManager;
    void Start()
    {
        for(var i = 0; i < maxHealth; i++)
        {
            GameObject newHeart = Instantiate(heart);
            newHeart.transform.SetParent(gridLayoutGroup.transform);
            newHeart.transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    public void loseHealth()
    {
        currHealth--;
        if(currHealth >= 0)
        {
            Transform child = gridLayoutGroup.transform.GetChild(currHealth);
            child.gameObject.GetComponent<Image>().sprite = emptyHeart;
        }
        if (currHealth == 0)
        {
            gameOverManager.gameOver("health");
        }
    }

    public void gainHealth()
    {
        currHealth++;
        if (currHealth >= 0)
        {
            Transform child = gridLayoutGroup.transform.GetChild(currHealth - 1);
            child.gameObject.GetComponent<Image>().sprite = fullHeart;
        }
    }
}
