using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDumy : MonoBehaviour
{
    public Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(10f, 0f, 0f);
    }
}
