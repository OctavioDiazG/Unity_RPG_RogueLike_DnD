using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggersController : MonoBehaviour
{
    public bool isTriggered { get; private set; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            isTriggered = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            isTriggered = false;
    }
}
