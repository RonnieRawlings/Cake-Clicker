using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{
    public void ResetSave()
    {
        PlayerPrefs.DeleteKey("save_game");
        Application.Quit();
    }
}
