using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaladinDodge : MonoBehaviour, IDodge
{
    public float dodgeHorizontalDistance = 10f; 
    //public float dodgeVerticalDistance = 0.5f;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Dodge(Vector3 direction)
    {
        //Horizontal force
        rb.AddForce(direction  * dodgeHorizontalDistance, ForceMode.Impulse);
        //vertical force
        //rb.AddForce(Vector3.up * dodgeVerticalDistance, ForceMode.Impulse);

    }
}
