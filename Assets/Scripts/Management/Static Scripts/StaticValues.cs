// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public static class StaticValues
{
    public static GameSave loadedSave;

    #region Overview Values

    public static float currentCakes = 0, clickAmount;
    public static float cakesPerSecond = 0.0f;
    public static List<TextMeshProUGUI> buildingPrices = new List<TextMeshProUGUI>();

    #endregion

    #region Clicker Values

    public static List<GameObject> clickers = new List<GameObject>();
    public static float clickerCPS = 0.5f, totalClickerCPS = 0;

    #endregion

    #region Plantation Values

    public static List<GameObject> plantations = new List<GameObject>();
    public static float plantationCPS = 10.0f, totalPlantations = 0;

    #endregion

    #region Factory Values

    public static List<GameObject> factories = new List<GameObject>();
    public static float factoryCPS = 50.0f, totalFactories = 0;

    #endregion

    #region Bank Values

    public static List<GameObject> banks = new List<GameObject>();
    public static float bankCPS = 120.0f, totalBanks = 0;

    #endregion

    static StaticValues()
    {
        loadedSave = SaveSystem.LoadGame();
        Debug.Log("This is called cunt");

        if (loadedSave != null)
        {
            clickAmount = loadedSave.clickAmount;
            cakesPerSecond = loadedSave.cakesPerSecond;
            currentCakes = loadedSave.currentCakes;

            buildingPrices = new List<TextMeshProUGUI>();
            SetObjectLists(buildingPrices, loadedSave.buildingPrices);

            totalPlantations = loadedSave.totalPlantations;
            totalBanks = loadedSave.totalBanks;
            totalFactories = loadedSave.totalFactories;

            clickerCPS = loadedSave.clickerCPS;
            totalClickerCPS = loadedSave.totalClickerCPS;
            clickers = new List<GameObject>();
            SetGameObjectLists(clickers, loadedSave.clickers);

            plantationCPS = loadedSave.plantationCPS;
            factoryCPS = loadedSave.factoryCPS;
            bankCPS = loadedSave.bankCPS;

            plantations = new List<GameObject>();
            SetGameObjectLists(plantations, loadedSave.plantations);

            factories = new List<GameObject>();
            SetGameObjectLists(factories, loadedSave.factories);

            banks = new List<GameObject>();
            SetGameObjectLists(banks, loadedSave.banks);
        }
        else
        {
            clickAmount = 1;
        }
    }

    public static void ResetValues()
    {
        currentCakes = 0;
        clickAmount = 1;
        cakesPerSecond = 0.0f;
        buildingPrices.Clear();
        clickers.Clear();
        clickerCPS = 0.5f;
        totalClickerCPS = 0;
        plantations.Clear();
        plantationCPS = 10.0f;
        totalPlantations = 0;
        factories.Clear();
        factoryCPS = 50.0f;
        totalFactories = 0;
        banks.Clear();
        bankCPS = 120.0f;
        totalBanks = 0;
    }


    public static void SetObjectLists(List<TextMeshProUGUI> listToFill, List<TextData> iterateList)
    {
        Transform canvasTransform = GameObject.Find("CakeCanvas").transform;
        foreach (TextData textData in iterateList)
        {
            Transform textObjectTransform = FindChildRecursive(canvasTransform, textData.gameObjectName);
            if (textObjectTransform != null)
            {
                TextMeshProUGUI textObject = textObjectTransform.GetComponent<TextMeshProUGUI>();
                if (textObject != null)
                {
                    textObject.text = textData.text;
                    listToFill.Add(textObject);
                }
            }
        }
    }

    public static void SetGameObjectLists(List<GameObject> listToFill, List<GameObjectData> iterateList)
    {
        Transform canvasTransform = GameObject.Find("CakeCanvas").transform;
        foreach (GameObjectData gameObjData in iterateList)
        {
            GameObject gameObjTransform = FindChildRecursive(canvasTransform, gameObjData.gameObjectName).gameObject;
            if (gameObjTransform != null)
            {
                gameObjTransform.GetComponent<Image>().enabled = gameObjData.isActive;               
                listToFill.Add(gameObjTransform.gameObject);
            }
        }
    }

    public static Transform FindChildRecursive(Transform parent, string name)
    {
        foreach (Transform child in parent)
        {
            if (child.name == name)
            {
                return child;
            }
            else
            {
                Transform result = FindChildRecursive(child, name);
                if (result != null)
                {
                    return result;
                }
            }
        }
        return null;
    }

    public static int CountEnabledClickers()
    {
        int count = 0;

        foreach (GameObject clicker in clickers)
        {
            if (clicker.GetComponent<Image>().enabled == true)
            {
                count++;
            }
        }

        return count;
    }

    public static void FillBuildingVisualSlots(Transform buildingSprites, List<GameObject> listToFill)
    {
        foreach (Transform child in buildingSprites)
        {
            listToFill.Add(child.gameObject);
        }
    }
}
