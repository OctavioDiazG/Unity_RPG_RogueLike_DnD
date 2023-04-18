using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    [SerializeField] private PlayerLocomotion m_playerLocomotion;
    [SerializeField] private PlayerInputManager m_playerInputManager;
    
    private PlayerState currentState;
    
    private PlayerState walkState = new PlayerWalkState();
    private PlayerState dodgeState = new PlayerDodgeState();
    
    public PlayerLocomotion playerLocomotion => m_playerLocomotion;
    public PlayerInputManager playerInputManager => m_playerInputManager;
    
    public PlayerState WalkState => walkState;
    public PlayerState DodgeState => dodgeState;

    private void Awake()
    {
        SetState(walkState);
    }

    public void SetState(PlayerState state){

        currentState?.OnExit(this);
        currentState = state;
        currentState?.OnEnter(this);
    }

    private void Update()
    {
        currentState?.OnUpdate(this);
    }
}
