using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraController : MonoBehaviour
{
    public float _sensitivity = 2.0f;
    public float _maxAngle = 80.0f;
    public bool IsMouseControlEnabled = true;

    private float rotationX = 0.0f;

    // Update is called once per frame
    void Update()
    {
        if (IsMouseControlEnabled == false)
        {
            return;
        }
        
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        transform.parent.Rotate(Vector3.up * mouseX * _sensitivity);

        rotationX -= mouseY * _sensitivity;
        rotationX = Mathf.Clamp(rotationX, -_maxAngle, _maxAngle);
        transform.localRotation = Quaternion.Euler(rotationX, 0.0f, 0.0f);
    }
    
}