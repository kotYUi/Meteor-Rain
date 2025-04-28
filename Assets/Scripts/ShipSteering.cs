using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSteering : MonoBehaviour
{
    public float turnRate = 6f;
    public float levelDamping = 1f;

    private void Update()
    {
        var steeringInput = InputManager.instance.steering.delta;
        var rotation = new Vector2();

        rotation.y = steeringInput.y;
        rotation.x = steeringInput.x;

        rotation *= turnRate;
        rotation.x = Mathf.Clamp(rotation.x, -Mathf.PI * 0.9f, Mathf.PI * 0.9f);
        var newOrentation = Quaternion.Euler(rotation);
        transform.rotation *= newOrentation;
        var levelAngles = transform.eulerAngles;
        levelAngles.z = 0f;
        var levelOrientation = Quaternion.Euler(levelAngles);
        transform.rotation = Quaternion.Slerp(transform.rotation, levelOrientation, levelDamping * Time.deltaTime);
    }
}
