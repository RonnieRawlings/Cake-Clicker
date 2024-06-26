// Author - Ronnie Rawlings.

using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Text;
using System.Collections.Generic;

[DataContract]
public class GameObjectData
{
    [DataMember]
    public string gameObjectName;
    [DataMember]
    public bool isActive;
    [DataMember]
    public string parentObj;
    [DataMember]
    public float x, y, z;
}

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
    [DataMember]
    public float totalPlantations, totalFactories, totalBanks, totalOffices;
    [DataMember]
    public List<GameObjectData> clickers = new List<GameObjectData>();
    [DataMember]
    public float clickerCPS, totalClickerCPS;
    [DataMember]
    public List<GameObjectData> plantations = new List<GameObjectData>();
    [DataMember]
    public List<GameObjectData> factories = new List<GameObjectData>();
    [DataMember]
    public List<GameObjectData> banks = new List<GameObjectData>();
    [DataMember]
    public List<GameObjectData> offices = new List<GameObjectData>();
    [DataMember]
    public float plantationCPS, factoryCPS, bankCPS, officeCPS;

    // UPGRADE MANAGEMENT SCRIPT
    [DataMember]
    public List<bool> hasPurchasedClickerUpgrade = new List<bool>();
    [DataMember]
    public List<bool> hasPurchasedPlantationUpgrade = new List<bool>();
    [DataMember]
    public List<bool> hasPurchasedFactoryUpgrade = new List<bool>();
    [DataMember]
    public List<bool> hasPurchasedBankUpgrade = new List<bool>();
    [DataMember]
    public List<bool> hasPurchasedOfficeUpgrade = new List<bool>();

    // UPGRADE VALUES SCRIPT
    [DataMember]
    public List<GameObjectData> upgradePositions = new List<GameObjectData>();

    // STATIC PET INFO SCRIPT
    [DataMember]
    public bool systemUnlocked;
    [DataMember]
    public Dictionary<string, List<string>> petInfo = new Dictionary<string, List<string>>();
    [DataMember]
    public Dictionary<string, int> petsOwned = new Dictionary<string, int>();
    [DataMember]
    public List<string> petEggs = new List<string>();
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
