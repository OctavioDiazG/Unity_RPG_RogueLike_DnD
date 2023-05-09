using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WPEnemyAI : MonoBehaviour
{

    float timer;
    public List<Transform> wayPoints = new List<Transform>();
    public NavMeshAgent agent;
    
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;

        agent.SetDestination(wayPoints[Random.Range(0, wayPoints.Count)].position);
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.SetDestination(wayPoints[Random.Range(0, wayPoints.Count)].position);
        }
    }
}
