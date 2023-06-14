// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AutoSave : MonoBehaviour
{
    public float saveInterval = 30.0f;

    void Start()
    {
        InvokeRepeating("SaveGame", saveInterval, saveInterval);
    }

    void SaveGame()
    {
        GameSave gameSave = new GameSave();

        StaticValuesSave(gameSave); // Saves values from StaticValues Script.

        SaveSystem.SaveGame(gameSave);
        Debug.Log("Game Saved");
    }

    public void StaticValuesSave(GameSave gameSave)
    {
        gameSave.clickAmount = StaticValues.clickAmount;
        gameSave.cakesPerSecond = StaticValues.cakesPerSecond;
        gameSave.currentCakes = StaticValues.currentCakes;

        List<TextData> textDataList = new List<TextData>();
        foreach (TextMeshProUGUI textObject in StaticValues.buildingPrices)
        {
            TextData textData = new TextData();
            textData.text = textObject.text;
            textData.gameObjectName = textObject.gameObject.name;
            textDataList.Add(textData);
        }
        gameSave.buildingPrices = textDataList;

        gameSave.clickerCPS = StaticValues.clickerCPS;
        gameSave.plantationCPS = StaticValues.plantationCPS;
        gameSave.factoryCPS = StaticValues.factoryCPS;
        gameSave.bankCPS = StaticValues.bankCPS;
     
        List<GameObjectData> clickerData = new List<GameObjectData>();
        foreach (GameObject gameObj in StaticValues.clickers)
        {
            GameObjectData gameObjData = new GameObjectData();
            gameObjData.gameObjectName = gameObj.name;
            gameObjData.isActive = gameObj.GetComponent<Image>().enabled;
            clickerData.Add(gameObjData);
        }
        gameSave.clickers = clickerData;

        List<GameObjectData> plantationData = new List<GameObjectData>();
        foreach (GameObject gameObj in StaticValues.plantations)
        {
            GameObjectData gameObjData = new GameObjectData();
            gameObjData.gameObjectName = gameObj.name;
            gameObjData.isActive = gameObj.GetComponent<Image>().enabled;
            plantationData.Add(gameObjData);
        }
        gameSave.plantations = plantationData;

        List<GameObjectData> factoryData = new List<GameObjectData>();
        foreach (GameObject gameObj in StaticValues.factories)
        {
            GameObjectData gameObjData = new GameObjectData();
            gameObjData.gameObjectName = gameObj.name;
            gameObjData.isActive = gameObj.GetComponent<Image>().enabled;
            factoryData.Add(gameObjData);
        }
        gameSave.factories = factoryData;

        List<GameObjectData> bankData = new List<GameObjectData>();
        foreach (GameObject gameObj in StaticValues.banks)
        {
            GameObjectData gameObjData = new GameObjectData();
            gameObjData.gameObjectName = gameObj.name;
            gameObjData.isActive = gameObj.GetComponent<Image>().enabled;
            bankData.Add(gameObjData);
        }
        gameSave.banks = bankData;

        gameSave.totalPlantations = StaticValues.totalPlantations;
        gameSave.totalFactories = StaticValues.totalFactories;
        gameSave.totalBanks = StaticValues.totalBanks;
        gameSave.totalClickerCPS = StaticValues.totalClickerCPS;
    }
}

