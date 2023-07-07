using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    public bool wantsToPrimaryAttack;
    public bool wantsToSecondaryAttack;
    public bool wantsToDodge;
    public bool wantsToInteract;
    
    
    
    //New
    public float horizontal;
    public float vertical;
    public float moveAmount;
    public float mouseX;   
    public float mouseY;   
    
    public bool b_input;
    public bool rollFlag;
    public bool isInteracting;
    
    

    PlayerInputActions playerInputs;
    public CameraHandler cameraHandler;
    
    public Vector2 movementInput;
    public Vector2 cameraInput;

    void Awake()
    {
        //cameraHandler = CameraHandler.singleton;
        playerInputs = new PlayerInputActions();
    }

    private void LateUpdate()
    {
        float delta = Time.deltaTime;

        if (cameraHandler != null)
        {
            cameraHandler.FollowTarget(delta);
            cameraHandler.HandleCameraRotation(delta, mouseX, mouseY);
        }
    }

    private void OnEnable()
    {
        //new
        if (playerInputs != null)
        {
            playerInputs = new PlayerInputActions();
            playerInputs.BasicMovement.Movement.performed += ctx => MovementInput(ctx);
            playerInputs.BasicMovement.Camera.performed += ctx => CameraInput(ctx);
        }
        
        playerInputs.Enable();
    }
    private void OnDisable()
    {
        playerInputs.Disable();
    }

    private void Start()
    {
        //Combate
        playerInputs.Combat.HeavyAttack.performed += ctx => HeavyAttackInput(ctx);
        playerInputs.Combat.LightAttack.performed += ctx => LightAttackInput(ctx);

        //Movimiento
        playerInputs.BasicMovement.Movement.performed += ctx => MovementInput(ctx);
        playerInputs.BasicMovement.Movement.canceled += ctx => MovementInputZero(ctx);
        
        //Dodge
        playerInputs.BasicMovement.Dodge.performed += ctx => DodgeInput(ctx);

        //Interact
        playerInputs.Interaction.Interact.performed += ctx => InteractInput(ctx);
    }

    private void InteractInput(InputAction.CallbackContext ctx)
    {
        //StopCoroutine(CancelInteractCoroutine());
        wantsToInteract = true;

        //StartCoroutine(CancelInteractCoroutine());
    }

    /*IEnumerator CancelInteractCoroutine()
    {
        yield return new WaitForSeconds(0.1f);
        wantsToInteract = false;
    }*/

    private void DodgeInput(InputAction.CallbackContext ctx)
    {
        StopCoroutine(CancelDodgeCoroutine());
        wantsToDodge = true;
        
        Debug.Log("Dodge Button pressed DodgeInput");
        StartCoroutine(CancelDodgeCoroutine());
    }

    IEnumerator CancelDodgeCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        wantsToDodge= false;
    }

    public void TickInput(float delta)
    {
        MoveInput(delta);
        //HandleRollInput(delta);
    }
    
    private void MoveInput (float delta)
    {
        horizontal = movementInput.x;
        vertical = movementInput.y;
        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontal) + Mathf.Abs(vertical));
        mouseX = cameraInput.x;
        mouseY = cameraInput.y;
        
    }

    /*private void HandleRollInput(float delta)
    {
        b_input = playerInputs.BasicMovement.Dodge.phase == UnityEngine.InputSystem.InputActionPhase.Started;
        if (b_input)
        {
            wantsToDodge = true;
            Debug.Log("Dodge Button pressed HandleRollInput");
        }
    }*/

    void LightAttackInput(InputAction.CallbackContext context)
    {
        StopCoroutine(CancelLightAttackCoroutine());
        wantsToPrimaryAttack = true;
        StartCoroutine(CancelLightAttackCoroutine());
    }

    IEnumerator CancelLightAttackCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        wantsToPrimaryAttack= false;

    }

    void HeavyAttackInput(InputAction.CallbackContext context)
    {
        StopCoroutine(CancelHeavyAttackCoroutine());
        wantsToSecondaryAttack = true;
        Debug.Log("Heavy");
        StartCoroutine(CancelHeavyAttackCoroutine());
    }

    IEnumerator CancelHeavyAttackCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        wantsToSecondaryAttack = false;
        Debug.Log("Heavy Canceled");
    }

    void MovementInput(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }
    
    void CameraInput(InputAction.CallbackContext context)
    {
        cameraInput = Mouse.current.delta.ReadValue();
    }

    void MovementInputZero(InputAction.CallbackContext context)
    {
        movementInput = new Vector2();
    }

    void Tester(InputAction.CallbackContext context)
    {
        Debug.Log("Comes");
    }
}
