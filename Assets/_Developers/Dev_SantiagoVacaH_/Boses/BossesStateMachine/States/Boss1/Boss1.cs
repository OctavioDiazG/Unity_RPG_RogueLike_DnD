using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : Entity
{
    public B1_IdleState idleState { get; private set; }
    public B1_MoveState moveState { get; private set; }
    public B1_ChaseState chaseState { get; private set; }
    public B1_AttackState attackState { get; private set; }
    public B_SpecialState specialState { get; private set; }
    
    [SerializeField] private B_Entity bEntity;
    [SerializeField] private B_IdleState idleStateData;
    [SerializeField] private B_MoveState moveStateData;
    [SerializeField] private B_ChaseState chaseStateData;
    [SerializeField] private B_AttackState attackStateData;

    public TriggersController specialAttackTrigger;
    
    public override void Start()
    {
        base.Start();

        GameObject player = GameObject.Find("Player");

        moveState = new B1_MoveState(this, stateMachine, "move", moveStateData, this);
        idleState = new B1_IdleState(this, stateMachine, "idle", idleStateData, this);
        chaseState = new B1_ChaseState(this, stateMachine, "chase", chaseStateData, GameObject.Find("Player"), this);
        attackState = new B1_AttackState(this, stateMachine, "attack", attackStateData, player.GetComponent<PlayerDumy>(), this);
        specialState = new B1_SpecialState(this, stateMachine, "special", attackStateData, player.GetComponent<PlayerDumy>(), this);

        specialAttackTrigger.GetComponent<SphereCollider>().radius = bEntity.specialAttackDistance;
        
        stateMachine.Initialize(moveState);
    }

    public virtual bool CheckPlayerSpecial()
    {
        return specialAttackTrigger.isTriggered;
    }
    
}
