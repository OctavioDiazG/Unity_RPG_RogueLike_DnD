using UnityEngine;

public class PlayerPrimaryAttackState : PlayerState
{
    public override void OnEnter(PlayerStateMachine machine)
    {
        Debug.Log("Entrando a Primary Attack");
        machine.SetState(machine.WalkState);
    }

    public override void OnUpdate(PlayerStateMachine machine)
    {
        //Not final
        if (machine.playerInputManager.wantsToSecondaryAttack)
            machine.SetState(machine.SecondaryAttackState);
    }

    public override void OnExit(PlayerStateMachine machine)
    {
        Debug.Log("Saliendo de Primary Attack");
    }
}
