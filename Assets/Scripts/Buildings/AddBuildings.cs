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
        TextMeshProUGUI amountOwnedText = transform.GetChild(0).GetChild(2).GetComponent<TextMeshProUGUI>();       

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

            if (amountOwnedText.text == "")
            {
                amountOwnedText.text = "1";
            }
            else
            {
                int currentOwned = int.Parse(amountOwnedText.text);
                amountOwnedText.text = (currentOwned + 1).ToString();
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
