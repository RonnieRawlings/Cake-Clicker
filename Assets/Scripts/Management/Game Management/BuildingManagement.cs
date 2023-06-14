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
            int.TryParse(building.transform.parent.GetChild(3).GetComponent<TextMeshProUGUI>().text, out int tryParse);
            if (building.text == "-")
            {

            }
            else if (StaticValues.currentCakes >= int.Parse(building.text.Replace(",", "")) || tryParse > 0)
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
        if (StaticValues.totalPlantations != 0)
            buildings.GetChild(1).GetChild(3).GetComponent<TextMeshProUGUI>().text = StaticValues.totalPlantations.ToString();
        if (StaticValues.totalFactories != 0)
            buildings.GetChild(2).GetChild(3).GetComponent<TextMeshProUGUI>().text = StaticValues.totalFactories.ToString();
        if (StaticValues.totalBanks != 0)
            buildings.GetChild(3).GetChild(3).GetComponent<TextMeshProUGUI>().text = StaticValues.totalBanks.ToString();

        int amount = 0;
        foreach (var obj in StaticValues.clickers)
        {
            if (obj.GetComponent<Image>().enabled)
            {
                amount++;
            }
        }
        if (amount !=0)
            buildings.GetChild(0).GetChild(3).GetComponent<TextMeshProUGUI>().text = amount.ToString();
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
    }
}
