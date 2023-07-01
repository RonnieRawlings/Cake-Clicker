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
        int upgradePrice = int.Parse(StaticValues.buildingPrices[0].text.Replace(",", ""));
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
        int upgradePrice = int.Parse(StaticValues.buildingPrices[1].text.Replace(",", ""));

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

    public void AddFactory()
    {
        TextMeshProUGUI amountOwnedText = transform.GetChild(2).GetChild(3).GetComponent<TextMeshProUGUI>();
        int upgradePrice = int.Parse(StaticValues.buildingPrices[2].text.Replace(",", ""));

        if (StaticValues.currentCakes >= upgradePrice)
        {
            if (amountOwnedText.text == "")
            {
                amountOwnedText.text = "1";

                StaticValues.factories[0].transform.parent.parent.gameObject.SetActive(true);
                StaticValues.factories[0].GetComponent<Image>().enabled = true;
            }
            else
            {
                int currentOwned = int.Parse(amountOwnedText.text);

                if (StaticValues.factories.Count > currentOwned)
                {
                    StaticValues.factories[currentOwned].GetComponent<Image>().enabled = true;
                }

                amountOwnedText.text = (currentOwned + 1).ToString();
            }

            StaticValues.cakesPerSecond += StaticValues.factoryCPS;
            StaticValues.totalFactories++;
            StaticValues.currentCakes -= upgradePrice;
            IncreaseUpgradePrice(StaticValues.buildingPrices[2], upgradePrice);
        }
    }

    public void AddBank()
    {
        TextMeshProUGUI amountOwnedText = transform.GetChild(3).GetChild(3).GetComponent<TextMeshProUGUI>();
        int upgradePrice = int.Parse(StaticValues.buildingPrices[3].text.Replace(",", ""));

        if (StaticValues.currentCakes >= upgradePrice)
        {
            if (amountOwnedText.text == "")
            {
                amountOwnedText.text = "1";

                StaticValues.banks[0].transform.parent.parent.gameObject.SetActive(true);
                StaticValues.banks[0].GetComponent<Image>().enabled = true;
            }
            else
            {
                int currentOwned = int.Parse(amountOwnedText.text);

                if (StaticValues.banks.Count > currentOwned)
                {
                    StaticValues.banks[currentOwned].GetComponent<Image>().enabled = true;
                }

                amountOwnedText.text = (currentOwned + 1).ToString();
            }

            StaticValues.cakesPerSecond += StaticValues.bankCPS;
            StaticValues.totalBanks++;
            StaticValues.currentCakes -= upgradePrice;
            IncreaseUpgradePrice(StaticValues.buildingPrices[3], upgradePrice);
        }
    }

    public void AddOffice()
    {
        TextMeshProUGUI amountOwnedText = transform.GetChild(4).GetChild(3).GetComponent<TextMeshProUGUI>();
        int upgradePrice = int.Parse(StaticValues.buildingPrices[4].text.Replace(",", ""));

        if (StaticValues.currentCakes >= upgradePrice)
        {
            if (amountOwnedText.text == "")
            {
                amountOwnedText.text = "1";

                StaticValues.offices[0].transform.parent.parent.gameObject.SetActive(true);
                StaticValues.offices[0].GetComponent<Image>().enabled = true;
            }
            else
            {
                int currentOwned = int.Parse(amountOwnedText.text);

                if (StaticValues.offices.Count > currentOwned)
                {
                    StaticValues.offices[currentOwned].GetComponent<Image>().enabled = true;
                }

                amountOwnedText.text = (currentOwned + 1).ToString();
            }

            StaticValues.cakesPerSecond += StaticValues.officeCPS;
            StaticValues.totalOffices++;
            StaticValues.currentCakes -= upgradePrice;
            IncreaseUpgradePrice(StaticValues.buildingPrices[4], upgradePrice);
        }
    }

    public void IncreaseUpgradePrice(TextMeshProUGUI textToChange, int currentPrice)
    {
        currentPrice = (int)(currentPrice * 1.4f);
        textToChange.text = currentPrice.ToString("N0");
        textToChange.gameObject.GetComponentInParent<ChangeInfo>().UpdateInfo(currentPrice.ToString());
    }
}
