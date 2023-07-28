using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDumy : MonoBehaviour
{
    public int life = 100;

    public void TakeDamege(int damage)
    {
        life -= damage;
    }
}
