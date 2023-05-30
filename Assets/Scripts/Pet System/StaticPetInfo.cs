// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticPetInfo
{
    public static Dictionary<string, string> petInfo = new Dictionary<string, string>();

    static StaticPetInfo()
    {
        petInfo.Add("Rabbit", "A friendly creature that provides 2% more cakes per second!");
    }
}
