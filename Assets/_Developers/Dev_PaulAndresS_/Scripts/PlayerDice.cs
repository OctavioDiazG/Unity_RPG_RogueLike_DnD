using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerDice : MonoBehaviour
{
    private int _die;

    private void OnTriggerEnter(Collider other)
    {
        if (CompareTag("Player"))
        {
            _die = Random.Range(1, 21);
            
        }
    }
}

