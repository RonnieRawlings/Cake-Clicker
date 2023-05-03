// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCursor : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Vector3 offset = new Vector3(-60, 0);
        transform.position = new Vector2(transform.position.x, Input.mousePosition.y);
    }
}
