// Author - Ronnie Rawlings.

using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Text;
using System.Collections.Generic;
using TMPro;

[DataContract]
public class TextData
{
    [DataMember]
    public string text;
    [DataMember]
    public string gameObjectName;
}

[DataContract]
public class GameSave
{
    // STATICVALUES SCRIPT
    [DataMember]
    public float currentCakes, clickAmount, cakesPerSecond;
    [DataMember]
    public List<TextData> buildingPrices = new List<TextData>();
}

public static class SaveSystem
{
    public static void SaveGame(GameSave gameSave)
    {
        MemoryStream stream = new MemoryStream();
        DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(GameSave));
        serializer.WriteObject(stream, gameSave);
        string jsonData = Encoding.UTF8.GetString(stream.ToArray());
        PlayerPrefs.SetString("save_game", jsonData);
    }

    public static GameSave LoadGame()
    {
        if (PlayerPrefs.HasKey("save_game"))
        {
            string jsonData = PlayerPrefs.GetString("save_game");
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonData));
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(GameSave));
            GameSave gameSave = (GameSave)serializer.ReadObject(stream);
            return gameSave;
        }
        else
        {
            Debug.Log("No save data found");
            return null;
        }
    }
}
