// Author - Ronnie Rawlings.

using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PetInfoChange : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private TextMeshProUGUI titleBox, infoBox;
    [SerializeField] private Image infoBackground;
    [SerializeField] protected string title, info;

    public string Title
    {
        set { title = value; }
    }

    public string Info
    {
        set { info = value; }
    }

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

    public void ForceTextChange()
    {
        titleBox.text = title;
        infoBox.text = info;
        infoBackground.enabled = true;
    }

    private void OnDisable()
    {
        titleBox.text = "";
        infoBox.text = "";
        infoBackground.enabled = false;
    }
}
