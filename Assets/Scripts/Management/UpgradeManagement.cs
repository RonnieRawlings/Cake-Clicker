// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManagement : MonoBehaviour
{
    public List<GameObject> clickerUpgrades = new List<GameObject>();
    public List<bool> purchasedUpgrades = new List<bool>();
    public List<Transform> upgradePositions = new List<Transform>();

    public void VisibleClickerUpgrades()
    {
        if (StaticValues.CountEnabledClickers() > 0 && !purchasedUpgrades[0])
        {
            purchasedUpgrades[0] = true;
            clickerUpgrades[0].SetActive(true);
            
            clickerUpgrades[0].transform.parent = upgradePositions[FindOpenPosition()].transform;
            clickerUpgrades[0].transform.position = clickerUpgrades[0].transform.parent.position;
        }
        else if (StaticValues.CountEnabledClickers() >= 5 && !purchasedUpgrades[1])
        {
            purchasedUpgrades[1] = true;
            clickerUpgrades[1].SetActive(true);

            clickerUpgrades[1].transform.parent = upgradePositions[FindOpenPosition()].transform;
            clickerUpgrades[1].transform.position = clickerUpgrades[1].transform.parent.position;
        }
    }

    public int FindOpenPosition()
    {
        for (int index = 0; index < upgradePositions.Count; index++)
        {
            if (upgradePositions[index].childCount == 0)
            {
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
