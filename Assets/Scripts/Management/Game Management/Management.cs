// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Management : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI cakeAmountText, cakesPerSecond;
    [SerializeField] private Canvas cakeCanvas;
    [SerializeField] private Font textFont;

    public void ResetSelectedButton()
    {
        EventSystem.current.SetSelectedGameObject(null);
    }

    public IEnumerator AddCPS()
    {
        yield return new WaitForSeconds(1f);
        StaticValues.currentCakes = StaticValues.currentCakes + StaticValues.cakesPerSecond;
        StartCoroutine(AddCPS());
    }

    public void FillClickers()
    {
        GameObject parent = GameObject.Find("CakeCanvas").transform.GetChild(1).GetChild(0).gameObject;

        foreach (Transform child in parent.transform)
        {
            StaticValues.clickers.Add(child.gameObject);
        }
    }

    public IEnumerator AnimateClickers()
    {
        foreach (GameObject clicker in StaticValues.clickers)
        {
            clicker.transform.localPosition = clicker.transform.localPosition + (clicker.transform.up * 5);
            yield return new WaitForSeconds(0.25f);
            clicker.transform.localPosition = clicker.transform.localPosition - (clicker.transform.up * 5);
            yield return new WaitForSeconds(0.25f);
        }
        
        StartCoroutine(AnimateClickers());
    }

    public void SpawnNumberText()
    {
        GameObject textObject = new GameObject();
        textObject.transform.SetParent(cakeCanvas.transform);

        textObject.transform.position = Input.mousePosition;
        Text text = textObject.AddComponent<Text>();

        text.raycastTarget = false;
        text.resizeTextForBestFit = true;
        text.text = "+" + StaticValues.clickAmount.ToString();
        text.font = textFont;

        StartCoroutine(FadeOut(textObject));
    }

    IEnumerator FadeOut(GameObject obj)
    {
        CanvasGroup canvasGroup = obj.AddComponent<CanvasGroup>();
        float duration = 3f;
        float timeElapsed = 0f;

        while (timeElapsed < duration)
        {
            canvasGroup.alpha = 1 - (timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        Destroy(obj);
    }

    public float AddPetMultipliers()
    {
        float amountToAdd = 0;
        foreach (KeyValuePair<string, int> pet in StaticPetInfo.petsOwned)
        {
            float multipleBy = int.Parse(StaticPetInfo.petInfo[pet.Key][1]) * pet.Value;
            amountToAdd += (multipleBy / 100) * StaticValues.cakesPerSecond;
        }
        return StaticValues.cakesPerSecond + amountToAdd;
    }

    private void Start()
    {
        if (StaticValues.clickers.Count == 0)
        {
            FillClickers();
        }

        StartCoroutine(AddCPS());
        StartCoroutine(AnimateClickers());
        
        Screen.fullScreen = false;
    }

    // Update is called once per frame
    void Update()
    {
        int currentCakes = (int)StaticValues.currentCakes;

        cakeAmountText.text = "Cakes: " + currentCakes.ToString("N0");
        cakesPerSecond.text = "per second: " + AddPetMultipliers().ToString();

        if (Screen.fullScreen)
        {
            Screen.fullScreen = false;
        }
    }
}
