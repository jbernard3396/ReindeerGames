using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class SaveData : MonoBehaviour
{
    public Save save;

    private void Awake()
    {
        LoadGame();
    }
    public void LoadGame()
    {
        // 1
        if (File.Exists(Application.persistentDataPath + "/gamesave.save"))
        {
           

            // 2
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
            save = (Save)bf.Deserialize(file);
            file.Close();
        }
        else
        {
            Debug.Log("No game saved!");
            Debug.Log("Creating New Save");
            CreateSaveGameObject();
        }
    }

    private Save CreateSaveGameObject()
    {
        save = new Save();

        for(int i = 0; i< 9; i++)
        {
            save.reindeerCoins[i] = 0;
        }
        save.totalCoins = 0;
        save.bulletColor = "Red";

        return save;
    }

    public void saveGame()
    {

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        bf.Serialize(file, save);
        file.Close();

        Debug.Log("Game Saved");
    }

    public void deleteSave()
    {
        save = CreateSaveGameObject();

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        bf.Serialize(file, save);
        file.Close();

        Debug.Log("Game Saved");
    }
}
