// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeClick : MonoBehaviour
{
    /// <summary> method <c>AddACake</c> Increments the currentCakes value by 1. </summary>
    public void AddACake()
    {
        StaticValues.currentCakes++;
    }
}
