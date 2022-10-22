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
    //public Transform player;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            SaveGame();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadGame();
        }
    }

    void SaveGame()
    {
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
    }
    
    void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/MySaveData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/MySaveData.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();
            
            var loadSceneIndex = data.playerSceneIndex;
            var x = data.playerPositionX;
            var y = data.playerPositionY;
            var z = data.playerPositionZ;

            Time.timeScale = 1f;

            UnityEngine.SceneManagement.SceneManager.LoadScene(loadSceneIndex);
            //player.gameObject.GetComponent<Traveler>();
            SpawnPoint.player.transform.position = new Vector3(x, y, z);

            Debug.Log("Game data loaded!");
        }
        else
        {
            Debug.LogError("There is no saved data!");
        }
    }
    
    public void SaveButtonPressed()
    {
        SaveGame();
    }

    public void LoadButtonPressed()
    {
        LoadGame();
    }
}
