// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ApplyUpgrades : MonoBehaviour
{
    public List<Transform> upgradePositions = new List<Transform>();

    public void ClickerUpgrade(int upgradeNum)
    {
        GameObject upgrade = upgradePositions[FindUpgrade("Upgrade Clickers " + upgradeNum.ToString())].GetChild(0).gameObject;
        int upgradePrice = upgrade.GetComponent<UpgradeValues>().upgradePrice;

        if (StaticValues.currentCakes >= upgradePrice)
        {
            StaticValues.currentCakes -= upgradePrice;

            StaticValues.clickAmount = StaticValues.clickAmount * 2;

            StaticValues.clickerCPS = StaticValues.clickerCPS * 2;
            StaticValues.cakesPerSecond -= StaticValues.totalClickerCPS;
            StaticValues.totalClickerCPS = StaticValues.totalClickerCPS * 2;
            StaticValues.cakesPerSecond += StaticValues.totalClickerCPS;

            upgrade.transform.SetParent(transform.GetChild(0));
            upgrade.transform.SetSiblingIndex(upgradeNum - 1);
            upgrade.SetActive(false);
        }     
    }

    public int FindUpgrade(string upgradeName)
    {
        for (int index = 0; index < upgradePositions.Count; index++)
        {
            if (upgradePositions[index].childCount != 0)
            {
                if (upgradePositions[index].GetChild(0).name == upgradeName)
                {
                    return index;
                }
            }
        }

        return 4;
    }
}
