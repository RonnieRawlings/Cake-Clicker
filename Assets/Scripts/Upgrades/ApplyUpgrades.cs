// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

            RepositionUpgrades();
        }     
    }

    public void PlantationUpgrade(int upgradeNum)
    {
        GameObject upgrade = upgradePositions[FindUpgrade("Upgrade Plantation " + upgradeNum.ToString())].GetChild(0).gameObject;
        int upgradePrice = upgrade.GetComponent<UpgradeValues>().upgradePrice;

        if (StaticValues.currentCakes >= upgradePrice)
        {
            StaticValues.currentCakes -= upgradePrice;
            StaticValues.cakesPerSecond -= (StaticValues.totalPlantations * StaticValues.plantationCPS);
            StaticValues.plantationCPS = StaticValues.plantationCPS * 2;
            StaticValues.cakesPerSecond += (StaticValues.totalPlantations * StaticValues.plantationCPS);

            upgrade.transform.SetParent(transform.GetChild(0));
            upgrade.transform.SetSiblingIndex(upgradeNum - 1);
            upgrade.SetActive(false);

            RepositionUpgrades();
        }
    }

    public void FactoryUpgrade(int upgradeNum)
    {
        GameObject upgrade = upgradePositions[FindUpgrade("Upgrade Factory " + upgradeNum.ToString())].GetChild(0).gameObject;
        int upgradePrice = upgrade.GetComponent<UpgradeValues>().upgradePrice;

        if (StaticValues.currentCakes >= upgradePrice)
        {
            StaticValues.currentCakes -= upgradePrice;
            StaticValues.cakesPerSecond -= (StaticValues.totalFactories * StaticValues.factoryCPS);
            StaticValues.factoryCPS = StaticValues.factoryCPS * 2;
            StaticValues.cakesPerSecond += (StaticValues.totalFactories * StaticValues.factoryCPS);

            upgrade.transform.SetParent(transform.GetChild(0));
            upgrade.transform.SetSiblingIndex(upgradeNum - 1);
            upgrade.SetActive(false);

            RepositionUpgrades();
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

    public void RepositionUpgrades()
    {
        for (int index = 0; index < upgradePositions.Count; index++)
        {
            if (upgradePositions[index].childCount == 0)
            {
                for (int next = index + 1; next < upgradePositions.Count; next++)
                {
                    if (upgradePositions[next].childCount != 0)
                    {
                        upgradePositions[next].GetChild(0).parent = upgradePositions[index];
                        upgradePositions[index].GetChild(0).position = upgradePositions[index].position;
                        break;
                    }
                }
            }
        }
    }
}
