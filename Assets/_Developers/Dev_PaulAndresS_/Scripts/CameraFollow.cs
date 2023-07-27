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
        switch (offset.x)
        {
            case >= 6.0f:
                offset = new Vector3(5.99f, 8.0f, 6.0f);
                break;
            case <= 1.0f:
                offset = new Vector3(1.01f, 3.0f, 1.0f);
                break;
            default:
                offset -= new Vector3(Input.mouseScrollDelta.y,Input.mouseScrollDelta.y,Input.mouseScrollDelta.y);
                break;
        }
        var desiredPosition = target.position + offset;
        var smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}