using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newBossData", menuName = "Data/Boss Data/Base Data")]
public class B_Entity : ScriptableObject
{
    public float specialAttackDistance = 10f;
    public int specialAttackDamage = 30;
}
