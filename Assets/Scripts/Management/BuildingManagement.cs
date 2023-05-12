// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class BuildingManagement : MonoBehaviour
{
    public List<TextMeshProUGUI> buildingPrices = new List<TextMeshProUGUI>();

    public void EnableBuilding()
    {
        foreach (TextMeshProUGUI building in StaticValues.buildingPrices)
        {
            if (StaticValues.currentCakes >= int.Parse(building.text.Replace(",", "")))
            {
                if (building.GetComponentInParent<Button>().interactable == false)
                {
                    building.GetComponentInParent<Button>().interactable = true;
                    UsefulMethods.ChangeTextColour(building.gameObject.transform.parent.GetChild(0).GetComponent<TextMeshProUGUI>(), "#FFFFFF");
                    UsefulMethods.ChangeTextColour(building.gameObject.transform.parent.GetChild(1).GetComponent<TextMeshProUGUI>(), "#FFFFFF");
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Transform buildingsVisualised = GameObject.Find("CakeCanvas").transform.Find("BuildingsVisualised");
        StaticValues.FillBuildingVisualSlots(buildingsVisualised.GetChild(0).GetChild(1), StaticValues.plantations);
        StaticValues.buildingPrices = buildingPrices;    
    }

    void Update()
    {
        EnableBuilding();
    }
}
