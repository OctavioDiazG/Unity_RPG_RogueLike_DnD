using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    PlayerInputManager playerInputManager;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        playerInputManager = GetComponent<PlayerInputManager>();
        anim = GetComponentInChildren<Animator>();
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        playerInputManager.isInteracting = anim.GetBool("isInteracting");

    }
}
