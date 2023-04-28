// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Management : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI cakeAmountText;

    // Update is called once per frame
    void Update()
    {
        cakeAmountText.text = "Cakes: " + StaticValues.currentCakes.ToString();
    }
}
