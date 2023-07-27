using UnityEngine;


[CreateAssetMenu(fileName = "newAttackStateData", menuName = "Data/State Data/Attack State")]
public class D_AttackState : ScriptableObject
{
    //TODO: check if the player life is int
    public int heavyDamage = 10;
    public int lightDamage = 5;

    public float attackSpeed = 2.0f;
    
    public int attackChanceHeavy = 1;
    public int attackChanceLight = 2;
    public int maxMissAttackChance = 3;
}