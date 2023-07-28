using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_ChaseState : ChaseState
{
    private Enemy1 enemy;
    
    public E1_ChaseState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_ChaseState stateData, GameObject player, Enemy1 enemy) : base(entity, stateMachine, animBoolName, stateData, player)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
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
        
        if (!entity.CheckPlayerChase())
        {
            stateMachine.ChangeState(enemy.idleState);
        }

        if (entity.CheckPlayerAttack())
        {
            Debug.Log("Chasse");
            stateMachine.ChangeState(enemy.attackState);
        }
    }
}
