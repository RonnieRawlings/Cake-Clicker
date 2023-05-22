// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SystemUnlock : MonoBehaviour
{
    private int unlockAmount = 3000;
    
    public void UnlockSystemMeth()
    {
        if (StaticValues.currentCakes >= unlockAmount)
        {
            transform.Find("StoreTitle").GetComponent<TextMeshProUGUI>().text = "Pet Store";
            transform.Find("PurchaseSlots").gameObject.SetActive(true);
            Destroy(this);
        }
    }

    void Update()
    {
        UnlockSystemMeth();
    }
}
