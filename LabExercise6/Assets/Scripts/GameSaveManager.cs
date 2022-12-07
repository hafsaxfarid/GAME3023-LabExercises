using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// SAVING + LOADING using Binary Formatting
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[System.Serializable]
class SaveData
{
    public int playerSceneIndex;

    public float playerPositionX;
    public float playerPositionY;
    public float playerPositionZ;
}
public class GameSaveManager : MonoBehaviour
{
    public static GameSaveManager gsmInstance;

    private void Awake()
    {
        if (gsmInstance == null)
        {
            gsmInstance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [SerializeField]
    public GameObject playerPrefab;

    //public Transform player;

    public bool continueGame = false;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadGame();
        }
    }

    void SaveGame()
    {
        Time.timeScale = 1f;

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/MySaveData.dat");
        SaveData data = new SaveData();
        
        data.playerSceneIndex = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        data.playerPositionX = SpawnPoint.player.transform.position.x;
        data.playerPositionY = SpawnPoint.player.transform.position.y;
        data.playerPositionZ = SpawnPoint.player.transform.position.z;
        
        bf.Serialize(file, data);
        file.Close();
        
        Debug.Log("Game data saved!");

        //Debug.Log("[ " + data.playerPositionX  + " " + data.playerPositionY + " " + data.playerPositionZ + " ]");                     
    }                                           

    void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/MySaveData.dat"))
        {
            
            Time.timeScale = 1f;
            
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/MySaveData.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();

            var loadSceneIndex = data.playerSceneIndex;
            var x = data.playerPositionX;
            var y = data.playerPositionY;
            var z = data.playerPositionZ;

            LevelLoader.llInstance.nextLevel = true;

            UnityEngine.SceneManagement.SceneManager.LoadScene(loadSceneIndex);

            GameObject newPlayer = Instantiate(playerPrefab, new Vector3(x, y, z), Quaternion.identity);
            SpawnPoint.player = newPlayer.GetComponent<Traveler>();
            SpawnPoint.player.transform.position = new Vector3(x, y, z);

            if (loadSceneIndex == 1)
            {
                SpawnPoint.player.travelerLight.gameObject.SetActive(false);
                AudioManager.amInstance.PlayAudio(TrackID.Town);
            }
            else
            {
                SpawnPoint.player.travelerLight.gameObject.SetActive(true);
                AudioManager.amInstance.PlayAudio(TrackID.Overworld);
            }

            Debug.Log("Game data loaded!");
        }
        else
        {
            Debug.LogError("There is no saved data!");
        }
    }
    
    public void SaveButtonPressed()
    {
        Time.timeScale = 1f;
        SaveGame();
    }

    public void LoadButtonPressed()
    {
        continueGame = true;
        LoadGame();
    }
}
