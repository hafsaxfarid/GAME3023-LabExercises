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

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnLoadSceneAction;
    }
    
    void OnLoadSceneAction(Scene scene, LoadSceneMode loadMode)
    {
        if (LastPortalExitSpawnName != "")
        {
            SpawnPoint[] exitSpawnPoints = GameObject.FindObjectsOfType<SpawnPoint>();

            foreach(SpawnPoint exitPoint in exitSpawnPoints)
            {
                if(exitPoint.name == LastPortalExitSpawnName)
                {
                    transform.position = exitPoint.transform.position;
                    
                    if(exitPoint.name != "PortalExitFromTown")
                    {
                        travelerLight.SetActive(false);
                    }
                    else
                    {
                        travelerLight.SetActive(true);
                    }
                }
            }
        }
    }
}
