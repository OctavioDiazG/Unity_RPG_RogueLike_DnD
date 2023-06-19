using UnityEngine;

public class PlayerDodgeState : PlayerState
{
    public override void OnEnter(PlayerStateMachine machine)
    { 
        Debug.Log("Enter Dodge State");
        machine.playerLocomotion.StateDelay(0.5f);
        machine.playerLocomotion.HandleRollingAndSprinting(Time.deltaTime);

    }

    public override void OnUpdate(PlayerStateMachine machine)
    {
        if (machine.playerLocomotion.changeState)
        {
            machine.playerLocomotion.changeState = false;
            machine.SetState(machine.WalkState);
        }
    }

    public override void OnExit(PlayerStateMachine machine)
    {
        Debug.Log("Saliendo de Dodge");
    }
}
