// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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

        SaveSystem.SaveGame(gameSave);
        Debug.Log("Game Saved");
    }
}

