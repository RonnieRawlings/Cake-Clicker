// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class StaticPetMethods
{
    public static void DecideOnPet(Transform petLocations, Image hatchedEgg, PetInfoChange infoToChange)
    {
        Transform petRarity = petLocations.GetChild(Random.Range(0, petLocations.childCount));
        int randomPet = Random.Range(0, petRarity.childCount);
        hatchedEgg.sprite = petRarity.GetChild(randomPet).GetComponent<Image>().sprite;

        SetNewInfo(infoToChange, petRarity.GetChild(randomPet));
    }

    public static void SetNewInfo(PetInfoChange infoChange, Transform orignalImage)
    {
        infoChange.Title = orignalImage.name;
        infoChange.Info = StaticPetInfo.petInfo[orignalImage.name];
        infoChange.ForceTextChange();
    }
}
