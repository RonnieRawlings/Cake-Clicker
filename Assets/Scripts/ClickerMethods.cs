// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickerMethods : MonoBehaviour
{
    public float speed = 10f;
    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();       
    }

    private void Update()
    {
        rectTransform.RotateAround(rectTransform.parent.position, Vector3.forward, speed * Time.deltaTime);
    }
}
