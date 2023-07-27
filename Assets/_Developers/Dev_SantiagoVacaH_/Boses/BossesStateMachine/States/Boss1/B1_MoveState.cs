using UnityEngine;

public class B1_MoveState : MoveState
{
    private Boss1 enemy;
    
    public B1_MoveState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, B_MoveState stateData, Boss1 enemy) : base(entity, stateMachine, animBoolName, stateData)
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

        distanceToWalkPoint = entity.aliveGo.transform.position - walkPoint;
        
        if (distanceToWalkPoint.magnitude < 1f)
        {
            stateMachine.ChangeState(enemy.idleState);
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
