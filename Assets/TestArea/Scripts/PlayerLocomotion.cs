using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    PlayerInputManager playerInputManager;
    Vector3 moveDirection;
    
    [HideInInspector]
    public Transform myTransform;
    [HideInInspector]
    public AnimationHandler animationHandler;
    
    
    public new Rigidbody rigidbody;

    [Header("Stats")] 
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float rotationSpeed = 10f;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        playerInputManager = GetComponent<PlayerInputManager>();
        animationHandler = GetComponentInChildren<AnimationHandler>();
        myTransform = transform;
        animationHandler.Initialize();
    }

    /*public void Update()
    {
        Move();
    }*/

    public void Move()
    {
        float delta = Time.deltaTime;
        playerInputManager.TickInput(delta);
        Vector3 _input = new Vector3(playerInputManager.movementInput.x, 0, playerInputManager.movementInput.y);

        moveDirection = _input.ToIso();

        float speed = movementSpeed;
        moveDirection *= speed;

        Vector3 projectedVelocity = Vector3.ProjectOnPlane(moveDirection, normalVector);
        rigidbody.velocity = projectedVelocity;

        animationHandler.UpdateAnimatorValues(playerInputManager.moveAmount, 0);

        if (animationHandler.canRotate)
        {
            HandleRotation(delta);
        }
    }

    #region Rotation

    Vector3 normalVector;
    Vector3 targetPosition;
    
    public void HandleRotation(float delta)
    {
        Vector3 targetDirection = Vector3.zero;
        Vector3 _input = new Vector3(playerInputManager.movementInput.x, 0, playerInputManager.movementInput.y);
        float moveOverride = playerInputManager.moveAmount;
        targetDirection = (transform.position + _input.ToIso()) - transform.position;
        targetDirection.y = 0;


        if (targetDirection == Vector3.zero)
            targetDirection = myTransform.forward;
        
        float rs = rotationSpeed;
        
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
        Quaternion playerRotation = Quaternion.Slerp(myTransform.rotation, targetRotation, delta * rs);
        myTransform.rotation = playerRotation;
    }

    #endregion
}














