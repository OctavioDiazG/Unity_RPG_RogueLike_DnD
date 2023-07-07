using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Entity : MonoBehaviour
{
    public FiniteStateMachine stateMachine;

    public D_Entity entityData;

    public NavMeshAgent agent { get; private set; }
    public Animator anim { get; private set; }
    public GameObject aliveGo { get; private set; }


    [SerializeField] private Transform wallCheck;
    [SerializeField] private Transform ledgeCheck;

    public virtual void Start()
    {
        
        aliveGo = transform.Find("Alive").gameObject;
        anim = aliveGo.GetComponent<Animator>();
        agent = aliveGo.GetComponent<NavMeshAgent>();

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
        agent.speed = velocity;
    }

    public virtual void SetDestination(Vector3 destination)
    {
        agent.SetDestination(destination);
    }

    public virtual bool CheckPlayerChase()
    {
        return Physics.CheckSphere(transform.position, entityData.playerCheckDistance, entityData.whatIsPlayer);
    }
}
