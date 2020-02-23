using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject firstCanvas;
    public GameObject secondCanvas;
    public GameObject thirdCanvas;
    private bool killedSecondPage;
    public void quitGame()
    {
        Application.Quit();
    }

    public void startGame()
    {
        Destroy(firstCanvas);
    }

    public void restartGame()
    {
        SceneManager.LoadScene("Scenes/Scene1");
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !killedSecondPage)
        {
            Destroy(secondCanvas);
            killedSecondPage = true;
        } else if(Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
