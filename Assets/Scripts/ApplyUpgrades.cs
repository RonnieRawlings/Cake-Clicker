// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ApplyUpgrades : MonoBehaviour
{
    [SerializeField] private GameObject theCake;

    public void IncreaseCakesPerSecond()
    {
        TextMeshProUGUI priceText = transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        int upgradePrice = int.Parse(priceText.text);

        if (StaticValues.currentCakes >= upgradePrice) 
        {
            StaticValues.cakesPerSecond += 0.1f;
            StaticValues.currentCakes -= upgradePrice;
            IncreaseUpgradePrice(priceText, upgradePrice);
            SpawnClicker();
        }      
    }

    public void IncreaseClickAmount()
    {
        TextMeshProUGUI priceText = transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>();
        int upgradePrice = int.Parse(priceText.text);

        if (StaticValues.currentCakes >= upgradePrice)
        {
            StaticValues.clickAmount++;
            StaticValues.currentCakes = StaticValues.currentCakes - upgradePrice;
            IncreaseUpgradePrice(priceText, upgradePrice);
        }
    }

    public void SpawnClicker()
    {
        GameObject clickerObj = new GameObject("Clicker");
        clickerObj.transform.SetParent(theCake.transform);
        clickerObj.transform.localScale = new Vector3(0.25f, 0.25f, 0);

        Image image = clickerObj.AddComponent<Image>();
        image.sprite = Resources.Load<Sprite>("Sprites/Clicker Sprite");
        clickerObj.AddComponent<ClickerMethods>();
    }

    public void IncreaseUpgradePrice(TextMeshProUGUI textToChange, int currentPrice)
    {
        currentPrice = currentPrice * 3;
        textToChange.text = currentPrice.ToString();
    }
}
