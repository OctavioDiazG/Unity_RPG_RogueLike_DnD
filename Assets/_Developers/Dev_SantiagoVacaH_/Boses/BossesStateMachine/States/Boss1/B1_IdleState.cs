using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B1_IdleState : IdleState
{
    private Boss1 enemy;
    
    public B1_IdleState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, B_IdleState stateData, Boss1 enemy) : base(entity, stateMachine, animBoolName, stateData)
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

        if (isIdleTimeOver)
        {
            stateMachine.ChangeState(enemy.moveState);
        }

        if (entity.CheckPlayerChase())
        {
            stateMachine.ChangeState(enemy.chaseState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
