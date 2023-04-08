using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    public Transform cameraObject;
    PlayerInputManager playerInputManager;
    Vector3 moveDirection;
    
    [HideInInspector]
    public Transform myTransform;
    [HideInInspector]
    public AnimationHandler animationHandler;
    
    
    public new Rigidbody rigidbody;
    public GameObject normalCamera;

    [Header("Stats")] 
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float rotationSpeed = 10f;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        playerInputManager = GetComponent<PlayerInputManager>();
        animationHandler = GetComponentInChildren<AnimationHandler>();
        //cameraObject = Camera.main.transform;
        myTransform = transform;
        animationHandler.Initialize();
    }

    public void Update()
    {
        float delta = Time.deltaTime;
        playerInputManager.TickInput(delta);

        moveDirection = cameraObject.forward * playerInputManager.vertical;//AD
        moveDirection += cameraObject.right * playerInputManager.horizontal; //WS
        moveDirection.Normalize();

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

    #region Movement

    Vector3 normalVector;
    Vector3 targetPosition;
    
    private void HandleRotation(float delta)
    {
        Vector3 targetDirection = Vector3.zero;
        float moveOverride = playerInputManager.moveAmount;
        targetDirection = cameraObject.forward * playerInputManager.vertical;//AD
        targetDirection += cameraObject.right * playerInputManager.horizontal;//WS
        targetDirection.Normalize();
        targetDirection.y = 0;
        
        if (targetDirection == Vector3.zero)
            targetDirection = myTransform.forward;
        
        float rs = rotationSpeed;
        
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        Quaternion playerRotation = Quaternion.Slerp(myTransform.rotation, targetRotation, delta * rotationSpeed);
        myTransform.rotation = playerRotation;
    }

    #endregion
}














