using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject settingsWindow;
    public GameObject menuWindow;


    private void Start()
    {
        GoToMenu();
    }

    //Use this function to play a level
    public void GoToLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }

    //USe this to activate the settings page.
    public void GoToSettings()
    {
        menuWindow.SetActive(false);
        settingsWindow.SetActive(true);
    }

    //Use this to activate the menu page.
    public void GoToMenu()
    {
        menuWindow.SetActive(true);
        settingsWindow.SetActive(false);
    }

    
    public void ExitGame()
    {
        Application.Quit();
    }

}

