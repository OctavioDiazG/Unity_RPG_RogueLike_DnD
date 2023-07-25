using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newEntityData", menuName = "Data/Entity Data/Base Data")]
public class D_Entity : ScriptableObject
{
    public float playerCheckDistance = 5f;
    public float attackPlayerDistance = 2f;
    
    public LayerMask whatIsGround;
    public LayerMask whatIsPlayer;
}
