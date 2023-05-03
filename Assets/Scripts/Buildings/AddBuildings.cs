// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AddBuildings : MonoBehaviour
{
    [SerializeField] private GameObject theCake;

    public void AddClicker()
    {
        TextMeshProUGUI priceText = transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        int upgradePrice = int.Parse(priceText.text);

        if (StaticValues.currentCakes >= upgradePrice) 
        {
            StaticValues.cakesPerSecond += StaticValues.clickerCPS;
            StaticValues.totalClickerCPS += StaticValues.clickerCPS;
            StaticValues.currentCakes -= upgradePrice;
            IncreaseUpgradePrice(priceText, upgradePrice);

            foreach (GameObject clicker in StaticValues.clickers)
            {
                if (!clicker.GetComponent<Image>().enabled)
                {
                    clicker.GetComponent<Image>().enabled = true;
                    break;
                }
            }
        }      
    }

    public void IncreaseUpgradePrice(TextMeshProUGUI textToChange, int currentPrice)
    {
        currentPrice = currentPrice * 3;
        textToChange.text = currentPrice.ToString();
        textToChange.gameObject.GetComponentInParent<ChangeInfo>().UpdateInfo(currentPrice.ToString());
    }
}
