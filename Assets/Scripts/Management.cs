// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Management : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI cakeAmountText;

    public void ResetSelectedButton()
    {
        EventSystem.current.SetSelectedGameObject(null);
    }

    // Update is called once per frame
    void Update()
    {
        cakeAmountText.text = "Cakes: " + StaticValues.currentCakes.ToString();
    }
}
