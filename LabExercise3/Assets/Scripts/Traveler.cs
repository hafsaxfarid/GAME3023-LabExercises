using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Traveler : MonoBehaviour
{
    public string LastPortalExitSpawnName
    {
        get;
        set;
    } = ""; // sets to nothing by default 

    [SerializeField]
    public GameObject travelerLight;

    [SerializeField]
    public GameObject playerHUD;

    private void Start()
    {
        DestroyIfNotOriginal();

        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnLoadSceneAction;
    }
    
    private void DestroyIfNotOriginal()
    {
        if(SpawnPoint.player != this)
        {
            Destroy(gameObject);
        }
    }

    void OnLoadSceneAction(Scene scene, LoadSceneMode loadMode)
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
            
            if (LastPortalExitSpawnName != "")
            {
                SpawnPoint[] exitSpawnPoints = GameObject.FindObjectsOfType<SpawnPoint>();

                foreach (SpawnPoint exitPoint in exitSpawnPoints)
                {
                    if (exitPoint.name == LastPortalExitSpawnName)
                    {
                        transform.position = exitPoint.transform.position;

                        if (exitPoint.name == "PortalExitFromTown")
                        {
                            travelerLight.SetActive(true);
                            playerHUD.SetActive(true);
                        }
                        else
                        {
                            travelerLight.SetActive(false);
                            playerHUD.SetActive(true);
                        }
                    }
                }
            }
        }
    }
}
