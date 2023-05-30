// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticPetInfo
{
    public static Dictionary<string, List<string>> petInfo = new Dictionary<string, List<string>>();
    public static Dictionary<string, int> petsOwned = new Dictionary<string, int>();

    static StaticPetInfo()
    {
        petInfo.Add("Rabbit", new List<string> { "A friendly creature that provides +2% more cakes per second!", "2" });
        petsOwned.Add("Rabbit", 0);
    }
}
