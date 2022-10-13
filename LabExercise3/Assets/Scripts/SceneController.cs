using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private Traveler player;
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void NewGame()
    {
        SceneManager.LoadScene("Town");
        Time.timeScale = 1f;
    }

    public void ContinueGame()
    {
        SceneManager.LoadScene("Overworld");
        Time.timeScale = 1f;

        // TO DO IN FUTURE: load saved game
    }

    public void Settings()
    {
        Time.timeScale = 0f;
    }

    public void ExitSettings()
    {
        Time.timeScale = 1f;
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
    }
}
