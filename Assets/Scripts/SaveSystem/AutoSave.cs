// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
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

        SaveSystem.SaveGame(gameSave);
        Debug.Log("Game Saved");
    }
}

