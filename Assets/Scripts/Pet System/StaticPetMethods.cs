// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class StaticPetMethods
{
    public static void DecideOnPet(Transform petLocations, Image hatchedEgg)
    {
        Transform petRarity = petLocations.GetChild(Random.Range(0, petLocations.childCount));
        hatchedEgg.sprite = petRarity.GetChild(Random.Range(0, petRarity.childCount)).GetComponent<Image>().sprite;
    }
}
