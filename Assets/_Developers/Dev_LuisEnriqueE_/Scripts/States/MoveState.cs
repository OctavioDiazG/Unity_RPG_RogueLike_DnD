using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
    protected D_MoveState stateData;
    
    protected bool isDetectingPlayer;

    protected Vector3 walkPoint;
    protected Vector3 distanceToWalkPoint;
    protected bool walkPointSet;
    
    public MoveState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_MoveState stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();
        SearchWalkPoint();
        entity.SetVelocity(stateData.movementSpeed);
        entity.SetDestination(walkPoint);

        isDetectingPlayer = entity.CheckPlayerChase();
    }

    public override void Exit()
    {
        base.Exit();
        walkPointSet = false;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        
        isDetectingPlayer = entity.CheckPlayerChase();
    }

    public void SearchWalkPoint()
    {
        float randomZ = Random.Range(-stateData.walkRange, stateData.walkRange);
        float randomX = Random.Range(-stateData.walkRange, stateData.walkRange);

        Vector3 pos = entity.aliveGo.transform.position;

        walkPoint = new Vector3(pos.x + randomX, pos.y, pos.z + randomZ);

        if (Physics.Raycast(walkPoint, -entity.transform.up, 3f, entity.entityData.whatIsGround))
            walkPointSet = true;
        else
            SearchWalkPoint();
    }
}
