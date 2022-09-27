using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField]
    GameObject playerPrefab;

    private static Traveler player = null;

    void Start()
    {
        if(player == null && playerPrefab != null)
        {
            GameObject newPlayer = Instantiate(playerPrefab, transform.position, Quaternion.identity);
            player = newPlayer.GetComponent<Traveler>();
        }
    }
}
