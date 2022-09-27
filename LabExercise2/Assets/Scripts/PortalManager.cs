using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalManager : MonoBehaviour
{
    [SerializeField]
    private string portalExitSpawnName = "";

    private Traveler traveler;

    private void OnTriggerEnter2D(Collider2D other)
    {
        traveler = other.GetComponent<Traveler>();

        if (traveler != null)
        {
            traveler.LastPortalExitSpawnName = portalExitSpawnName;
            SceneManager.LoadScene(gameObject.tag, LoadSceneMode.Single);
        }
    }
}
