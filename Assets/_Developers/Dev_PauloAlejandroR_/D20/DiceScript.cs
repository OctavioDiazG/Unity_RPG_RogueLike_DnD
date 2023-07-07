using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DiceScript : MonoBehaviour
{
    public List<GameObject> numbers;
    public int result = 0;

    public Rigidbody rb;
    public bool tossed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (tossed)
        {
            if (rb.velocity.magnitude <= 0)
            {
                readNumber();
                tossed = false;
            }
        }

        if(Input.GetKeyDown(KeyCode.Space)) {
            Toss();
        }
    }

    public void Toss()
    {
        float dirX = Random.Range(0, 500);
        float dirY = Random.Range(0, 500);
        float dirZ = Random.Range(0, 500);
        rb.AddForce(transform.up * 500);
        rb.AddTorque(dirX, dirY, dirZ);
        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.5f);
        tossed = true;
    }

    public void readNumber()
    {
        GameObject cara = numbers[0];
            foreach (GameObject num in numbers)
            {
                if (num.transform.position.y > cara.transform.position.y)
                {
                    cara = num;
                }
            }
        Debug.Log(cara.name);
        result = int.Parse(cara.name);
    }
}
