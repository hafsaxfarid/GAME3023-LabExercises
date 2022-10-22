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
    }

    public void ContinueGame()
    {
        //SceneManager.LoadScene("Overworld");
        Time.timeScale = 1f;

        // load saved game
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
        SceneManager.LoadScene("MainMenu");
    }
}
