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

    public bool inBattle;

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
        inBattle = false;
    }

    void Update()
    {
        if (state == GameState.FreeRoam)
        {
            // Disable battle scene, enable player controller camera
            inBattle = false;
            battle.gameObject.SetActive(false);
            traveler.playerCamera.gameObject.SetActive(true);
        }
        else if(state == GameState.BattleMode)
        {
            // Disable player controller camera, enable battle scene
            inBattle = true;
            traveler.playerCamera.gameObject.SetActive(false);
            battle.gameObject.SetActive(true);
        }

        if(Input.GetKeyDown(KeyCode.P))
        {
            inBattle = false;
            CheckActiveScene();
            state = GameState.FreeRoam;
        }
    }

    public void CheckActiveScene()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex == 1)
        {
            AudioManager.amInstance.PlayAudio(TrackID.Town);
        }
        else
        {
            AudioManager.amInstance.PlayAudio(TrackID.Overworld);
        }
    }
}
