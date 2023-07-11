using UnityEngine;


public class B1_ChaseState : ChaseState
{
    private Boss1 enemy;
        
    public B1_ChaseState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_ChaseState stateData, GameObject player, Boss1 enemy) : base(entity, stateMachine, animBoolName, stateData, player)
    {
            
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
        if (!entity.CheckPlayerChase())
        {
            stateMachine.ChangeState(enemy.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
