// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    private void Start()
    {
        StartCoroutine(AddCPS());
    }

    // Update is called once per frame
    void Update()
    {
        cakeAmountText.text = "Cakes: " + StaticValues.currentCakes.ToString();
        cakesPerSecond.text = "per second: " + StaticValues.cakesPerSecond.ToString();
    }
}
