using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuddleController : MonoBehaviour
{
    private void FixedUpdate()
    {
        transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                                        transform.position.y,
                                        transform.position.z);
    }
}
