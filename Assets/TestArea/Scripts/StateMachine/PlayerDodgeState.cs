using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDodgeState : PlayerState
{
    public override void OnEnter(PlayerStateMachine machine)
    {
        Debug.Log("Entrando a Dodge");
    }

    public override void OnUpdate(PlayerStateMachine machine)
    {
        
    }

    public override void OnExit(PlayerStateMachine machine)
    {
        Debug.Log("Saliendo de Dodge");
    }
}
