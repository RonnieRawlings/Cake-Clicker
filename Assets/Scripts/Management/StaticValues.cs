// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class StaticValues
{
    #region Overview Values

    public static float currentCakes = 0, clickAmount = 1;
    public static float cakesPerSecond = 0.0f;

    #endregion

    #region Clicker Values

    public static List<GameObject> clickers = new List<GameObject>();
    public static float clickerCPS = 0.5f, totalClickerCPS;

    #endregion

    #region Plantation Values

    public static List<GameObject> plantations = new List<GameObject>();
    public static float plantationCPS = 10.0f, totalPlantations = 0;

    #endregion

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
