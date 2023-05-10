// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public static class UsefulMethods
{
    public static void ChangeTextColour(TextMeshProUGUI textMeshProUGUI, string hexColor)
    {
        Color color;
        if (ColorUtility.TryParseHtmlString(hexColor, out color))
        {
            textMeshProUGUI.color = color;
        }
    }
}
