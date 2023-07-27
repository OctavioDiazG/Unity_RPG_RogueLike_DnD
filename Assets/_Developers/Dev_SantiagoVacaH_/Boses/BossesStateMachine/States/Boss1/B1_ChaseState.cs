using System.Threading;
using UnityEngine;


public class B1_ChaseState : ChaseState
{
    private Boss1 enemy;

    private float specialAtackTimer;
        
    public B1_ChaseState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, B_ChaseState stateData, GameObject player, Boss1 enemy) : base(entity, stateMachine, animBoolName, stateData, player)
    {
            
    }
    
    public override void Enter()
    {
        base.Enter();
        specialAtackTimer = stateData.timeBetweenSpecialAttack;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (!entity.CheckPlayerChase())
        {
            stateMachine.ChangeState(enemy.idleState);
        }

        if (entity.CheckPlayerAttack())
        {
            stateMachine.ChangeState(enemy.attackState);
        }

        if (enemy.CheckPlayerSpecial() && Time.time >= startTime + specialAtackTimer && !entity.CheckPlayerAttack())
        {
            stateMachine.ChangeState(enemy.specialState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
