// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public static class StaticValues
{
    private static GameSave loadedSave;

    #region Overview Values

    public static float currentCakes = 0, clickAmount;
    public static float cakesPerSecond = 0.0f;
    public static List<TextMeshProUGUI> buildingPrices = new List<TextMeshProUGUI>();

    #endregion

    #region Clicker Values

    public static List<GameObject> clickers = new List<GameObject>();
    public static float clickerCPS = 0.5f, totalClickerCPS;

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

        if (loadedSave == null)
        {
            clickAmount = 1;
        }
        else
        {
            clickAmount = loadedSave.clickAmount; 
        }
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
