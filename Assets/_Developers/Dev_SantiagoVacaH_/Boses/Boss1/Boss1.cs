using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : Entity
{
    public B1_IdleState idleState { get; private set; }
    public B1_MoveState moveState { get; private set; }
    public B1_ChaseState chaseState { get; private set; }
    public B1_AttackState attackState { get; private set; }
    
    [SerializeField] private D_IdleState idleStateData;
    [SerializeField] private D_MoveState moveStateData;
    [SerializeField] private D_ChaseState chaseStateData;
    
    public override void Start()
    {
        base.Start();

        moveState = new B1_MoveState(this, stateMachine, "move", moveStateData, this);
        idleState = new B1_IdleState(this, stateMachine, "idle", idleStateData, this);
        chaseState = new B1_ChaseState(this, stateMachine, "chase", chaseStateData, GameObject.Find("Player"), this);
        
        stateMachine.Initialize(moveState);
    }
    
}
