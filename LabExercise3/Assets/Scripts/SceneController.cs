using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene("Town");
        Debug.Log("New Game starting!");
    }

    public void ContinueGame()
    {
        SceneManager.LoadScene("Overworld");
        Debug.Log("Continuing game!");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Quitting game....");
    }
}
