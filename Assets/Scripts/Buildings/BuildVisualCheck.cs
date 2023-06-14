using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildVisualCheck : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        foreach (Transform child in transform)
        {
            if (child.GetChild(1).GetChild(0).GetComponent<Image>().enabled)
            {
                child.gameObject.SetActive(true);
            }
        }
    }
}
