using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState
{
    public abstract void OnEnter(PlayerStateMachine machine);
    public abstract void OnUpdate(PlayerStateMachine machine);
    public abstract void OnExit(PlayerStateMachine machine);
}
