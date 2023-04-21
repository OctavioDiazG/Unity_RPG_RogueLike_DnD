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
    private PlayerState primaryAttackState = new PlayerPrimaryAttackState();
    private PlayerState secondaryAttackState = new PlayerSecondaryAttackState();
    
    public PlayerLocomotion playerLocomotion => m_playerLocomotion;
    public PlayerInputManager playerInputManager => m_playerInputManager;
    
    public PlayerState WalkState => walkState;
    public PlayerState DodgeState => dodgeState;
    public PlayerState PrimaryAttackState => primaryAttackState;
    public PlayerState SecondaryAttackState => secondaryAttackState;

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
