using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B1_AttackState : AttackState
{
    private Boss1 enemy;

    private int attackChanceHeavy = 1;
    private int attackChanceLight = 2;

    private int missAttackChance;
    private int maxMissAttackChance = 3;

    public B1_AttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, B_AttackState stateData, PlayerDumy player, Boss1 enemy) : base(entity, stateMachine, animBoolName, stateData, player)
    {
        this.enemy = enemy;
        missAttackChance = maxMissAttackChance;
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
        if (isAttackReady)
        {
            isAttackReady = false;
            switch (CalculatePlayerHit())
            {
                case 0:
                    //TODO: add an animation without dealing damage
                    break;
                
                case 1:
                    //TODO: change to the real function to take damage
                    player.TakeDamege(stateData.lightDamage);
                    break;
                
                case 2:
                    player.TakeDamege(stateData.heavyDamage);
                    break;
            }

            if (entity.CheckPlayerAttack())
            {
                startTime = Time.time;
            }
            else
            {
                stateMachine.ChangeState(enemy.chaseState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
