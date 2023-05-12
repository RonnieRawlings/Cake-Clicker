// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManagement : MonoBehaviour
{
    #region Upgrades

    public List<GameObject> clickerUpgrades = new List<GameObject>();
    public List<bool> hasPurchasedClickerUpgrade = new List<bool>();

    public List<GameObject> plantationUpgrades = new List<GameObject>();
    public List<bool> hasPurchasedPlantationUpgrade = new List<bool>();

    #endregion

    public List<Transform> upgradePositions = new List<Transform>();

    public void VisibleClickerUpgrades()
    {
        int enabledClickers = StaticValues.CountEnabledClickers();
        for (int i = 0; i < clickerUpgrades.Count; i++)
        {
            if (enabledClickers >= (i == 0 ? 1 : i * 5) && !hasPurchasedClickerUpgrade[i])
            {
                hasPurchasedClickerUpgrade[i] = true;
                clickerUpgrades[i].transform.parent = upgradePositions[FindOpenPosition()].transform;
                clickerUpgrades[i].transform.position = clickerUpgrades[i].transform.parent.position;
            }
        }
    }

    public void VisiblePlantationUpgrades()
    {
        for (int i = 0; i < plantationUpgrades.Count; i++)
        {
            if (StaticValues.totalPlantations >= (i == 0 ? 1 : i * 5) && !hasPurchasedPlantationUpgrade[i])
            {
                hasPurchasedPlantationUpgrade[i] = true;
                plantationUpgrades[i].transform.parent = upgradePositions[FindOpenPosition()].transform;
                plantationUpgrades[i].transform.position = plantationUpgrades[i].transform.parent.position;
            }
        }
    }

    public int FindOpenPosition()
    {
        for (int index = 0; index < upgradePositions.Count; index++)
        {
            if (upgradePositions[index].childCount == 0)
            {
                upgradePositions[index].GetComponent<Image>().enabled = true;
                return index;
            }
        }

        return 4;
    }

    private void Update()
    {
        VisibleClickerUpgrades();
        VisiblePlantationUpgrades();
    }
}
