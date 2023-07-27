using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_SpecialState : AttackState
{
    private Boss1 enemy;

    private int specialChance = 1;
    private int missAttackChance;
    private int maxMissAttackChance = 3;

    public B_SpecialState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, B_AttackState stateData, PlayerDumy player, Boss1 enemy) : base(entity, stateMachine, animBoolName, stateData, player)
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
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    private int CalculatePlayerHit()
    {
        int aux = Random.Range(0, specialChance + missAttackChance);

        if (aux < missAttackChance)
        {
            if (missAttackChance > 0)
            {
                missAttackChance--;
            }
            return 0;
        }
        else if (aux < missAttackChance + specialChance)
        {
            missAttackChance = maxMissAttackChance;
            return 1;
        }
        missAttackChance = maxMissAttackChance;
        return 2;
    }
}
