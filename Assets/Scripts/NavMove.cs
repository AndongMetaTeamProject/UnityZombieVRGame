using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class NavMove : MonoBehaviour
{
    public Transform target;
    Vector3 destination;
    UnityEngine.AI.NavMeshAgent agent;

    void Start()
    {
        // Cache agent component and destination
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
       
    }
    

    void Update()
    {
        
        destination = agent.destination;
        // Update destination if the target moves one unit
        if (Vector3.Distance(destination, target.position) > 1.0f)
        {
           
            destination = target.position;
            agent.destination = destination;
        }
    }
}
