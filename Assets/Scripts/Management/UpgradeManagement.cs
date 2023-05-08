// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManagement : MonoBehaviour
{
    public List<GameObject> clickerUpgrades = new List<GameObject>();
    public List<bool> purchasedUpgrades = new List<bool>();
    public List<Transform> upgradePositions = new List<Transform>();

    public void VisibleClickerUpgrades()
    {
        int enabledClickers = StaticValues.CountEnabledClickers();
        for (int i = 0; i < clickerUpgrades.Count; i++)
        {
            if (enabledClickers >= (i == 0 ? 1 : i * 5) && !purchasedUpgrades[i])
            {
                purchasedUpgrades[i] = true;
                clickerUpgrades[i].SetActive(true);

                clickerUpgrades[i].transform.parent = upgradePositions[FindOpenPosition()].transform;
                clickerUpgrades[i].transform.position = clickerUpgrades[i].transform.parent.position;
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
    }
}
