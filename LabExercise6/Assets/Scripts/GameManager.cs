using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { FreeRoam, BattleMode}

public class GameManager : MonoBehaviour
{
    [SerializeField]
    Traveler traveler;

    [SerializeField]
    BattleSystem battle;

    public GameState state;

    public static GameManager gmInstance;

    private void Awake()
    {
        if (gmInstance == null)
        {
            gmInstance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        state = GameState.FreeRoam;
    }

    void Update()
    {
        if(state == GameState.FreeRoam)
        {
            // Disable battle scene, enable player controller camera
            battle.gameObject.SetActive(false);
            traveler.playerCamera.gameObject.SetActive(true);
        }
        else if(state == GameState.BattleMode)
        {
            // Disable player controller camera, enable battle scene
            traveler.playerCamera.gameObject.SetActive(false);
            battle.gameObject.SetActive(true);
        }

        if(Input.GetKeyDown(KeyCode.P))
        {
            state = GameState.FreeRoam;       
        }
    }
}
