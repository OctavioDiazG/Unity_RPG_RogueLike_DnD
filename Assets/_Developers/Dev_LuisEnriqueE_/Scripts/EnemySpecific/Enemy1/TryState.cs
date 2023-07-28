using UnityEngine;

public class TryState : ChaseState
{
    private Enemy1 enemy;
    
    public TryState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_ChaseState stateData, GameObject player, Enemy1 enemy) : base(entity, stateMachine, animBoolName, stateData, player)
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
    }
}