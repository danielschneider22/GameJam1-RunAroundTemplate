using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DatePointManager : MonoBehaviour
{
    public int maxNumPoints;

    private int currNumPoints = 0;

    public TextMeshProUGUI pointsText;
    public Image dateSuccessBar;

    public Sprite goodSuccessBar;
    public Sprite badSuccessBar;
    public Animator pointChangeAnimator;

    public void Start()
    {
        pointsText.text = currNumPoints + "/" + maxNumPoints;
        dateSuccessBar.fillAmount = currNumPoints / maxNumPoints;
    }
    public void increasePoints(int numPoints, string reason)
    {
        currNumPoints += numPoints;
        pointsText.text = currNumPoints + "/" + maxNumPoints;
        dateSuccessBar.fillAmount = (float)currNumPoints / (float)maxNumPoints;
        if(dateSuccessBar.fillAmount >= .75f)
        {
            dateSuccessBar.sprite = goodSuccessBar;
        }
        pointChangeAnimator.SetTrigger("Point Change Positive");
    }

    public void decreasePoints(int numPoints, string reason)
    {
        currNumPoints -= numPoints;
        pointsText.text = currNumPoints + "/" + maxNumPoints;
        dateSuccessBar.fillAmount = currNumPoints / maxNumPoints;
        if (dateSuccessBar.fillAmount < .75f)
        {
            dateSuccessBar.sprite = badSuccessBar;
        }
        pointChangeAnimator.SetTrigger("Point Change Negative");
    }
}
