// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCursor : MonoBehaviour
{
    [SerializeField] private int offset;

    // Update is called once per frame
    void Update()
    {
        float bottomBound = Camera.main.transform.position.y - Camera.main.orthographicSize;
        float topBound = Camera.main.transform.position.y + Camera.main.orthographicSize;

        float y = Mathf.Clamp(Input.mousePosition.y + offset, bottomBound, 99999);
        transform.position = new Vector2(transform.position.x, y);
    }
}
