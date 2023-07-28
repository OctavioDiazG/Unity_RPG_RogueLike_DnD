using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B1_SpecialState : AttackState
{
    private Boss1 enemy;
    private B_Entity bEntity;
    private int specialChance = 1;
    private int missAttackChance;
    private int maxMissAttackChance = 3;

    public B1_SpecialState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, B_AttackState stateData, PlayerDumy player, Boss1 enemy, B_Entity bEntity) : base(entity, stateMachine, animBoolName, stateData, player)
    {
        this.enemy = enemy;
        this.bEntity = bEntity;
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
        switch (CalculatePlayerHit())
            {
                case 0:
                    //TODO: add an animation without dealing damage
                    break;
                
                case 1:
                    //TODO: change to the real function to take damage
                    player.TakeDamege(bEntity.specialAttackDamage);
                    break;
            }
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
        missAttackChance = maxMissAttackChance;
        return 1;
    }
}
