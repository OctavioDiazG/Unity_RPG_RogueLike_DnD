using UnityEngine;


public class AttackState : State
{
    protected D_AttackState stateData;

    protected PlayerDumy player;

    protected bool isAttackReady;
    
    protected int attackChanceHeavy;
    protected int attackChanceLight;

    protected int missAttackChance;
    protected int maxMissAttackChance;
    
    //TODO: change playerdumy for the cript for the player
    public AttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_AttackState stateData, PlayerDumy player) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
        this.player = player;

        attackChanceHeavy = this.stateData.attackChanceHeavy;
        attackChanceLight = this.stateData.attackChanceLight;
        maxMissAttackChance = this.stateData.maxMissAttackChance;
    }


    public override void Enter()
    {
        base.Enter();
        entity.SetVelocity(0);
        isAttackReady = false;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (Time.time >= startTime + stateData.attackSpeed)
        {
            isAttackReady = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public virtual int CalculatePlayerHit()
    {
        int aux = Random.Range(0, attackChanceLight + attackChanceHeavy + missAttackChance);

        if (aux < missAttackChance)
        {
            if (missAttackChance > 0)
            {
                missAttackChance--;
            }
            return 0;
        }
        else if (aux < missAttackChance + attackChanceLight)
        {
            missAttackChance = maxMissAttackChance;
            return 1;
        }
        missAttackChance = maxMissAttackChance;
        return 2;
    }
}