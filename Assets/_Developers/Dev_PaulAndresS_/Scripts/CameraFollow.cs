using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset = new Vector3(5.0f,7.0f,5.0f);

    private void FixedUpdate()
    {
        offset -= new Vector3(Input.mouseScrollDelta.y,Input.mouseScrollDelta.y,Input.mouseScrollDelta.y);
        
        var desiredPosition = target.position + offset;
        var smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}