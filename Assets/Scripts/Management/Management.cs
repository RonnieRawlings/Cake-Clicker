// Author - Ronnie Rawlings.

using System.Collections;
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
        GameObject parent = GameObject.Find("CakeCanvas").transform.GetChild(1).GetChild(2).gameObject;

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
    }

    private void Start()
    {
        StartCoroutine(AddCPS());
        FillClickers();
        StartCoroutine(AnimateClickers());
    }

    // Update is called once per frame
    void Update()
    {
        int currentCakes = (int)StaticValues.currentCakes;

        cakeAmountText.text = "Cakes: " + currentCakes.ToString();
        cakesPerSecond.text = "per second: " + StaticValues.cakesPerSecond.ToString();
    }
}
