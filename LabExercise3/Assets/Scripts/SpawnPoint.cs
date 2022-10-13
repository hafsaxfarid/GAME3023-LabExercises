using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField]
    GameObject playerPrefab;

    public static Traveler player = null;

    //public static Traveler Player
    //{
    //    get;
    //    private set;
    //}

    void Start()
    {
        if (player == null && playerPrefab != null)
        {
            GameObject newPlayer = Instantiate(playerPrefab, transform.position, Quaternion.identity);
            player = newPlayer.GetComponent<Traveler>();

            //if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex == 1)
            if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Overworld")
            {
                player.travelerLight.gameObject.SetActive(true);
                //Debug.Log("Spawned in Overworld!");
            }
            else
            {
                player.travelerLight.gameObject.SetActive(false);
                //Debug.Log("Spawned in Town!");
            }
        }
    }
}
