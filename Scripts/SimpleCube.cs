using System;
using UnityEngine;

public class SimpleCube : AbstractCube
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        DestroyCube();
    }
}
