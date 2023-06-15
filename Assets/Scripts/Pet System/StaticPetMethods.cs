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
        hatchedEgg.name = petRarity.GetChild(randomPet).GetComponent<Image>().sprite.name;

        SetNewInfo(infoToChange, petRarity.GetChild(randomPet));
    }

    public static void SetNewInfo(PetInfoChange infoChange, Transform orignalImage)
    {
        infoChange.Title = orignalImage.name;
        infoChange.Info = StaticPetInfo.petInfo[orignalImage.name][0];
        infoChange.ForceTextChange();

        StaticPetInfo.petsOwned[orignalImage.name]++;
        Debug.Log(StaticPetInfo.petsOwned[orignalImage.name]);
    }

    public static void LoadPets(Image hatchedEgg, PetInfoChange infoChange)
    {
        infoChange.Title = hatchedEgg.name;
        infoChange.Info = StaticPetInfo.petInfo[hatchedEgg.name][0];
        infoChange.ForceTextChange();

        hatchedEgg.sprite = Resources.Load("Sprites/Pet System/Common Pets/" + hatchedEgg.name, typeof (Sprite)) as Sprite;
    }
}
