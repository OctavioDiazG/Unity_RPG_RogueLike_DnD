using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    //public Vector2 movementVector;
    public bool wantsToLight;
    public bool wantsToHeavy;
    
    //New
    public float horizontal;
    public float vertical;
    public float moveAmount;
    public float mouseX;
    public  float mouseY;

    PlayerInputActions playerInputs;
    
    Vector2 movementInput;
    Vector2 cameraInput;

    void Awake()
    {
        playerInputs = new PlayerInputActions();
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

        //Movimiento
        playerInputs.BasicMovement.Movement.performed += ctx => MovementInput(ctx);
        playerInputs.BasicMovement.Movement.canceled += ctx => MovementInputZero(ctx);
    }

    public void TickInput(float delta)
    {
        MoveInput(delta);
    }
    
    private void MoveInput (float delta)
    {
        horizontal = movementInput.x;
        vertical = movementInput.y;
        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontal) + Mathf.Abs(vertical));
        mouseX = cameraInput.x;
        mouseY = cameraInput.y;
    }

    void LightAttackInput(InputAction.CallbackContext context)
    {
        StopCoroutine(CancelLightAttackCoroutine());
        wantsToHeavy = true;
        
        StartCoroutine(CancelLightAttackCoroutine());
    }

    IEnumerator CancelLightAttackCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        wantsToLight= false;

    }

    void HeavyAttackInput(InputAction.CallbackContext context)
    {
        StopCoroutine(CancelHeavyAttackCoroutine());
        wantsToHeavy = true;
        Debug.Log("Heavy");
        StartCoroutine(CancelHeavyAttackCoroutine());
    }

    IEnumerator CancelHeavyAttackCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        wantsToHeavy = false;
        Debug.Log("Heavy Canceled");
    }

    void MovementInput(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }
    
    void CameraInput(InputAction.CallbackContext context)
    {
        cameraInput = context.ReadValue<Vector2>();
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
