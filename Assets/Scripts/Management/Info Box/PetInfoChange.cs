// Author - Ronnie Rawlings.

using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PetInfoChange : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private TextMeshProUGUI titleBox, infoBox;
    [SerializeField] private Image infoBackground;
    [SerializeField] private string title, info;

    public void OnPointerEnter(PointerEventData eventData)
    {
        titleBox.text = title;
        infoBox.text = info;
        infoBackground.enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        titleBox.text = "";
        infoBox.text = "";
        infoBackground.enabled = false;
    }

    private void OnDisable()
    {
        titleBox.text = "";
        infoBox.text = "";
        infoBackground.enabled = false;
    }
}
