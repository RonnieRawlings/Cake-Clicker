// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticPetInfo
{
    public static bool systemUnlocked;

    public static List<GameObject> petEggs = new List<GameObject>();

    public static Dictionary<string, List<string>> petInfo = new Dictionary<string, List<string>>();
    public static Dictionary<string, int> petsOwned = new Dictionary<string, int>();

    static StaticPetInfo()
    {
        if (StaticValues.loadedSave != null)
        {
            systemUnlocked = StaticValues.loadedSave.systemUnlocked;
            petInfo = StaticValues.loadedSave.petInfo;
            petsOwned = StaticValues.loadedSave.petsOwned;

            Debug.Log(petsOwned["Rabbit"]);
            Debug.Log(petsOwned["Fish"]);
        }
        else
        {
            petInfo.Add("Rabbit", new List<string> { "A friendly creature that provides +2% more cakes per second!", "2" });
            petsOwned.Add("Rabbit", 0);

            petInfo.Add("Fish", new List<string> { "A friendly sea creature that provides +2% more cakes per second!", "2" });
            petsOwned.Add("Fish", 0);
        }

        petEggs.Add(new GameObject());
        petEggs.Add(new GameObject());
        petEggs.Add(new GameObject());
    }
}
