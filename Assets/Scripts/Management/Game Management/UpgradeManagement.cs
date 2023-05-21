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

    public List<GameObject> factoryUpgrades = new List<GameObject>();
    public List<bool> hasPurchasedFactoryUpgrade = new List<bool>();

    public List<GameObject> bankUpgrades = new List<GameObject>();
    public List<bool> hasPurchasedBankUpgrade = new List<bool>();

    #endregion

    public List<Transform> upgradePositions = new List<Transform>();
    private int clickerOffset, plantationOffset, factoryOffset, bankOffset;

    public void VisibleClickerUpgrades()
    {
        int enabledClickers = StaticValues.CountEnabledClickers();
        if (FindOpenPosition() == 5)
        {
            clickerOffset++;
        }
        else
        {
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
    }

    public void VisiblePlantationUpgrades()
    {
        if (FindOpenPosition() == 5)
        {
            plantationOffset++;
        }
        else
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
    }

    public void VisibleFactoryUpgrades()
    {
        if (FindOpenPosition() == 5)
        {
            factoryOffset++;
        }
        else
        {
            for (int i = 0; i < factoryUpgrades.Count; i++)
            {
                if ((StaticValues.totalFactories - factoryOffset) >= (i == 0 ? 1 : i * 5) && !hasPurchasedFactoryUpgrade[i])
                {
                    hasPurchasedFactoryUpgrade[i] = true;
                    factoryUpgrades[i].transform.parent = upgradePositions[FindOpenPosition()].transform;
                    factoryUpgrades[i].transform.position = factoryUpgrades[i].transform.parent.position;
                }
            }
        }       
    }

    public void VisibleBankUpgrades()
    {
        if (FindOpenPosition() == 5)
        {
            bankOffset++;
        }
        else
        {
            for (int i = 0; i < bankUpgrades.Count; i++)
            {
                if ((StaticValues.totalBanks - bankOffset) >= (i == 0 ? 1 : i * 5) && !hasPurchasedBankUpgrade[i])
                {
                    hasPurchasedBankUpgrade[i] = true;
                    bankUpgrades[i].transform.parent = upgradePositions[FindOpenPosition()].transform;
                    bankUpgrades[i].transform.position = bankUpgrades[i].transform.parent.position;
                }
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

        return 5;
    }
}
