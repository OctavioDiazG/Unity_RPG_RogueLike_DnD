using System.Threading;
using UnityEngine;


public class B1_ChaseState : ChaseState
{
    public B_ChaseState b_StateData;
    private Boss1 enemy;

    private float specialAtackTimer;
        
    public B1_ChaseState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_ChaseState stateData, GameObject player, Boss1 enemy, B_ChaseState b_StateData) : base(entity, stateMachine, animBoolName, stateData, player)
    {
        this.enemy = enemy;
        this.b_StateData = b_StateData;
    }
    
    public override void Enter()
    {
        base.Enter();
        specialAtackTimer = b_StateData.timeBetweenSpecialAttack;
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
