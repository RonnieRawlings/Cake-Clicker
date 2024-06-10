// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PreventBoxRemained : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        PetInfoChange[] petInfoChangeScripts = FindObjectsOfType<PetInfoChange>();

        bool isPointerOver = false;
        foreach (PetInfoChange petObj in petInfoChangeScripts)
        {
            if (petObj.isPointerOver)
            {
                isPointerOver = true;
                break;
            }
        }

        // Resets obj if not over a pointer.
        if (!isPointerOver)
        {
            transform.GetComponentInChildren<Image>().enabled = false;

            foreach (TextMeshProUGUI comp in transform.GetComponentsInChildren<TextMeshProUGUI>())
            {
                comp.text = "";
            }
        }
    }
}
