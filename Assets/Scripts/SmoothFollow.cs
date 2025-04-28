using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
    public Transform target;
    public float height = 5.0f;
    public float distance = 10.0f;
    public float rotationDamping;
    public float hightDamping;

    private void LateUpdate()
    {
        if (!target) return;

        var wantedRotationAngle = transform.eulerAngles.y;
        var wantedHight = target.position.y + height;
        var currentRotationAngle = transform.eulerAngles.y;
        var currentHight = target.position.y;

        currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping *  Time.deltaTime);
        currentHight = Mathf.LerpAngle(currentHight, wantedHight, hightDamping * Time.deltaTime);
        var currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

        transform.position = target.position;
        transform.position -= currentRotation * Vector3.forward * distance;
        transform.position = new Vector3(transform.position.x, currentHight, transform.position.z);
        transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, rotationDamping * Time.deltaTime);
    }
}
