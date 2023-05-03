// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManagement : MonoBehaviour
{
    public List<GameObject> clickerUpgrades = new List<GameObject>();
    public List<bool> purchasedUpgrades = new List<bool>();

    public void VisibleClickerUpgrades()
    {
        if (StaticValues.totalClickerCPS != 0f)
        {
            if (!purchasedUpgrades[0])
            {
                clickerUpgrades[0].SetActive(true);
                purchasedUpgrades[0] = true;
            }            
        }
    }

    private void Update()
    {
        VisibleClickerUpgrades();
    }
}
