using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
    protected D_ChaseState stateData;

    protected GameObject player;
    
    public ChaseState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_ChaseState stateData, GameObject player) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
        this.player = player;
    }

    public override void Enter()
    {
        base.Enter();
        entity.SetVelocity(stateData.moveSpeed);
        entity.SetDestination(player.transform.position);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        entity.SetDestination(player.transform.position);
    }
}
