using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndLogic : MonoBehaviour
{
    public bool isThereANextLevel;

    [Header("Winning Screen Objects")]
    public GameObject winScreen;
    public GameObject nextLevelButton;

    [Header("Losing Screen Objects")]
    public GameObject loseScreen;

    //This will load the winning game screen
    public void WinGameScreen()
    {
        winScreen.SetActive(true);
        loseScreen.SetActive(false);

        if (isThereANextLevel == true)
            nextLevelButton.SetActive(true);
    }

    //This will load the losing screen on the game
    public void LoseGameScreen()
    {
        winScreen.SetActive(false);
        loseScreen.SetActive(true);
    }

    //Use this to replay the current level
    public void ReplayLevel()
    {
        //Use the SceneManager class to load a level.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //We use this to exit the application.
    public void ExitGame()
    {
        Application.Quit();
    }

    //We use this with a button.
    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }
}
