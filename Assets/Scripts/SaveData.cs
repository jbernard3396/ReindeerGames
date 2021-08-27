using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;



public class SaveData : MonoBehaviour
{
    public Save save;
    public OldSave partialSave;

    private void Awake()
    {
        LoadGame();
    }
    public void LoadGame()
    {
        // 1
        Debug.Log(Application.persistentDataPath + "/gamesave.save");
        if (File.Exists(Application.persistentDataPath + "/gamesave.save"))
        {
           

            // 2
            BinaryFormatter bf = new BinaryFormatter();
            BinaryFormatter oldbf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);

            try
            {
                Debug.Log("attempting to access new save file");
                save = (Save)bf.Deserialize(file);
                file.Close();
            }
            catch (Exception error)
            {
                try
                {
                    file.Close();
                    FileStream oldFile = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
                    Debug.Log("attempting to access old save file");
                    partialSave = (OldSave)oldbf.Deserialize(oldFile);
                    oldFile.Close();
                    Debug.Log("got old save now converting to new");
                    save = new Save(partialSave);
                } catch(Exception error2)
                {
                    Debug.Log(error2);
                    Debug.Log("save file has been corrupted, crashing");
                    //CreateSaveGameObject();
                }
            }

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
        save.collectedCoins = 0;
        save.initializeAchievements();

        return save;
    }

    private OldSave CreateOldSaveGameObject()
    {
        partialSave = new OldSave();

        for (int i = 0; i < 9; i++)
        {
            partialSave.reindeerCoins[i] = 0;
        }
        partialSave.totalCoins = 0;

        return partialSave;
    }

    public void saveGame()
    {

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        Debug.Log(save);
        bf.Serialize(file, save);
        file.Close();

        Debug.Log("Game Saved");
    }

    public void deleteSave()
    {
        save = CreateSaveGameObject();


        BinaryFormatter bf = new BinaryFormatter();
        FileStream newFile = File.Create(Application.persistentDataPath + "/gamesave.save");
        bf.Serialize(newFile, save);
        newFile.Close();

        Debug.Log("Game Saved");
    }
}
