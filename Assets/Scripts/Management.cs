// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using TMPro;
using TreeEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class Management : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI cakeAmountText, cakesPerSecond;

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
        StaticValues.clickers[0].transform.localPosition = StaticValues.clickers[0].transform.localPosition + (StaticValues.clickers[0].transform.up * 5);
        yield return new WaitForSeconds(1f);
        StaticValues.clickers[0].transform.localPosition = StaticValues.clickers[0].transform.localPosition - (StaticValues.clickers[0].transform.up * 5);
        yield return new WaitForSeconds(1f);
        StartCoroutine(AnimateClickers());
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
