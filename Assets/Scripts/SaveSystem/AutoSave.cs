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

        // STATICVALUES SCRIPT SAVE

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

        List<GameObjectData> clickerData = new List<GameObjectData>();
        foreach (GameObject gameObj in StaticValues.clickers)
        {
            GameObjectData gameObjData = new GameObjectData();
            gameObjData.gameObjectName = gameObj.name;
            gameObjData.isActive = gameObj.GetComponent<Image>().enabled;
            clickerData.Add(gameObjData);
        }
        gameSave.clickers = clickerData;

        gameSave.totalPlantations = StaticValues.totalPlantations;
        gameSave.totalFactories = StaticValues.totalFactories;
        gameSave.totalBanks = StaticValues.totalBanks;

        SaveSystem.SaveGame(gameSave);
        Debug.Log("Game Saved");
    }
}

