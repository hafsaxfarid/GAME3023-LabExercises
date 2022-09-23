using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Traveler traveler = other.GetComponent<Traveler>();

        if(traveler != null)
        {
            SceneManager.LoadScene(gameObject.tag, LoadSceneMode.Single);
        }
    }
}
