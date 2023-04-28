// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ApplyUpgrades : MonoBehaviour
{
    public void IncreaseClickAmount()
    {
        int upgradePrice = int.Parse(transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text);

        if (StaticValues.currentCakes >= upgradePrice)
        {
            StaticValues.clickAmount++;
            StaticValues.currentCakes = StaticValues.currentCakes - upgradePrice;
        }
        
    }
}
