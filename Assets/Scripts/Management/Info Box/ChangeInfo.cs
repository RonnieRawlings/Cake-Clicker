// Author - Ronnie Rawlings.

using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChangeInfo : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TextMeshProUGUI infoText, titleText, priceText, cpsText;
    public Image infoBackground;
    public string info, title, price, cps;
    

    public void OnPointerEnter(PointerEventData eventData)
    {
        titleText.text = title;
        infoText.text = info;     
        priceText.text = "<sprite=0> " + int.Parse(price).ToString("N0");
        cpsText.text = FindCPSValue();
        infoBackground.enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        titleText.text = "";
        infoText.text = "";     
        priceText.text = "";
        cpsText.text = "";
        infoBackground.enabled = false;
    }

    public string FindCPSValue()
    {
        if (cps != "")
        {
            Dictionary<string, string> cpsValues = new Dictionary<string, string>
            {
                { "AddClicker", cps + StaticValues.clickerCPS + " cakes per second." },
                { "AddPlantation", cps + StaticValues.plantationCPS + " cakes per second" },
                { "AddFactory", cps + StaticValues.factoryCPS + " cakes per second" }
            };

            if (cpsValues.ContainsKey(transform.name))
            {
                return cpsValues[transform.name];
            }
        }

        return "";
    }

    public void UpdateInfo(string newPrice)
    {
        price = newPrice;
    }

    private void OnDisable()
    {
        titleText.text = "";
        infoText.text = "";
        priceText.text = "";
        cpsText.text = "";
        infoBackground.enabled = false;
    }
}
