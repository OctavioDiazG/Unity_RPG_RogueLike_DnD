using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    PlayerInputManager playerInputManager;
    Animator anim;
    private PlayerLocomotion playerLocomotion;
    
    public bool isInteracting;
    public bool isSprinting = false;
    public CameraHandler cameraHandler;
    


    // Start is called before the first frame update
    void Start()
    {
        playerInputManager = GetComponent<PlayerInputManager>();
        anim = GetComponentInChildren<Animator>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
    }

    // Update is called once per frame
    void Update()
    {
        float delta = Time.deltaTime;
        isInteracting = anim.GetBool("isInteracting");
        
        isSprinting = playerInputManager.wantsToSprint;
        playerInputManager.TickInput(delta);
        playerLocomotion.HandleRotation(delta);
        playerLocomotion.HandleRollingAndSprinting(delta);

    }
    
    private void LateUpdate()
    {
        float delta = Time.deltaTime;

        if (cameraHandler != null)
        {
            cameraHandler.FollowTarget(delta);
            cameraHandler.HandleCameraRotation(delta, playerInputManager.mouseX, playerInputManager.mouseY);
        }
    }
}
