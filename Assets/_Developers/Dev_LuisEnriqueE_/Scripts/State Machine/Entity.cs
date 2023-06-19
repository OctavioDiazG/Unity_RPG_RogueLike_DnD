using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public FiniteStateMachine stateMachine;

    public D_Entity entityData;
    
    public int facingDirection { get; private set; }
    
    public Rigidbody rb { get; private set; }
    public Animator anim { get; private set; }
    public GameObject aliveGo { get; private set; }

    private Vector2 velocityWorkspace;

    [SerializeField] private Transform wallCheck;
    [SerializeField] private Transform ledgeCheck;

    public virtual void Start()
    {
        facingDirection = 1;
        
        aliveGo = transform.Find("Alive").gameObject;
        rb = aliveGo.GetComponent<Rigidbody>();
        anim = aliveGo.GetComponent<Animator>();

        stateMachine = new FiniteStateMachine();
    }

    public virtual void Update()
    {
        stateMachine.currentState.LogicUpdate();
    }

    public virtual void FixedUpdate()
    {
        stateMachine.currentState.PhysicsUpdate();
    }

    public virtual void SetVelocity(float velocity)
    {
        velocityWorkspace.Set(facingDirection * velocity, rb.velocity.y);
        rb.velocity = velocityWorkspace;
    }

    public virtual bool CheckWall()
    {
        return Physics.Raycast(wallCheck.position, aliveGo.transform.right, entityData.wallCheckDistance,
            entityData.whatIsGround);
    }
    
    public virtual bool CheckLedge()
    {
        return Physics.Raycast(ledgeCheck.position, Vector3.down, entityData.ledgeCheckDistance,
            entityData.whatIsGround);
    }

    public virtual void Flip()
    {
        facingDirection *= -1;
        
        aliveGo.transform.Rotate(0f, 180f, 0f);
    }
    
    public virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(wallCheck.position, wallCheck.position + (Vector3)(Vector2.right * facingDirection * entityData.wallCheckDistance));
        Gizmos.DrawLine(ledgeCheck.position, ledgeCheck.position + (Vector3)(Vector2.down * entityData.ledgeCheckDistance));
    }
}
