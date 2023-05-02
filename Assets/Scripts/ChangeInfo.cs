// Author - Ronnie Rawlings.

using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeInfo : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TextMeshProUGUI infoText;
    public string info;

    public void OnPointerEnter(PointerEventData eventData)
    {
        infoText.text = info;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        infoText.text = "";
    }
}
