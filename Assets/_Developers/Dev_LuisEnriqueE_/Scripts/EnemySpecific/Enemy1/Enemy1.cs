using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Entity
{
    public E1_IdleState idleState { get; private set; }
    public E1_MoveState moveState { get; private set; }
    public E1_ChaseState chaseState { get; private set; }
    public E1_AttackState attackState { get; private set; }

    [SerializeField] private D_IdleState idleStateData;
    [SerializeField] private D_MoveState moveStateData;
    [SerializeField] private D_ChaseState chaseStateData;
    [SerializeField] private D_AttackState attackStateData;

    public override void Start()
    {
        base.Start();

        GameObject player = GameObject.Find("Player");

        moveState = new E1_MoveState(this, stateMachine, "move", moveStateData, this);
        idleState = new E1_IdleState(this, stateMachine, "idle", idleStateData, this);
        chaseState = new E1_ChaseState(this, stateMachine, "chase", chaseStateData, player, this);
        attackState = new E1_AttackState(this, stateMachine, "attack", attackStateData, player.GetComponent<PlayerDumy>(), this);
        
        stateMachine.Initialize(moveState);
    }
}
