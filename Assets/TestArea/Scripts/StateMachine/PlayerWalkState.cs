
using UnityEngine;

public class PlayerWalkState : PlayerState
{
    public override void OnEnter(PlayerStateMachine machine)
    {
        Debug.Log("Entrando a Walk");
    }

    public override void OnExit(PlayerStateMachine machine)
    {
        Debug.Log("Saliendo de Walk");
    }

    public override void OnUpdate(PlayerStateMachine machine)
    {
        machine.playerLocomotion.Move();
        if (machine.playerInputManager.wantsToDodge)
            machine.SetState(machine.DodgeState);
    }
}
