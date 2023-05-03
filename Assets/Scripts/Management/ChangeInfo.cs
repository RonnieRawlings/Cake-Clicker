// Author - Ronnie Rawlings.

using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChangeInfo : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TextMeshProUGUI infoText, titleText, priceText;
    public Image infoBackground;
    public string info, title, price;
    

    public void OnPointerEnter(PointerEventData eventData)
    {
        titleText.text = title;
        infoText.text = info;     
        priceText.text = price;
        infoBackground.enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        titleText.text = "";
        infoText.text = "";     
        priceText.text = "";
        infoBackground.enabled = false;
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
        infoBackground.enabled = false;
    }
}
