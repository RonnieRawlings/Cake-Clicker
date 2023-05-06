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
    public static float clickerCPS = 0.1f, totalClickerCPS;

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
}
