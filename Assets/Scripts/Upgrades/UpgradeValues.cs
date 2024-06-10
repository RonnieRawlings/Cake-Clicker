// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeValues : MonoBehaviour
{
    public int upgradePrice;

    private void Awake()
    {
        if (StaticValues.loadedSave != null)
        {
            Debug.Log("Here");

            foreach (GameObjectData upgrade in StaticValues.loadedSave.upgradePositions)
            {
                if (upgrade.gameObjectName == transform.name)
                {
                    transform.parent = FindGameObjectInScene(upgrade.parentObj).transform;
                    transform.position = new Vector3(upgrade.x, upgrade.y, upgrade.z);
                    break;
                }
            }
        }       
    }

    public GameObject FindGameObjectInScene(string gameObjectName)
    {
        GameObject[] allGameObjects = Resources.FindObjectsOfTypeAll<GameObject>();
        foreach (GameObject gameObject in allGameObjects)
        {
            if (gameObject.name == gameObjectName)
            {
                return gameObject;
            }
        }
        return null;
    }

}
