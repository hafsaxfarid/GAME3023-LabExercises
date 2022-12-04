using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    [SerializeField]
    public Camera playerCamera;

    private void Start()
    {
        DestroyIfNotOriginal();

        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnLoadSceneAction;

        playerCamera.gameObject.SetActive(true);
    }

    private void Update()
    {
        DestroyIfNotOriginal();
    }

    private void DestroyIfNotOriginal()
    {
        if (SpawnPoint.player != this || UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "MainMenu")
        {
            Destroy(gameObject);
        }
    }

    void OnLoadSceneAction(Scene scene, LoadSceneMode loadMode)
    {
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