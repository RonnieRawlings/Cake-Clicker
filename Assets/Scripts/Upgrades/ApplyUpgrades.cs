// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ApplyUpgrades : MonoBehaviour
{
    public void ClickerUpgrade(int upgradeNum)
    {
        int upgradePrice = transform.GetChild(upgradeNum).GetComponent<UpgradeValues>().upgradePrice;

        if (StaticValues.currentCakes >= upgradePrice)
        {
            StaticValues.clickerCPS = StaticValues.clickerCPS * 2;
            StaticValues.cakesPerSecond -= StaticValues.totalClickerCPS;
            StaticValues.totalClickerCPS = StaticValues.totalClickerCPS * 2;
            StaticValues.cakesPerSecond += StaticValues.totalClickerCPS;

            transform.GetChild(upgradeNum).gameObject.SetActive(false);
        }     
    }
}
