// Author - Ronnie Rawlings.

using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChangeInfo : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TextMeshProUGUI infoText;
    public Image infoBackground;
    public string info;
    

    public void OnPointerEnter(PointerEventData eventData)
    {
        infoText.text = info;
        infoBackground.enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        infoText.text = "";
        infoBackground.enabled = false;
    }

    private void OnDisable()
    {
        infoText.text = "";
        infoBackground.enabled = false;
    }
}
