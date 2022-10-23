using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private static SceneController scInstance;

    private void Awake()
    {
        if (scInstance == null)
        {
            scInstance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void NewGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Town");
        GameSaveManager.gsmInstance.continueGame = false;
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
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
