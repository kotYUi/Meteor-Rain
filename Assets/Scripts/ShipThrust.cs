using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipThrust : MonoBehaviour
{
    public float speed = 5.0f;

    private void Update()
    {
        var offset = Vector3.forward * Time.deltaTime * speed;
        this.transform.Translate(offset);
    }
}
