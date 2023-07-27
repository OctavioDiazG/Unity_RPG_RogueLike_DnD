using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    [SerializeField]
    Transform cameraObject;
    PlayerInputManager playerInputManager;
    PlayerManager playerManager;
    Vector3 moveDirection;


    [HideInInspector]
    public IDodge Dodge;
    [HideInInspector]
    public Transform myTransform;
    [HideInInspector]
    public AnimationHandler animationHandler;
    [HideInInspector]
    public bool changeState = false;
    
    public Vector3 targetDirection = Vector3.zero;




    public new Rigidbody rigidbody;

    [Header("Stats")] 
    [SerializeField] float movementSpeed = 5f;  //change speed for character speed
    [SerializeField] float rotationSpeed = 10f;
    [SerializeField] float sprintSpeed = 10f;

    private void Awake()
    {
        playerManager = GetComponent<PlayerManager>();
    }

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        playerInputManager = GetComponent<PlayerInputManager>();
        animationHandler = GetComponentInChildren<AnimationHandler>();
        //cameraObject = Camera.main.transform;
        myTransform = transform;
        animationHandler.Initialize();

        Dodge = GetComponent<IDodge>();
    }

    public void StateDelay(float time)
    {
        StartCoroutine(stateDelayCoroutine(time));
    }

    IEnumerator stateDelayCoroutine(float time)
    {
        yield return new WaitForSeconds(time);
        changeState = true;
    }

    #region Movement

    Vector3 normalVector;
    Vector3 targetPosition;
    
    public void HandleMovement(float delta)
    {
        moveDirection = cameraObject.forward * playerInputManager.vertical;
        moveDirection += cameraObject.right * playerInputManager.horizontal;
        moveDirection.Normalize();
        moveDirection.y = 0;

        float speed = movementSpeed;    //change speed for character speed in.
        playerManager.isSprinting = false;
        if (playerInputManager.moveAmount!=0)
        {
            if (playerInputManager.wantsToSprint)
            {
                speed = sprintSpeed;
                playerManager.isSprinting = true;
                moveDirection *= speed;
            }
            else
            {
                moveDirection *= speed;
            }
        }
     

        Vector3 projectedVelocity = Vector3.ProjectOnPlane(moveDirection, normalVector);
        rigidbody.velocity = projectedVelocity;

        animationHandler.UpdateAnimatorValues(playerInputManager.moveAmount, 0, playerManager.isSprinting);

        if (animationHandler.canRotate)
        {
            HandleRotation(delta);
        }
    }
    public void HandleRotation(float delta)
    {
        Vector3 targetDirection = Vector3.zero;
        float moveOverride = playerInputManager.moveAmount;
        
        targetDirection = cameraObject.forward * playerInputManager.vertical;
        targetDirection += cameraObject.right * playerInputManager.horizontal;

        targetDirection.Normalize();
        targetDirection.y = 0;
        
        if (targetDirection == Vector3.zero)
            targetDirection = myTransform.forward;
        
        float rs = rotationSpeed;
        
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
        Quaternion playerRotation = Quaternion.Slerp(myTransform.rotation, targetRotation, delta * rs);
        myTransform.rotation = playerRotation;

        /* as soon as tested we can delete this. 
        Matrix4x4 _isoMatrix = Matrix4x4.Rotate(Quaternion.Euler(0, cameraObject.transform.rotation.y, 0));
        targetDirection = Vector3.zero;
        Vector3 _input = new Vector3(playerInputManager.movementInput.x, 0, playerInputManager.movementInput.y);
        float moveOverride = playerInputManager.moveAmount;
        targetDirection = (transform.position + _isoMatrix.MultiplyPoint3x4(_input)) - transform.position;
        targetDirection.y = 0;


        if (targetDirection == Vector3.zero)
            targetDirection = myTransform.forward;
        
        float rs = rotationSpeed;
        
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
        Quaternion playerRotation = Quaternion.Slerp(myTransform.rotation, targetRotation, delta * rs);
        myTransform.rotation = playerRotation;
        */
    }
    public void HandleRollingAndSprinting(float delta)
    {
        if (animationHandler.anim.GetBool("isInteracting"))
        {   
            return;
        }
        
        if (playerInputManager.wantsToDodge)
        {
            Debug.Log("MoveDirection = Camera.forward");
            moveDirection = cameraObject.forward * playerInputManager.vertical;
            moveDirection += cameraObject.right * playerInputManager.horizontal;

            if (playerInputManager.moveAmount > 0)
            {
                animationHandler.PlayTargetAnimation("ForwardRolling",true);
                moveDirection.y = 0;
                Quaternion rollRotation = Quaternion.LookRotation(moveDirection);
                myTransform.rotation = rollRotation;
                Debug.Log("Can Roll Forward");
                
            }
            else
            {
                animationHandler.PlayTargetAnimation("BackwardRolling",true);
                Debug.Log("Can Roll Backward");
                
            }
        }
    }

    #endregion
}














