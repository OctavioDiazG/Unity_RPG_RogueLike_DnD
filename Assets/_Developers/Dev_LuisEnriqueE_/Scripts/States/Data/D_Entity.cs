using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newEntityData", menuName = "Data/Entity Data/Base Data")]
public class D_Entity : ScriptableObject
{
    public float wallCheckDistance = 0.2f;
    public float ledgeCheckDistance = 0.4f;

    public float playerCheckDistance = 10f;
    public float attackPlayerDistance = 4f;
    
    public LayerMask whatIsGround;
    public LayerMask whatIsPlayer;
}
