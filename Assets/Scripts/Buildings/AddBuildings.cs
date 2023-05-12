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
        TextMeshProUGUI amountOwnedText = transform.GetChild(0).GetChild(3).GetComponent<TextMeshProUGUI>();       

        int upgradePrice = int.Parse(StaticValues.buildingPrices[0].text);
        bool allEnabled = true;

        if (StaticValues.currentCakes >= upgradePrice) 
        {
            foreach (GameObject clicker in StaticValues.clickers)
            {
                if (!clicker.GetComponent<Image>().enabled)
                {
                    clicker.GetComponent<Image>().enabled = true;
                    allEnabled = true;

                    foreach (GameObject otherClicker in StaticValues.clickers)
                    {
                        if (!otherClicker.GetComponent<Image>().enabled)
                        {
                            allEnabled = false;
                            break;
                        }
                    }

                    break;
                }
            }

            if (allEnabled)
            {
                PreventFurtherBuildings(amountOwnedText, StaticValues.buildingPrices[0]);
            }
            else
            {
                if (amountOwnedText.text == "")
                {
                    amountOwnedText.text = "1";
                }
                else
                {
                    int currentOwned = int.Parse(amountOwnedText.text);
                    amountOwnedText.text = (currentOwned + 1).ToString();
                }

                StaticValues.cakesPerSecond += StaticValues.clickerCPS;
                StaticValues.totalClickerCPS += StaticValues.clickerCPS;
                StaticValues.currentCakes -= upgradePrice;
                IncreaseUpgradePrice(StaticValues.buildingPrices[0], upgradePrice);
            }           
        }      
    }

    public void PreventFurtherBuildings(TextMeshProUGUI amountOwnedText, TextMeshProUGUI priceText)
    {
        amountOwnedText.text = "MAX";
        priceText.text = "-";

        GameObject clickerBuilding = transform.GetChild(0).gameObject;
        clickerBuilding.GetComponent<Button>().interactable = false;
    }

    public void AddPlantation()
    {
        TextMeshProUGUI amountOwnedText = transform.GetChild(1).GetChild(3).GetComponent<TextMeshProUGUI>();

        int upgradePrice = int.Parse(StaticValues.buildingPrices[1].text);

        if (StaticValues.currentCakes >= upgradePrice)
        {
            if (amountOwnedText.text == "")
            {
                amountOwnedText.text = "1";

                StaticValues.plantations[0].transform.parent.parent.gameObject.SetActive(true);
                StaticValues.plantations[0].GetComponent<Image>().enabled = true;
            }
            else
            {
                int currentOwned = int.Parse(amountOwnedText.text);

                if (StaticValues.plantations.Count > currentOwned)
                {
                    StaticValues.plantations[currentOwned].GetComponent<Image>().enabled = true;
                }
                
                amountOwnedText.text = (currentOwned + 1).ToString();
            }

            StaticValues.cakesPerSecond += StaticValues.plantationCPS;
            StaticValues.totalPlantations++;
            StaticValues.currentCakes -= upgradePrice;
            IncreaseUpgradePrice(StaticValues.buildingPrices[1], upgradePrice);
        }
    }

    public void IncreaseUpgradePrice(TextMeshProUGUI textToChange, int currentPrice)
    {
        currentPrice = currentPrice * 3;
        textToChange.text = currentPrice.ToString("N0");
        textToChange.gameObject.GetComponentInParent<ChangeInfo>().UpdateInfo(currentPrice.ToString());
    }
}
