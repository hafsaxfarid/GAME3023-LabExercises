using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void NewGame()
    {
        SceneManager.LoadScene("Town");
        Time.timeScale = 1f;
        Debug.Log("New Game starting!");
    }

    public void ContinueGame()
    {
        SceneManager.LoadScene("Overworld");
        Time.timeScale = 1f;
        Debug.Log("Continuing game");

        // TO DO IN FUTURE: load saved game
    }

    public void Settings()
    {
        Time.timeScale = 0f;
        Debug.Log("Game paused");
    }

    public void ExitSettings()
    {
        Time.timeScale = 1f;
        Debug.Log("Game unpaused");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Quitting game....");
    }

    public void MainMenu()
    {
        // figure out how to remove pip from scene when loading back to main menu
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Main Menu loading...");
    }
}
