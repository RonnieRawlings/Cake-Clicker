// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ApplyUpgrades : MonoBehaviour
{
    public void IncreaseClickAmount()
    {
        TextMeshProUGUI priceText = transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        int upgradePrice = int.Parse(priceText.text);

        if (StaticValues.currentCakes >= upgradePrice)
        {
            StaticValues.clickAmount++;
            StaticValues.currentCakes = StaticValues.currentCakes - upgradePrice;
            IncreaseUpgradePrice(priceText, upgradePrice);
        }
        
    }

    public void IncreaseUpgradePrice(TextMeshProUGUI textToChange, int currentPrice)
    {
        currentPrice = currentPrice * 3;
        textToChange.text = currentPrice.ToString();
    }
}
