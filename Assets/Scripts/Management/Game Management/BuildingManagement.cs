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
    public List<TextMeshProUGUI> example;
    public List<string> exampleInts;

    public void EnableBuilding()
    {
        foreach (TextMeshProUGUI building in StaticValues.buildingPrices)
        {
            if (building.text == "-")
            {

            }
            else if (StaticValues.currentCakes >= int.Parse(building.text.Replace(",", "")))
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

    public void LoadBuildingVisuals()
    {
        Transform buildings = GameObject.Find("CakeCanvas").transform.GetChild(3).GetChild(2);
        buildings.GetChild(1).GetChild(3).GetComponent<TextMeshProUGUI>().text = StaticValues.totalPlantations.ToString();
        buildings.GetChild(2).GetChild(3).GetComponent<TextMeshProUGUI>().text = StaticValues.totalFactories.ToString();
        buildings.GetChild(3).GetChild(3).GetComponent<TextMeshProUGUI>().text = StaticValues.totalBanks.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        Transform buildingsVisualised = GameObject.Find("CakeCanvas").transform.Find("BuildingsVisualised");
        StaticValues.FillBuildingVisualSlots(buildingsVisualised.GetChild(0).GetChild(1), StaticValues.plantations);
        StaticValues.FillBuildingVisualSlots(buildingsVisualised.GetChild(1).GetChild(1), StaticValues.factories);
        StaticValues.FillBuildingVisualSlots(buildingsVisualised.GetChild(2).GetChild(1), StaticValues.banks);

        if (StaticValues.buildingPrices.Count == 0)
        {
            StaticValues.buildingPrices = buildingPrices;
            Debug.Log("THIS IS CALLED");
        }
        else
        {
            LoadBuildingVisuals();
        }

        if (StaticValues.loadedSave != null)
        {
            Debug.Log(StaticValues.loadedSave.buildingPrices.Count);
        }
        
    }

    void Update()
    {
        EnableBuilding();
        example = StaticValues.buildingPrices;

        exampleInts = new List<string>();
        foreach (var item in example)
        {            
            exampleInts.Add(item.text);
        }
    }
}
